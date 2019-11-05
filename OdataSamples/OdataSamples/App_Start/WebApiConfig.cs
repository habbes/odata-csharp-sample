using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using OdataSamples.Models;

namespace OdataSamples
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            var builder = new ODataConventionModelBuilder();
           

            builder.EntitySet<Car>("Car");

            //return builder.GetEdmModel();

            builder.Namespace = "CarService";

            builder.EntityType<Car>().Collection
                .Function("HighestCarValue")
                .Returns<double>();

            builder.EntityType<Car>().Collection
               .Function("ModelWithHighestCarValue")
               .Returns<string>();

            builder.EntityType<Car>().Collection
              .Function("MostLikedCarColor")
              .Returns<string>();

            builder.EntityType<Car>()
               .Action("CarValueUpdate")
               .Parameter<double>("CarValue");


            config.Count().Filter().OrderBy().Expand().Select().MaxTop(null);

            config.MapODataServiceRoute("ODataRoute", null, builder.GetEdmModel());
          
        }
    }
}
