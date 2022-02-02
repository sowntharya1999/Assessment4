using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace assessment4.Models
{
    public class Db_con
    {
        string dbcon = "Data Source=100.72.130.5;Initial Catalog=350559_Dev;User ID=350559;Password=350559";

        public DataTable ViewDb(properties foot)
        {
            SqlConnection con = new SqlConnection(dbcon);
            SqlDataAdapter da = new SqlDataAdapter($"select Product_Code,Name,Cost  from FootWare_Details where Category = '{foot.Category}'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public statusProperties Fetch(properties foot)
        {
            statusProperties status = new statusProperties();
            SqlConnection con = new SqlConnection(dbcon);
            SqlDataAdapter da = new SqlDataAdapter($"select * from Footware_Details where Product_Code = {foot.Product_Code} ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            status.Product_Code = Convert.ToInt32(dt.Rows[0][0]);
            status.Name = dt.Rows[0][1].ToString();
            status.Price = Convert.ToInt32(dt.Rows[0][2]);
            return status;
        }
        public string Payment(statusProperties status)
        {
            SqlConnection con = new SqlConnection(dbcon);
            con.Open();
            SqlCommand cmd = new SqlCommand($"insert into OrderTable values({status.Product_Code},'{status.Name}',{status.Price},{status.Quantity},{status.Total_Amount})", con); ;
            cmd.ExecuteNonQuery();
            con.Close();
            return ("successfully saved");


        }
    }
    }