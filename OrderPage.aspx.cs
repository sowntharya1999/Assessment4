using assessment4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace assessment4
{
    public partial class OrderPage : System.Web.UI.Page
    {
        properties propObj = new properties(); 
        statusProperties status= new statusProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            Db_con con = new Db_con();

            if (!IsPostBack)
            {
                lblProductCode.Text = "" + Session["value"];
                propObj.Product_Code = Convert.ToInt32(Session["value"]);
                statusProperties status = con.Fetch(propObj);

                lblProductName.Text = status.Name;
                lblPrice.Text = status.Price.ToString();
            }
        }

        protected void btnBill_Click(object sender, EventArgs e)
        {
            Db_con con = new Db_con();
            propObj.Product_Code = Convert.ToInt32(Session["value"]);

            statusProperties status = con.Fetch(propObj);
            int Quantity = Convert.ToInt32(txtQuantity.Text);
            lblTotalAmount.Text = Convert.ToString(status.Price * Quantity);

        }

        protected void btnPayment_Click(object sender, EventArgs e)
        {
            Db_con con = new Db_con();
            statusProperties op = new statusProperties();
            op.Product_Code = Convert.ToInt32(lblProductCode.Text);
            op.Name = lblProductName.Text;
            op.Price = Convert.ToInt32(lblPrice.Text);
            op.Quantity = Convert.ToInt32(txtQuantity.Text);
            op.Total_Amount = Convert.ToInt32(lblTotalAmount.Text);
            string msg = con.Payment(op);
            Response.Write($"<script>alert('{msg}')</script>");

        }
    }
}