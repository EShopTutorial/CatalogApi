using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace CatalogApi.Models
{
    public class ItemCatalog
    {
        public int ID { get; set; }

        [Required]
        public string ItemCategory { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }

        [Range(10, 9999)]
        public int ItemValue { get; set; }

        [Required]
        public int? Quantity { get; set; }
    }
}