using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DsodAsgmnt5
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookies = Request.Cookies["details"];
                if (myCookies != null)
                {
                    if (myCookies["Role"] == "Admin")
                    {
                        Label1.Text = "Hello, " + myCookies["username"];
                    }
                    else
                    {
                        Label1.Text = "You are not authorized to view this page!!";
                        Button2.Visible = false;
                        Button3.Visible = false;
                        Button4.Visible = false;
                        Button5.Visible = false;
                        Button6.Visible = false;
                        ListBox1.Visible = false;
                        ListBox2.Visible = false;
                        ListBox3.Visible = false;
                        TextBox1.Visible = false;
                        TextBox2.Visible = false;
                        TextBox3.Visible = false;
                        TextBox4.Visible = false;
                        DropDownList1.Visible = false;
                        DropDownList2.Visible = false;
                        Label2.Visible = false;
                        Label3.Visible = false;
                        Label4.Visible = false;
                        Label5.Visible = false;
                        Label6.Visible = false;
                        Label7.Visible = false;
                        Label8.Visible = false;
                        Label9.Visible = false;
                        Label10.Visible = false;
                        Label11.Visible = false;
                    }
                }
                else
                {
                    Response.Redirect("http://webstrar13.fulton.asu.edu/page0/AdminLogin.aspx");
                }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.Cookies["details"] != null)
                {
                    Session["verifyAdmin"] = string.Empty;
                    HttpCookie myCookie = new HttpCookie("details");
                    myCookie.Expires = System.DateTime.Now.AddDays(-1d);
                    Response.Cookies.Add(myCookie);
                    Response.Redirect("http://webstrar13.fulton.asu.edu/page0/AdminLogin.aspx");
                }
            }
            catch (Exception ex)
            {
                Label1.Text = "Logout Error!" + ex.ToString();
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
            Label9.Text = "";
            Label10.Text = "";
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
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
            Label9.Text = "";
            Label10.Text = "";
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            LoginRegisterSvcRef.Service1Client obj1 = new LoginRegisterSvcRef.Service1Client();
            String[] result1 = obj1.viewManager();
            ListBox3.Items.Clear();
            foreach (string r1 in result1)
            {
                ListBox3.Items.Add(r1);
            }
            Label9.Text = "";
            Label10.Text = "";
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            LoginRegisterSvcRef.Service1Client obj = new LoginRegisterSvcRef.Service1Client();
            EncryptDecryptDLL.Class1 c = new EncryptDecryptDLL.Class1();
            string encPswd = c.encryptMethod(TextBox2.Text);
            string encCnfrmPswd = c.encryptMethod(TextBox4.Text);
            string result = obj.addUser(TextBox1.Text, encPswd, encCnfrmPswd, DropDownList1.Text);
            Label9.Text = result;
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            Label10.Text = "";
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            LoginRegisterSvcRef.Service1Client obj = new LoginRegisterSvcRef.Service1Client();
            string result = obj.deleteUser(TextBox3.Text, DropDownList2.Text);
                Label10.Text = result;
                Label9.Text = "";
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
        }
    }
}