using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogApi.Factory
{
    public class ConnectionFactory
    {
        public string HostName { get; set; }

        public ConnectionClass CreateConnection() {
            return new ConnectionClass();
        }
    }
}