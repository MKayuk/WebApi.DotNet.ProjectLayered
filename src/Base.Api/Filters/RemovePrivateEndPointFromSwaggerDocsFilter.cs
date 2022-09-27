using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Immutable;
using System.Linq;

namespace Base.Filters
{
    public class RemovePrivateEndPointFromSwaggerDocsFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var privateRoutes = swaggerDoc.Paths
                .Where(_ => _.Key.ToLower().Contains("private")).ToImmutableList();

            privateRoutes.ForEach(route =>
            {
                var (key, _) = route;
                swaggerDoc.Paths.Remove(key);
            });
        }
    }
}
