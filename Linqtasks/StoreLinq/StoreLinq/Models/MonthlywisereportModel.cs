using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreLinq.Models
{
    public class MonthlywisereportModel
    {
        public Customer CustomerName { get; set; }
        public DateTime Date{ get; set; }
        public PurchaseOrder Amount { get; set; }
    }
}