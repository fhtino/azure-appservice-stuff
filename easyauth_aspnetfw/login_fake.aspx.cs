using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web472
{
    public partial class login_fake : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FakeLocalAuth.SetCookie(HttpContext.Current);

            string url = Request["post_login_redirect_url"];
            if (String.IsNullOrEmpty(url)) url = "/";
            Response.Redirect(url);
        }

    }
}