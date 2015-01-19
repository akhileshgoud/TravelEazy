using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Web;

namespace DsodAsgmnt5
{
    public partial class ManagerPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookies = Request.Cookies["details"];
                if (myCookies != null)
                {
                    if (myCookies["Role"] == "Manager")
                    {
                        Label1.Text = "Hello, " + myCookies["username"];
                    }
                    else
                    {
                        Label1.Text = "You are not authorized to view this page!!";
                        Button2.Visible = false;
                        Button3.Visible = false;
                        ListBox1.Visible = false;
                        ListBox2.Visible = false;
                    }
                }
                else
                {
                    Response.Redirect("http://webstrar13.fulton.asu.edu/page0/ManagerLogin.aspx");
                }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            LoginRegisterSvcRef.Service1Client obj = new LoginRegisterSvcRef.Service1Client();
            String[] result = obj.viewUser();
            ListBox1.Items.Clear();
            foreach (string r in result)
            {
                ListBox1.Items.Add(r);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.Cookies["details"] != null)
                {
                    Session["verifyManager"] = string.Empty;
                    HttpCookie myCookie = new HttpCookie("details");
                    myCookie.Expires = System.DateTime.Now.AddDays(-1d);
                    Response.Cookies.Add(myCookie);
                    Response.Redirect("http://webstrar13.fulton.asu.edu/page0/ManagerLogin.aspx");
                }
            }
            catch (Exception ex)
            {
                Label1.Text = "Logout Error!" + ex.ToString();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            LoginRegisterSvcRef.Service1Client obj1 = new LoginRegisterSvcRef.Service1Client();
            String[] result1 = obj1.viewStaff();
            ListBox2.Items.Clear();
            foreach (string r1 in result1)
            {
                ListBox2.Items.Add(r1);
            }
        }
    }
}