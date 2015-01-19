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
    public partial class Registration : System.Web.UI.Page
    {
        public static string myStr = string.Empty;
        public void loadCaptcha()
        {
            ImageVerifierSvcRef.ServiceClient fromService = new ImageVerifierSvcRef.ServiceClient();
            string length = 5.ToString();
            myStr = fromService.GetVerifierString(length);
            Session["verifyString"] = myStr;
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
            if (Session["verifyString"].Equals(string.Empty))
            {
                loadCaptcha();
            }
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            try
            {
                LoginRegisterSvcRef.Service1Client client = new LoginRegisterSvcRef.Service1Client();
                EncryptDecryptDLL.Class1 cl = new EncryptDecryptDLL.Class1();
                string encryPassword = cl.encryptMethod(Password.Text);
                string encryConfirmPassword = cl.encryptMethod(ConfirmPassword.Text);
                if (TextBox1.Text.Equals(myStr))
                {
                    string result = client.registerUser(Username.Text, encryPassword, encryConfirmPassword, ZipCode.Text, Email.Text, CellNumber.Text, "Member");
                    if (result.Equals("success"))
                    {
                        Label1.Text = "Registration Successful!";
                        LinkButton1.Visible = true;
                        Label2.Text = " to login and proceed";
                        Username.Text = "";
                        Email.Text = "";
                        ZipCode.Text = "";
                        CellNumber.Text = "";
                        TextBox1.Text = "";
                        loadCaptcha();
                    }
                    else
                    {
                        loadCaptcha();
                        Label1.Text = "Registration Error!";
                        Label2.Text = "Try Again with proper credentials.";
                        Username.Text = "";
                        Email.Text = "";
                        ZipCode.Text = "";
                        CellNumber.Text = "";
                        TextBox1.Text = "";
                    }
                }
                else
                {
                    TextBox1.Text = "";
                    loadCaptcha();
                    Label1.Text = "";
                    LinkButton1.Visible = false;
                    Label2.Text = "Enter Correct Captcha!";
                }
            }
            catch (Exception ex)
            {
                loadCaptcha();
                Label1.Text = "Registration Error!";
                Label2.Text = ex.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            loadCaptcha();
            TextBox1.Text = "";
        }
    }
}