using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserControl
{
    public partial class ViewCart : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void updatecart(string name, string prodid, double price)
        {
            TableRow trow1 = new TableRow();
            Table1.Rows.Add(trow1);
            TableCell tcell11 = new TableCell();
            tcell11.Text = name;
            trow1.Cells.Add(tcell11);
            TableCell tcell21 = new TableCell();
            tcell21.Text = prodid;
            trow1.Cells.Add(tcell21);
            TableCell tcell31 = new TableCell();
            tcell31.Text = price.ToString();
            trow1.Cells.Add(tcell31);
        }
    }
}