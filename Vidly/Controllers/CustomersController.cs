using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //Just use one time.
        protected override void Dispose(bool disposing)
        {
           _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customer = _context.Customers.ToList();
            return View(customer);
        }
    }
}