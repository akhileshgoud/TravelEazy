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
    public partial class StaffPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookies = Request.Cookies["details"];
            if (myCookies != null)
            {
                if ((myCookies["Role"] == "Staff") || myCookies["Role"] == "Manager")
                {
                    Label1.Text = "Hello, " + myCookies["username"];
                }
                else
                {
                    Label1.Text = "You are not authorized to view this page!!";
                    Button2.Visible = false;
                    ListBox1.Visible = false;
                }
            }
            else
            {
                Response.Redirect("http://webstrar13.fulton.asu.edu/page0/StaffLogin.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.Cookies["details"] != null)
                {
                    Session["verifyStaff"] = string.Empty;
                    HttpCookie myCookie = new HttpCookie("details");
                    myCookie.Expires = System.DateTime.Now.AddDays(-1d);
                    Response.Cookies.Add(myCookie);
                    Response.Redirect("http://webstrar13.fulton.asu.edu/page0/StaffLogin.aspx");
                }
            }
            catch (Exception ex)
            {
                Label1.Text = "Logout Error!" + ex.ToString();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                LoginRegisterSvcRef.Service1Client obj = new LoginRegisterSvcRef.Service1Client();
                String[] result = obj.viewOrders();
                ListBox1.Items.Clear();
                foreach (string r in result)
                {
                    ListBox1.Items.Add(r);
                }
            }
            catch (Exception ex)
            {
                ListBox1.Items.Clear();
                ListBox1.Items.Add("Error!" + ex.ToString());
            }
        }
    }
}