using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogApi.Factory
{
    public class ConnectionClass : IDisposable
    {
        public Channel CreateModel() {
            return new Channel();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    public class Channel : IDisposable
        {
      public Channel  channel;
                string message;
        string body;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void ExchangeDeclare() { 
        
        }

        public void BasicPublish()
        { }
    }
}