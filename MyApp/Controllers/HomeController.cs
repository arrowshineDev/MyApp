using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using MyApp.Models;
using System.Net;

namespace MyApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category);
            return View(products.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Shop()
        {

            var products = db.Products.Include(p => p.Category);
            return View(products.ToList());
        }

        public ActionResult SingleProduct(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }


        public ActionResult CheckOut(int? id)
        {
            Product product = db.Products.Find(id);


            return View(product);
        }

        public ActionResult AddOrder(int productId)
        {
            Product product = db.Products.Find(productId);

            Order order = new Order();

            order.OrderTime = DateTime.Now.ToString(yyyy/mm/dd);
            order.ProducId = product.ProductID;

            db.Orders.Add(order);
            db.SaveChanges();

        }
    }
}