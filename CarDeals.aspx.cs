using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DsodAsgmnt5
{
    public partial class CarDeals : System.Web.UI.Page
    {
        string[] result;
        string updated = "";
        private static string city;
        orderItem order;
        private static string carid;
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
                carid = city + "car";
                String start = Request.QueryString["start"];
                String end = Request.QueryString["end"];
                String pick = Request.QueryString["pick"];
                String drop = Request.QueryString["drop"];

                ServiceReference1.CatalogService1Client client = new ServiceReference1.CatalogService1Client();

                result = client.GetCarDeals(city, start, end, pick, drop);

                for (int i = 0; (i < 11) || (i < result.Count()); i++)
                {
                    string[] delim = result[i].Split(';');
                    string res = "<b> Deal " + (i + 1).ToString() + "</b> <br> <br>" + "<b> Car Type Code: </b>" + delim[0] + "<br>" +
                            "<b> Daily Rate: </b>" + delim[1] + "<br>" +
                            "<b> Pick Up Code: </b>" + delim[2] + "<br>" +
                            "<b> Rental Days: </b>" + delim[3] + "<br>" +
                            "<b> Sub Total: </b>" + delim[5] + "<br>" +
                            "<b> Taxes and Fares: </b>" + delim[6] + "<br>" +
                            "<b> Total Price: </b>" + delim[7];

                    TableRow trow = new TableRow();
                    trow.BorderStyle = BorderStyle.Solid;
                    Table1.Rows.Add(trow);

                    TableCell tcell1 = new TableCell();
                    tcell1.BorderStyle = BorderStyle.Solid;
                    tcell1.Text = res;
                    trow.Cells.Add(tcell1);

                    Button b = new Button();
                    b.Text = "Add To Cart";
                    b.ID = "But" + i.ToString();
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
            int id;
            string s;
            Button b = (Button)sender;
            s = b.ID;
            id = int.Parse(s[3].ToString());
            string name = "Deal" + (id + 1).ToString();
            string prodid = city + "car" + (id + 1).ToString();

            if (Session[prodid] == null)
            {
                string[] delim = result[id].Split(';');
                double price = Convert.ToDouble(delim[7]);

                orderItem order = new orderItem(name, prodid, price);
                Session[prodid] = order;
                orderItem order1 = (orderItem)Session[prodid];
                updated = order1._Name;
                viewcart1.updatecart(name, prodid, price);
            }
            else
            {
                Label2.Text = "Sorry you cannot add the same package again!";
            }

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("http://webstrar13.fulton.asu.edu/page0/MyCart.aspx?city=" + city);
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