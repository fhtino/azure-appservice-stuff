using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Web;


namespace web472
{

    public class FakeRoles
    {

        public static void AddRoles(ClaimsIdentity claimsIdentity)
        {
            if (claimsIdentity != null && claimsIdentity.IsAuthenticated)
            {
                string userIDFromAuthProvider = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                // Web.config data example:
                //   google#123567858947674#admins+powerusers
                //   aad#f734hb89sughhsd78we78yg#guests

                var configItems = ConfigurationManager.AppSettings
                                                      .AllKeys
                                                      .Where(key => key.StartsWith("SimpleRoles_"))
                                                      .Select(key => ConfigurationManager.AppSettings[key]);

                foreach (var configItem in configItems)
                {
                    var vect = configItem.Split('#');
                    if (vect[0] == claimsIdentity.AuthenticationType &&
                        vect[1] == userIDFromAuthProvider)
                    {
                        var roles = vect[2].Split('+');
                        foreach (var role in roles)
                        {
                            claimsIdentity.AddClaim(new Claim(claimsIdentity.RoleClaimType, role));
                        }
                    }
                }

            }
        }

    }

}