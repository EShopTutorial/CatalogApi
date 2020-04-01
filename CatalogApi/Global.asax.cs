using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

using CatalogApi.Data;

namespace CatalogApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

          //  var db = new CatalogContext();

            // This is an alternate method to seed database. The other option is Web.Config

          //  Database.SetInitializer(new DropCreateDatabaseAlways<CatalogContext>());

            AreaRegistration.RegisterAllAreas();

            //using (var db1 = new CatalogContext()) //initializer won't be called here
            //{
            //    db.Database.Initialize(false);

            //}

        }
    }
}
