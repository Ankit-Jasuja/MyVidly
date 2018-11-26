using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using AutoMapper;
using MyVidly.Dtos;
using MyVidly.Models;

namespace MyVidly.Api
{
    public class CustomersController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Customer> GetCustomers()
        {
           return _context.Customers.ToList();
            //var customerDtoList = Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(customers);
            //return customerDtoList;
        }

        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(z => z.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            var customerDto = Mapper.Map<CustomerDto>(customer);
            return Ok(customerDto);
        }

        [HttpPost]
        public IHttpActionResult Create(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = Mapper.Map<Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);//convention says status 201 is appropriate when new entity is created,with location link
        }

        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            var customerInDb = _context.Customers.SingleOrDefault(z => z.Id == id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            customerDto.Id = customerInDb.Id;
            Mapper.Map(customerDto, customerInDb);
            _context.SaveChanges();
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var customer = _context.Customers.SingleOrDefault(z => z.Id == id);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }


    }
}
