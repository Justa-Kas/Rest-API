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
    public class CustomerAndSuppliersByCityController : ControllerBase
    {
        //api/CustomerAndSuppliersByCity/getall
        [HttpGet("getall")]
        public List<CustomerAndSuppliersByCity> GetAll()
        {
            List<CustomerAndSuppliersByCity> result = null;
            using (NorthwindContext context = new NorthwindContext())
            {
                result = context.CustomerAndSuppliersByCities.ToList();
            }
            return result;
        }

        //api/CustomerAndSuppliersByCity/getbycompanyname?companyname={companyname}
        [HttpGet("getbycompanyname")]
        public List<CustomerAndSuppliersByCity> GetCaSByCompanyName(string companyName)
        {
            List<CustomerAndSuppliersByCity> result = null;
            using (NorthwindContext context = new NorthwindContext())
            {
                result = context.CustomerAndSuppliersByCities.Where(a => a.CompanyName.ToLower() == companyName.ToLower()).ToList();
            }
            return result;
        }

        //api/CustomerAndSuppliersByCity/getbycity/{companyname}
        [HttpGet("getbycity/{city}")]
        public List<CustomerAndSuppliersByCity> GetByCity(string city)
        {
            List<CustomerAndSuppliersByCity> result = null;
            using (NorthwindContext context = new NorthwindContext())
            {
                result = context.CustomerAndSuppliersByCities.Where(a => a.City.ToLower() == city.ToLower()).ToList();
            }
            return result;
        }
    }
}
