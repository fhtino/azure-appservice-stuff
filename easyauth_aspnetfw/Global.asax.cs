using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace web472
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            FakeLocalAuth.InjectIfRequired(HttpContext.Current);
        }


        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            FakeRoles.AddRoles(ClaimsPrincipal.Current.Identity as ClaimsIdentity);
        }


        protected void Application_EndRequest(object sender, EventArgs e)
        {
            if (Response.StatusCode == (int)System.Net.HttpStatusCode.Unauthorized)
            {
                Response.Redirect("~/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }
    }
}