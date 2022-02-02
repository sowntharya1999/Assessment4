using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace assessment4.Models
{
    public class statusProperties
    {
        public int Order_Id { get; set; }
        public int Product_Code { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Total_Amount { get; set; }
    }
}