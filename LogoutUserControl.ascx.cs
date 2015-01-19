using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace DsodAsgmnt5
{
    public partial class LogoutUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.Cookies["details"] != null)
                {
                    HttpCookie myCookie = new HttpCookie("details");
                    myCookie.Expires = System.DateTime.Now.AddDays(-1d);
                    Response.Cookies.Add(myCookie);
                    Response.Redirect("http://webstrar13.fulton.asu.edu/page0/Home.aspx");
                }
            }
            catch
            {
                Response.Redirect("http://webstrar13.fulton.asu.edu/page0/ErrorPage.aspx");
            }
        }
    }
}