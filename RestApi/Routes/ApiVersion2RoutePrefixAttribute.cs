﻿using System.Web.Http;

namespace RestApiDemo.Routes
{
    public class ApiVersion2RoutePrefixAttribute: RoutePrefixAttribute
    {

        private const string RouteBase = "{apiVersion:apiVersionConstraint(V2)}";
        private const string PrefixRouteBase = RouteBase + "/";

        public ApiVersion2RoutePrefixAttribute(string routePrefix ): base (string.IsNullOrWhiteSpace(routePrefix)?RouteBase : PrefixRouteBase + routePrefix)
        {

        }
    }
}