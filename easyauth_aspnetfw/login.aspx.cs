using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web472
{
    public partial class login : System.Web.UI.Page
    {

        public string ReturnURL { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ReturnURL = Server.UrlEncode(Request["returnurl"]);
            if (String.IsNullOrEmpty(ReturnURL))
                ReturnURL = "/";
        }

    }
}