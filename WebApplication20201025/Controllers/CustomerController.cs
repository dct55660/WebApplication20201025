using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication20201025.Models;

namespace WebApplication20201025.Controllers
{
    public class CustomerController : Controller
    {
        NorthwindEntities1 db = new NorthwindEntities1();
        // GET: Customer
        public ActionResult Index()
        {
            IQueryable<Customer> cusData = from q in db.Customers
                          select q;
            return View(cusData);
        }
    }
}