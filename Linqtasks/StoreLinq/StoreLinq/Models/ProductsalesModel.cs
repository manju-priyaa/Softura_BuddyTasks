using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreLinq.Models
{
    public class ProductsalesModel
    {
        public DateTime Date { get; set; }
        public Product ProductName { get; set; }
        public PurchaseOrderDetail Quantity { get; set; }
    }
}