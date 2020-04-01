using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net.Http.Formatting;
using System.Net.Http.Headers;

using CatalogApi.Models;
using System.IO;
using System.Net.Http;

namespace CatalogApi.MIddleWare
{
    public class CatalogCSVFormatter : BufferedMediaTypeFormatter
    {
        public CatalogCSVFormatter()
        {
            // Add the supported media type.
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/csv"));
        }

        public override bool CanWriteType(Type type)
        {
            if (type == typeof(ItemCatalog))
            {
                return true;
            }
            else
            {
                Type enumerableType = typeof(IEnumerable<ItemCatalog>);
                return enumerableType.IsAssignableFrom(type);
            }
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
        {
            using (var writer = new StreamWriter(writeStream))
            {
                var products = value as IEnumerable<ItemCatalog>;
                if (products != null)
                {
                    foreach (var product in products)
                    {
                        WriteItem(product, writer);
                    }
                }
                else
                {
                    var singleProduct = value as ItemCatalog;
                    if (singleProduct == null)
                    {
                        throw new InvalidOperationException("Cannot serialize type");
                    }
                    WriteItem(singleProduct, writer);
                }
            }
        }

        // Helper methods for serializing Products to CSV format. 
        private void WriteItem(ItemCatalog catalog, StreamWriter writer)
        {
            writer.WriteLine("{0},{1},{2},{3},{4}", Escape(catalog.ID),
                Escape(catalog.ItemName), Escape(catalog.ItemCategory), Escape(catalog.ItemDescription), Escape(catalog.ItemValue));
        }

        static char[] _specialChars = new char[] { ',', '\n', '\r', '"' };

        private string Escape(object o)
        {
            if (o == null)
            {
                return "";
            }
            string field = o.ToString();
            if (field.IndexOfAny(_specialChars) != -1)
            {
                // Delimit the entire field with quotes and replace embedded quotes with "".
                return String.Format("\"{0}\"", field.Replace("\"", "\"\""));
            }
            else return field;
        }
    }
}