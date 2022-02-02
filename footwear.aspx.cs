using assessment4.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace assessment4
{
    public partial class footwear : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            div1.Visible = false;
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            Session["value"] = txtProductCode.Text;
            Response.Redirect("OrderPage.aspx");
            
        }

       

        protected void btnView_Click(object sender, EventArgs e)
        {
            properties foot = new properties();
            Db_con db = new Db_con();
            foot.Category = DD_Category.SelectedValue;
            DataTable dt = new DataTable();
            dt = db.ViewDb(foot);
            GVProductData.DataSource = dt;
            GVProductData.DataBind();
            div1.Visible = true;
        }
    }
}