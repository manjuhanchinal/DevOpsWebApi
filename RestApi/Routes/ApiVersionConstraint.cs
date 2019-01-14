using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http.Routing;

namespace RestApiDemo.Routes
{
    public class ApiVersionConstraint: IHttpRouteConstraint
    {
         
        public string AllowedVersion { get; set; }

        public ApiVersionConstraint(string allowedVersion)
        {
            AllowedVersion = allowedVersion;
        }

        public bool Match(HttpRequestMessage httpRequestMessage, IHttpRoute httpRoute, string parameterName, IDictionary<string, object> values, HttpRouteDirection routeDirection)
        {
            object value;

            if (values.TryGetValue(parameterName, out value) && value !=null)
            {
                return AllowedVersion.Equals(value.ToString().ToUpperInvariant());
            }
            return false;
        }
    }
}