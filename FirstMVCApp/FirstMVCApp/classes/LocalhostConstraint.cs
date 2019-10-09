using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;


namespace FirstMVCApp.classes
    {

    public class LocalhostConstraint : IRouteConstraint
{
    public bool Match(HttpContextBase httpContext, Route route , string paramterName , RouteValueDictionary values , RouteDirection routeDirection)
    {
            // return httpContext.Request.Url.Port==1234;
            return httpContext.Request.IsLocal;
    }

}
}
