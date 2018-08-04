using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Vidly.Models;
using System.Web.Http;

namespace Vidly.Controllers.ApiController
{
    public class CustomerController : System.Web.Http.ApiController
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        //get api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        //get api/customers/1
        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }


        //add api/customer
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        //put apt/customer/1
        [HttpPut]
        public void PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(customerInDb==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            customerInDb.Name = customer.Name;
            customerInDb.BirthDay = customer.BirthDay;
            customerInDb.IsSuprierToNewLetter = customer.IsSuprierToNewLetter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();
        }

        //delete api/customer/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDb);

            _context.SaveChanges();
        }
    }
}
