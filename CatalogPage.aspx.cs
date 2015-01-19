using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DsodAsgmnt5
{
    public partial class CatalogPage : System.Web.UI.Page
    {
        private static string[] result;
        private static string city;
        private static string carid;
        orderItem order;
        //string updated = "";
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
                ServiceReference1.CatalogService1Client client = new ServiceReference1.CatalogService1Client();
                city = Request.QueryString["city"];
                carid = city + "car";

                result = client.GetHotelDeals(city);

                for (int i = 0; i < result.Count(); i++)
                {
                    string[] delim = result[i].Split(';');
                    string res = "<b> Package " + (i + 1).ToString() + "</b> <br> <br>" + "<b> Night Duration: </b>" + delim[0] + "<br>" +
                            "<b> Start Date: </b>" + delim[1] + "<br>" +
                            "<b> End Date: </b>" + delim[2] + "<br>" +
                            "<b> Description: </b>" + delim[3] + "<br>" +
                            "<b> Price per night: </b>" + delim[4] + "<br>" +
                            "<b> City: </b>" + delim[5];

                    TableRow trow = new TableRow();
                    trow.BorderStyle = BorderStyle.Solid;
                    Table1.Rows.Add(trow);

                    TableCell tcell1 = new TableCell();
                    tcell1.BorderStyle = BorderStyle.Solid;
                    tcell1.Text = res;
                    trow.Cells.Add(tcell1);

                    Button b = new Button();
                    b.Text = "Add To Cart";
                    b.ID = "Button" + i.ToString();
                    b.Click += new EventHandler(Button_Click);
                    TableCell tcell2 = new TableCell();
                    tcell2.BorderStyle = BorderStyle.Solid;
                    tcell2.Controls.Add(b);
                    tcell2.HorizontalAlign = HorizontalAlign.Center;
                    tcell2.VerticalAlign = VerticalAlign.Middle;
                    trow.Cells.Add(tcell2);
                }

                int j = 1;
                int count = 0;
                if (Session.Count != 0)
                {
                    while (j <= 10 && count <= Session.Count)
                    {
                        if (Session[city + j.ToString()] != null)
                        {
                            order = (orderItem)Session[city + j.ToString()];
                            viewcart1.updatecart(order._Name, order._ProductId, order._Price);
                            count++;
                        }
                        j++;
                    }

                    j = 1;

                    while (j <= 10 && count <= Session.Count)
                    {
                        if (Session[carid + j.ToString()] != null)
                        {
                            order = (orderItem)Session[carid + j.ToString()];
                            viewcart1.updatecart(order._Name, order._ProductId, order._Price);
                            count++;
                        }
                        j++;
                    }
                }
            }
        }

        void Button_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                string s;
                Button b = (Button)sender;
                s = b.ID;
                id = int.Parse(s[6].ToString());
                string name = "Package" + (id + 1).ToString();
                string prodid = city + (id + 1).ToString();

                if (Session[prodid] == null)
                {
                    string[] delim = result[id].Split(';');
                    double price = Convert.ToDouble(delim[0]) * Convert.ToDouble(delim[4]);

                    orderItem order = new orderItem(name, prodid, price);
                    Session[prodid] = order;
                   // orderItem order1 = (orderItem)Session[prodid];
                   // updated = order1._Name;
                    viewcart1.updatecart(name, prodid, price);
                }
                else
                {
                    Label2.Text = "Sorry you cannot add the same package again!";
                }
            }
            catch(Exception ex)
            {
                Label2.Text = "Error! " + ex.ToString();
            }
        }

        protected void Logout_Click(object sender, EventArgs e)
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

        protected void Cart_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://webstrar13.fulton.asu.edu/page0/MyCart.aspx?city=" + city);
        }

        protected void CarDeals_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text.Equals("") || TextBox2.Text.Equals("") || TextBox3.Text.Equals("") || TextBox4.Text.Equals(""))
            {
                Label3.Text = "Please enter all the details to get the deals!";
            }
            else
            {
                Response.Redirect("http://webstrar13.fulton.asu.edu/page0/CarDeals.aspx?city=" + city + "&start=" + TextBox1.Text + "&end=" + TextBox2.Text + "&pick=" + TextBox3.Text + "&drop=" + TextBox4.Text);
            }
        }
    }

    public class orderItem
    {
        public string _Name;
        public string _ProductId;
        public double _Price;
        public orderItem(string name, string productid, double price)
        {
            _Name = name;
            _ProductId = productid;
            _Price = price;
        }

    }
}