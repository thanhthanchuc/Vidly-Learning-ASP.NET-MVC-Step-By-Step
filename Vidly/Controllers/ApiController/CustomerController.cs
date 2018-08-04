using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Vidly.Models;
using System.Web.Http;
using AutoMapper;
using Vidly.DTO;

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
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }

        //get api/customers/1
        public CustomerDto GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Customer, CustomerDto>(customer);
        }


        //add api/customer
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return customerDto;
        }

        //put apt/customer/1
        [HttpPut]
        public void PutCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(customerInDb==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerInDb);

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
