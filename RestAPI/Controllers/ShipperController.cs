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
    public class ShipperController : ControllerBase
    {
        //api/Shipper/getall
        [HttpGet("getall")]
        public List<Shipper> GetAllShippers()
        {
            List<Shipper> result = null;
            using (NorthwindContext context = new NorthwindContext())
            {
                result = context.Shippers.ToList();
            }
            return result;
        }

        //api/shipper/getbyid/{id}
        [HttpGet("getById/{id}")]
        public Shipper GetShipperById(int id)
        {
            Shipper result = null;
            using (NorthwindContext context = new NorthwindContext())
            {
                result = context.Shippers.Find(id);
            }
            return result;
        }

        //api/Shipper/getbyphone?phone={phone}
        [HttpGet("getbyPhone")]
        public List<Shipper> GetShippersByPhone(string phone)
        {
            List<Shipper> result = null;
            using (NorthwindContext context = new NorthwindContext())
            {
                result = context.Shippers.Where(a => a.Phone==phone).ToList();
            }
            return result;
        }

        /*
        Just felt the delete function wasn't needed, could possibly lead to some errors if shippers is needed elsewhere. 

         api/shipper/delete/{id}
        [HttpDelete("Delete/{id}")]
        public Shipper DeleteById(int id)
        {
            Shipper result = null;
            using (NorthwindContext context = new NorthwindContext())
            {
                result = context.Shippers.Find(id);
                context.Shippers.Remove(result);
                context.SaveChanges();
            }
            return result;
        }*/


        //api/shipper/add?companyname={companyname}&phone={phone}
        [HttpPost("add")]
        public Shipper CreateShipper(string companyName, string phone)
        {
            Shipper newShipper = new Shipper();
            newShipper.CompanyName = companyName;
            newShipper.Phone = phone;
            using (NorthwindContext context = new NorthwindContext())
            {
                context.Shippers.Add(newShipper);
                context.SaveChanges();
            }
            return newShipper;
        }
    }
}
