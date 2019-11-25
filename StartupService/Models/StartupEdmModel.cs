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
            return builder.GetEdmModel();
        }
    }
}