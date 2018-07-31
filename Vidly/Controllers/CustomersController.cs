using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

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

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customer = _context.Customers.Include(m=>m.MembershipType).ToList();
            return View(customer);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(m => m.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        public ActionResult Create(Customer customer)
        {
            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer
            };
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers", viewModel);
        }
    }
}