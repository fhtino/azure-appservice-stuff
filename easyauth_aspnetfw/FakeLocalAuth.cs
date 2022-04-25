using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace web472
{

    public class FakeLocalAuth
    {

        private static string EasyAuthCookieName = "AppServiceAuthSession";
        private static string EasyAuthCookieFakeValue = "***fake***";


        public static void SetCookie(HttpContext ctx)
        {
            if (IsActive(ctx))
            {
                ctx.Response.Cookies.Add(new HttpCookie(EasyAuthCookieName, EasyAuthCookieFakeValue));
            }
        }


        public static void InjectIfRequired(HttpContext ctx)
        {
            if (IsActive(ctx))
            {
                if (ctx.Request.Cookies[EasyAuthCookieName]?.Value == EasyAuthCookieFakeValue)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, "LocalDev_name"),
                        new Claim(ClaimTypes.NameIdentifier, "localdev"),
                        new Claim(ClaimTypes.Email, "localdev@dev.localhost"),
                        new Claim(ClaimTypes.Surname, "Developer"),
                        new Claim(ClaimTypes.GivenName, "Local-developer"),
                        new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "Local temp ASP.NET Identity"),
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, "LocalFakeAuthenticator");
                    ctx.User = new ClaimsPrincipal(claimsIdentity);
                }
            }
        }

        public static bool IsActive(HttpContext ctx)
        {
            return ConfigurationManager.AppSettings["FakeAuthenticator"] == "ON" &&
                   (ctx.Request.UserHostAddress == "127.0.0.1" || ctx.Request.UserHostAddress == "::1");
        }

    }

}