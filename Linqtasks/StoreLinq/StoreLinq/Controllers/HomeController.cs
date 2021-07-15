using StoreLinq.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreLinq.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListofPurchaseOrder()
        {
            dbStoreLinqEntities sentity = new dbStoreLinqEntities();
            List<Customer> customers = sentity.Customers.ToList();
            List<Product> products = sentity.Products.ToList();
            List<PurchaseOrder> purorder = sentity.PurchaseOrders.ToList();
            List<PurchaseOrderDetail> purorderdetails = sentity.PurchaseOrderDetails.ToList();
            var storeLinqobj = (from prod in products
                                join pod in purorderdetails on prod.ProductID equals pod.ProductID
                                join po in purorder on pod.POID equals po.POID
                                join cust in customers on po.CustomerID equals cust.CustomerID
                                orderby cust.CustomerID
                                select new ListPurchaseModel
                                {
                                    CustomerName = cust,
                                    POID = po,
                                    ProductName = prod,
                                    Price = pod

                                });
            return View(storeLinqobj);

        }

        public ActionResult Monthwisecustomerreport()
        {
            dbStoreLinqEntities sentity = new dbStoreLinqEntities();
            List<Customer> customers = sentity.Customers.ToList();
            List<PurchaseOrder> purorder = sentity.PurchaseOrders.ToList();
            var storeLinqobj = (from cust in customers
                                join po in purorder
                                on cust.CustomerID equals po.CustomerID
                                orderby po.Date.Month
                                select new MonthlywisereportModel
                                {
                                    Date = po.Date,
                                    CustomerName = cust,
                                    Amount = po

                                });
            return View(storeLinqobj);

        }

        public ActionResult ProductsalesreportMonthwise()
        {

            dbStoreLinqEntities sentity = new dbStoreLinqEntities();
            List<Product> products = sentity.Products.ToList();
            List<PurchaseOrder> purorder = sentity.PurchaseOrders.ToList();
            List<PurchaseOrderDetail> purorderdetails = sentity.PurchaseOrderDetails.ToList();
            var storeLinqobj = (from prod in products
                                join pod in purorderdetails on prod.ProductID equals pod.ProductID
                                join po in purorder on pod.POID equals po.POID
                                orderby po.Date.Month
                                select new ProductsalesModel
                                {
                                    Date = po.Date,
                                    ProductName = prod,
                                    Quantity = pod

                                });
            return View(storeLinqobj);
        }

        public ActionResult Maximumorderpriceorder()
        {

            dbStoreLinqEntities sentity = new dbStoreLinqEntities();
            List<Product> products = sentity.Products.ToList();
            List<PurchaseOrder> purorder = sentity.PurchaseOrders.ToList();
            List<PurchaseOrderDetail> purorderdetails = sentity.PurchaseOrderDetails.ToList();
            var storeLinqobj = (from prod in products
                                join pod in purorderdetails on prod.ProductID equals pod.ProductID
                                join po in purorder on pod.POID equals po.POID
                                group new { po, pod } by new { po.Date.Month } into G
                                let firstprodgroup = G.FirstOrDefault()
                                let DOP = firstprodgroup.po
                                let poid = firstprodgroup.pod
                                let maxprice = G.Max(m => m.pod.Price)
                                select new MaximumorderModel
                                {
                                    Date = DOP.Date,
                                    POID = poid,
                                    Price = maxprice
                                });



            return View(storeLinqobj);
        }
    }
}