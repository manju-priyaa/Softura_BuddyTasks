using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreLinq.Models
{
    public class MaximumorderModel
    {
        public DateTime Date { get; set; }
        public PurchaseOrderDetail POID { get; set; }
        public decimal? Price { get; set; }
    }
}