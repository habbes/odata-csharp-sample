using Microsoft.OData.Edm;
using Microsoft.AspNet.OData.Builder;

namespace StartupService.Models
{
    public static class StartupEdmModel
    {
        public static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Company>("Companies");
            builder.EntitySet<Person>("People");

            builder.ComplexType<Address>();

            var func = builder.Function("MostPopularLocationInPeriod").Returns<Address>();
            func.Parameter<int>("startYear");
            func.Parameter<int>("endYear");

            var action = builder.EntityType<Company>().Collection.Action("MakePublic").ReturnsFromEntitySet<Company>("Companies");
            action.Parameter<int>("company");

            return builder.GetEdmModel();
        }
    }
}