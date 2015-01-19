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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["verifyStr"] = string.Empty;
            Session["verifyString"] = string.Empty;
            Session["verifyStaff"] = string.Empty;
            Session["verifyManager"] = string.Empty;
            Session["verifyAdmin"] = string.Empty;
            HttpCookie myCookies = Request.Cookies["details"];
            if ((myCookies == null) || (myCookies["username"] == ""))
            {
                Label1.Text = "User";
                Button6.Visible = false;
            }
            else
            {
                Label1.Text = myCookies["username"];
                Button1.Visible = false;
                Button2.Visible = false;
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == string.Empty)
            {
                Label5.Text = "Please enter a place name!";
                Label2.Text = "";
                Label3.Text = "";
                Label4.Text = "";
                Label6.Text = "";
                Label7.Text = "";
                Label8.Text = "";
                Label9.Text = "";
                Label10.Text = "";
                ListBox1.Visible = false;
                ListBox2.Visible = false;
            }
            else
            {
                string city = TextBox1.Text;

                CityToZipSvcRef.Service1Client obj = new CityToZipSvcRef.Service1Client();
                string zip = obj.CityToZip(city);
                // Label1.Text = zip;

                WeatherSvcRef.WeatherServ1Client obj1 = new WeatherSvcRef.WeatherServ1Client();
                Label5.Text = "Weather For next 5 days: ";
                string[] days = obj1.Weather5day(zip);
                ListBox2.Visible = true;
                ListBox2.Items.Clear();
                foreach (string day in days)
                {
                    ListBox2.Items.Add(day);
                }

                NewsSvcRef.Service1Client obj2 = new NewsSvcRef.Service1Client();
                Label6.Text = "Latest News URLs: ";
                string[] urls = obj2.NewsFocus(city);
                ListBox1.Visible = true;
                ListBox1.Items.Clear();
                foreach (string url in urls)
                {
                    ListBox1.Items.Add(url);
                }

                Uri baseUri = new Uri("http://webstrar13.fulton.asu.edu/page5/ConvService.svc/");
                UriTemplate myTemplate = new UriTemplate("zip2lat?zipcode={zipcode}");
                Uri completeUri = myTemplate.BindByPosition(baseUri, zip);
                WebClient proxy = new WebClient();
                byte[] abc = proxy.DownloadData(completeUri);
                Stream strm = new MemoryStream(abc);
                DataContractSerializer obje = new DataContractSerializer(typeof(string));
                string result = obje.ReadObject(strm).ToString();
                string[] latlong = result.Split(',');
                decimal lat = Convert.ToDecimal(latlong[0]);
                decimal lng = Convert.ToDecimal(latlong[1]);

                NatHazSvcRef.NatHazService1Client obj3 = new NatHazSvcRef.NatHazService1Client();
                Label7.Text = "Number of Natural Hazards in the past: ";
                Label2.Text = obj3.NaturalHazards(lat, lng).ToString();

                SolarWindSvcRef.Service1Client obj4 = new SolarWindSvcRef.Service1Client();
                Label8.Text = "Solar and Wind Intensity: ";
                Label3.Text = obj4.getSolarEnergy(lat, lng).ToString();
                Label9.Text = "kWh/m2/day";
                Label4.Text = obj4.getWindEnergy(lat, lng).ToString();
                Label10.Text = "m/s";

                HttpCookie myCookies = Request.Cookies["details"];
                if (myCookies == null)
                {
                    Label11.Text = "Login or register to find latest travel packages available for this place!";
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://webstrar13.fulton.asu.edu/page0/servicedirectory.html");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("http://webstrar13.fulton.asu.edu/page0/Login.aspx");
            }
            catch (Exception exe)
            {
                Label1.Text = "Login Error!" + exe.ToString();
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.Cookies["details"] != null)
                {
                    Session["verifyStr"] = string.Empty;
                    Session["verifyString"] = string.Empty;
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("http://webstrar13.fulton.asu.edu/page0/Registration.aspx");
            }
            catch (Exception exe)
            {
                Label1.Text = "Register Error!" + exe.ToString();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == string.Empty)
            {
                Label5.Text = "Please enter a place name!";
                Label2.Text = "";
                Label3.Text = "";
                Label4.Text = "";
                Label6.Text = "";
                Label7.Text = "";
                Label8.Text = "";
                Label9.Text = "";
                Label10.Text = "";
                Label11.Text = "";
                ListBox1.Visible = false;
                ListBox2.Visible = false;
            }
            else
            {
                HttpCookie myCookies = Request.Cookies["details"];
                if (myCookies != null)
                {
                    Response.Redirect("http://webstrar13.fulton.asu.edu/page0/CatalogPage.aspx?city=" + TextBox1.Text);
                }
                else
                {
                    Label5.Text = "Please Login or register to check the Latest deals for travel packages!";
                    Label2.Text = "";
                    Label3.Text = "";
                    Label4.Text = "";
                    Label6.Text = "";
                    Label7.Text = "";
                    Label8.Text = "";
                    Label9.Text = "";
                    Label10.Text = "";
                    Label11.Text = "";
                    ListBox1.Visible = false;
                    ListBox2.Visible = false;
                }
            }
        }
    }
}