using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace DsodAsgmnt5
{
    public partial class ManagerLogin : System.Web.UI.Page
    {
        public static string myStr = string.Empty;
        public void loadCaptcha()
        {
            ImageVerifierSvcRef.ServiceClient fromService = new ImageVerifierSvcRef.ServiceClient();
            string length = 5.ToString();
            myStr = fromService.GetVerifierString(length);
            Session["verifyManager"] = myStr;
            Image1.Visible = true;
            Stream myStream = fromService.GetImage(myStr);
            MemoryStream memStr = new MemoryStream();
            myStream.CopyTo(memStr);
            BinaryReader br = new BinaryReader(myStream);
            byte[] bytes = memStr.ToArray();
            string bs = Convert.ToBase64String(bytes, 0, bytes.Length);
            Image1.ImageUrl = "data:image/png;base64," + bs;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookies = Request.Cookies["details"];
            if (myCookies != null)
            {
                Response.Redirect("http://webstrar13.fulton.asu.edu/page0/Home.aspx");
            }
            if (Session["verifyManager"].Equals(string.Empty))
            {
                loadCaptcha();
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                LoginRegisterSvcRef.Service1Client client = new LoginRegisterSvcRef.Service1Client();
                EncryptDecryptDLL.Class1 c = new EncryptDecryptDLL.Class1();
                string encPswd = c.encryptMethod(Password.Text);
                if (TextBox1.Text.Equals(myStr))
                {
                    bool result = client.login(Username.Text, encPswd, "Manager");
                    if (result)
                    {
                        HttpCookie usercookie = new HttpCookie("details");
                        usercookie["username"] = Username.Text;
                        usercookie["Role"] = "Manager";
                        usercookie.Expires = System.DateTime.Now.AddDays(30);
                        Response.Cookies.Add(usercookie);
                        //Response.Redirect("Home.aspx");
                        Response.Redirect("http://webstrar13.fulton.asu.edu/page0/ManagerPage.aspx");
                    }
                    else
                    {
                        Label1.Text = "Login failed!";
                        Label2.Text = "Username or Password Incorrect.";
                        loadCaptcha();
                        TextBox1.Text = "";
                    }
                }
                else
                {
                    TextBox1.Text = "";
                    loadCaptcha();
                    Label1.Text = "";
                    Label2.Text = "Enter Correct Captcha!";
                }
            }
            catch (Exception ex)
            {
                loadCaptcha();
                Label1.Text = "Error!" + ex.ToString();
                Label2.Text = "";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            loadCaptcha();
            TextBox1.Text = "";
            Label1.Text = "";
            Label2.Text = "";
        }
    }
}