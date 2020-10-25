using Newtonsoft.Json;
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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer cus)
        {
            if (cus != null && cus.CustomerID != null && cus.CompanyName != null)
            {
                db.Customers.Add(cus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        public ActionResult Edit(string ID)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                var cusData = (from q in db.Customers
                               where q.CustomerID == ID
                               select q).FirstOrDefault();
                return View(cusData);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(Customer cus)
        {
            if (cus != null)
            {
                var cusData = (from q in db.Customers
                               where q.CustomerID == cus.CustomerID
                               select q).FirstOrDefault();

                if (cusData != null)
                {
                    cusData.CompanyName = cus.CompanyName;
                    cusData.ContactName = cus.ContactName;
                    cusData.ContactTitle = cus.ContactTitle;
                    cusData.Address = cus.Address;
                    cusData.City = cus.City;
                    cusData.Phone = cus.Phone;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }

            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public string Delete(string ID)
        {
            string MSG = "";
            List<dynamic> jList = new List<dynamic>();
            if (!string.IsNullOrEmpty(ID))
            {                
                try
                {
                    var cusData = (from q in db.Customers
                                   where q.CustomerID == ID
                                   select q).FirstOrDefault();
                    if(cusData!= null)
                    {
                        db.Customers.Remove(cusData);
                        db.SaveChanges();
                    }
                    else
                    {
                        MSG = JsonConvert.SerializeObject("NoData");
                    }
                }
                catch
                {
                    MSG = JsonConvert.SerializeObject("Fail");
                }
                if(MSG == JsonConvert.SerializeObject("Fail"))
                {
                    return MSG;
                }
                else
                {
                    var cusData = from q in db.Customers
                                  select q;
                    foreach(var item in cusData)
                    {
                        jList.Add(item);
                    }
                    string jsCusData = JsonConvert.SerializeObject(jList);
                    return jsCusData;
                }
            }
            else
            {
                MSG = JsonConvert.SerializeObject("NoData");
                return MSG;
            }
        }
    }
}