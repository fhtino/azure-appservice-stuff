using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web472
{
    public partial class dumpuserinfo : System.Web.UI.Page
    {
        public string xmsClientPrincialID { get; set; }
        public string xmsClientPrincialIDP { get; set; }
        public string xmsClientPrincial { get; set; }
        public string easyAuthJson2 { get; set; }



        protected void Page_Load(object sender, EventArgs e)
        {
            // Dump claims & user info

            var ci = User.Identity as ClaimsIdentity;
            var rows = new List<string>();
            rows.Add("User: IsAuthenticated = " + ci.IsAuthenticated);
            rows.Add("User: Name = " + ci.Name);
            rows.Add("User: AuthenticationType = " + ci.AuthenticationType);

            rows.Add("");
            rows.Add(ci.NameClaimType);
            rows.Add("");

            if (ci.IsAuthenticated)
            {
                foreach (var c in ci.Claims)
                {
                    rows.Add("Claim: " + c.Type + " = " + c.Value);
                }
            }
            LabelInfo.Text = String.Join("<br/>", rows);

            // Dump some headers
            xmsClientPrincialID = Request.Headers["X-MS-CLIENT-PRINCIPAL-ID"];
            xmsClientPrincialIDP = Request.Headers["X-MS-CLIENT-PRINCIPAL-IDP"];
            xmsClientPrincial = Request.Headers["X-MS-CLIENT-PRINCIPAL"];
            easyAuthJson2 = "";
            if (xmsClientPrincial != null)
            {
                string easyAuthJson = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(xmsClientPrincial));
                easyAuthJson2 = Newtonsoft.Json.Linq.JToken.Parse(easyAuthJson).ToString(Newtonsoft.Json.Formatting.Indented);
            }

        }
    }
}