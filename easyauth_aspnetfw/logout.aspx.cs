using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web472
{
    public partial class logout : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            // Note: Response.Cookies.Remove does not cancel the cookie on the client. 
            //       Unfortunately Asp.net framework does not have .net core Response.Cookies.Delete
            //       Solution: set an empty cookie, already expired.

            Response.Cookies.Add(
                new HttpCookie("AppServiceAuthSession")
                {
                    Value = "",
                    Expires = DateTime.UtcNow.AddDays(-1)
                });

            Response.Redirect("~/");
        }

    }
}