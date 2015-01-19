using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DsodAsgmnt5
{
    public partial class CheckoutPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookies = Request.Cookies["details"];
            if (myCookies != null)
            {
                Label1.Text = "Hello, " + myCookies["username"];
                Label2.Text = "Your total order amount is: " + Request.QueryString["total"];
            }
            else
            {
                Response.Redirect("http://webstrar13.fulton.asu.edu/page0/Home.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string tot = Request.QueryString["total"];
            decimal total = Convert.ToDecimal(tot);
            Random orderNo = new Random();
            if ((TextBox1.Text.Equals("")) || (TextBox2.Text.Equals("")) || (TextBox3.Text.Equals("")) || (TextBox4.Text.Equals("")) || (TextBox5.Text.Equals("")) || (TextBox6.Text.Equals("")))
            {
                Label3.Text = "Please fill in all the fields!";
            }
            else
            {

                NewsSvcRef.Service1Client obj = new NewsSvcRef.Service1Client();
                string result = obj.cardVerify(TextBox4.Text, DropDownList1.Text);
                if (result.Equals("Valid Card!"))
                {
                    int orderNum = orderNo.Next(100000, 999999);
                    string date = System.DateTime.Now.ToString();
                    LoginRegisterSvcRef.Service1Client obj1 = new LoginRegisterSvcRef.Service1Client();
                    string r = obj1.addOrder(orderNum, TextBox1.Text, TextBox2.Text, date, total);
                    if (r.Equals("Success"))
                    {
                        Label4.Text = "";
                        Label5.Text = "";
                        Label6.Text = "";
                        Label7.Text = "";
                        Label8.Text = "";
                        Label9.Text = "";
                        Label10.Text = "";
                        Label11.Text = "";
                        TextBox1.Visible = false;
                        TextBox2.Visible = false;
                        TextBox3.Visible = false;
                        TextBox4.Visible = false;
                        TextBox5.Visible = false;
                        TextBox6.Visible = false;
                        DropDownList1.Visible = false;
                        Button2.Visible = false;
                        Label2.Text = "Order placed succesfully! Your Order Number is: " + orderNum.ToString() + ". Thank you!";
                    }
                    else
                    {
                        Label4.Text = "";
                        Label5.Text = "";
                        Label6.Text = "";
                        Label7.Text = "";
                        Label8.Text = "";
                        Label9.Text = "";
                        Label10.Text = "";
                        Label11.Text = "";
                        TextBox1.Visible = false;
                        TextBox2.Visible = false;
                        TextBox3.Visible = false;
                        TextBox4.Visible = false;
                        TextBox5.Visible = false;
                        TextBox6.Visible = false;
                        DropDownList1.Visible = false;
                        Button2.Visible = false;
                        Label2.Text = r;
                    }
                }
                else
                {
                    Label3.Text = result;
                }
            }
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
            catch (Exception ex)
            {
                Label1.Text = "Logout Error!" + ex.ToString();
            }
        }
    }
}