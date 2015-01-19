using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DsodAsgmnt5
{
    public partial class MyCart : System.Web.UI.Page
    {
        orderItem order;
        private static string city;
        private static double totalprice;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookies = Request.Cookies["details"];
            if (myCookies == null)
            {
                Response.Redirect("http://webstrar13.fulton.asu.edu/page0/Home.aspx");
            }
            else
            {
                Label1.Text = "Hello, " + myCookies["username"];
                city = Request.QueryString["city"];
                int i = 1;
                int count = 0;
                string carid = city + "car";
                totalprice = 0;

                if (Session.Count != 0)
                {
                    while (i <= 10 && count <= Session.Count)
                    {
                        if (Session[city + i.ToString()] != null)
                        {
                            order = (orderItem)Session[city + i.ToString()];
                            string result = "<b>Product ID : </b>" + order._ProductId + "<br>" +
                                            "<b> Product Name: </b>" + order._Name + "<br>" +
                                            "<b> Product Price: </b>" + order._Price.ToString();

                            TableRow trow = new TableRow();
                            trow.BorderStyle = BorderStyle.Solid;
                            Table1.Rows.Add(trow);

                            TableCell tcell1 = new TableCell();
                            tcell1.BorderStyle = BorderStyle.Solid;
                            tcell1.Text = result;
                            trow.Cells.Add(tcell1);

                            Button b = new Button();
                            b.Text = "Delete from Cart";
                            b.ID = "Button" + (i - 1).ToString();
                            b.Click += new EventHandler(Button_Click);
                            TableCell tcell2 = new TableCell();
                            tcell2.BorderStyle = BorderStyle.Solid;
                            tcell2.Controls.Add(b);
                            tcell2.HorizontalAlign = HorizontalAlign.Center;
                            tcell2.VerticalAlign = VerticalAlign.Middle;
                            trow.Cells.Add(tcell2);

                            count++;
                            totalprice = totalprice + order._Price;
                        }
                        i++;
                    }

                    i = 1;

                    while (i <= 10 && count <= Session.Count)
                    {
                        if (Session[carid + i.ToString()] != null)
                        {
                            order = (orderItem)Session[carid + i.ToString()];
                            string result = "<b>Product ID : </b>" + order._ProductId + "<br>" +
                                            "<b> Product Name: </b>" + order._Name + "<br>" +
                                            "<b> Product Price: </b>" + order._Price.ToString();

                            TableRow trow = new TableRow();
                            trow.BorderStyle = BorderStyle.Solid;
                            Table1.Rows.Add(trow);

                            TableCell tcell1 = new TableCell();
                            tcell1.BorderStyle = BorderStyle.Solid;
                            tcell1.Text = result;
                            trow.Cells.Add(tcell1);

                            Button b = new Button();
                            b.Text = "Delete from Cart";
                            b.ID = "CarButton" + (i - 1).ToString();
                            b.Click += new EventHandler(Button_Click);
                            TableCell tcell2 = new TableCell();
                            tcell2.BorderStyle = BorderStyle.Solid;
                            tcell2.Controls.Add(b);
                            tcell2.HorizontalAlign = HorizontalAlign.Center;
                            tcell2.VerticalAlign = VerticalAlign.Middle;
                            trow.Cells.Add(tcell2);

                            count++;
                            totalprice = totalprice + order._Price;
                        }
                        i++;
                    }

                    TableRow trow1 = new TableRow();
                    trow1.BorderStyle = BorderStyle.Solid;
                    Table1.Rows.Add(trow1);

                    TableCell tcell11 = new TableCell();
                    tcell11.BorderStyle = BorderStyle.Solid;
                    tcell11.Text = "<b>Total Price </b>";
                    tcell11.HorizontalAlign = HorizontalAlign.Center;
                    trow1.Cells.Add(tcell11);

                    TableCell tcell21 = new TableCell();
                    tcell21.BorderStyle = BorderStyle.Solid;
                    tcell21.Text = totalprice.ToString();
                    tcell21.HorizontalAlign = HorizontalAlign.Center;
                    trow1.Cells.Add(tcell21);
                }

                if (Session.Count == 0 || totalprice == 0)
                {
                    Label2.Text = "Your shopping cart is empty!";
                    Button11.Enabled = false;
                }
                else {
                    Label2.Text = "";
                    Button11.Enabled = true;
                }                
            }
        }
        void Button_Click(object sender, EventArgs e)
        {
            city = Request.QueryString["city"];
            int id;
            string s;
            string catid;
            Button b = (Button)sender;
            s = b.ID;

            if (s.Length > 8)
            {
                Label1.Text = s;
                id = int.Parse(s[9].ToString());
                catid = city + "car" + (id + 1).ToString();

            }
            else
            {
                id = int.Parse(s[6].ToString());
                catid = city + (id + 1).ToString();
            }

            Session.Remove(catid);
            Response.Redirect(Request.RawUrl);
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://webstrar13.fulton.asu.edu/page0/CheckoutPage.aspx?total=" + totalprice);
        }

        protected void Button25_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.Cookies["details"] != null)
                {
                    HttpCookie myCookie = new HttpCookie("details");
                    myCookie.Expires = System.DateTime.Now.AddDays(-1d);
                    Response.Cookies.Add(myCookie);
                    Response.Redirect("http://webstrar13.fulton.asu.edu/page0/Login.aspx");
                }
            }
            catch (Exception ex)
            {
                Label1.Text = "Logout Error!" + ex.ToString();
            }
        }
    }
}