using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        //api/customer/getAll
        [HttpGet("getAll")]
        public List<Customer> GetAllCustomers()
        {
            List<Customer> result = null;
            using(NorthwindContext context = new NorthwindContext())
            {
                result = context.Customers.ToList();
            }
            return result;
        }
        //api/customer/getById/
        [HttpGet("getById/{id}")]
        public Customer GetCustomerById(string id)
        {
            Customer result = null;
            using (NorthwindContext context = new NorthwindContext())
            {
                result = context.Customers.Find(id);
            }
            return result;
        }

        //api/customer/Add?CustomerId=BBNOS&CompanyName=Great Music&ContactName=BBNO$&ContactTitle=Musician&Address=Who knows&City=Who knows&Region=Who Knows&PostalCode=99999&Country=US&Phone=999-999-9999&Fax=null
        [HttpPost("Add")]
        public Customer CreateCustomer(string customerId, string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax)
        {
            Customer newCustomer = new Customer();
            newCustomer.CustomerId = customerId;
            newCustomer.CompanyName = companyName;
            newCustomer.ContactName = contactName;
            newCustomer.ContactTitle = contactTitle;
            newCustomer.Address = address;
            newCustomer.City = city;
            newCustomer.Region = region;
            newCustomer.PostalCode = postalCode;
            newCustomer.Country = country;
            newCustomer.Phone = phone;
            newCustomer.Fax = fax;

            using(NorthwindContext context = new NorthwindContext())
            {
                context.Customers.Add(newCustomer);
                context.SaveChanges();
            }
            return newCustomer;
        }

        [HttpDelete("Delete/{id}")]
        public Customer DeleteById(string id)
        {
            Customer result = null;
            using(NorthwindContext context = new NorthwindContext())
            {
                result = context.Customers.Find(id);
                context.Customers.Remove(result);
                context.SaveChanges();
            }
            return result;
        }
    }
}
