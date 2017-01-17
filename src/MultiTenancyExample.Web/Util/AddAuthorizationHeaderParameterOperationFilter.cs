using System.Collections.Generic;
using Swashbuckle.Swagger.Model;
using Swashbuckle.SwaggerGen.Generator;

namespace MultiTenancyExample.Web.Util
{
    /// <summary>
    /// Utils contains utility classes for dev/test scenarios. This operation filter is for use with Swagger.
    /// </summary>
    public class AddAuthorizationHeaderParameterOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<IParameter>();
            }

            operation.Parameters.Add(new NonBodyParameter
            {
                Name = "Authorization",
                Description = "access token",
                In = "header",
                Required = false,
                Type = "string"
            });
        }
    }
}