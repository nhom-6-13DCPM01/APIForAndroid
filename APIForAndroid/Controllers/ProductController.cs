using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIForAndroid.Models;
using Newtonsoft.Json;

namespace APIForAndroid.Controllers
{
    public class ProductController : ApiController
    {
        CandybugWinformEntities db = new CandybugWinformEntities();
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            var list = (from c in db.Products
                        select new
                        {
                            Id = c.Id,
                            Name = c.Name,
                            Category = c.Category.Name,
                            Price = c.Price,
                            Producer = c.Producer.Name,
                            Quantity = c.Quantity,
                            Discount = c.Discount,
                            Image = "http://ushop.somee.com/Content/Client/img/" + c.Image
                        }).ToList();
            return Ok(list);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
           var product = (from c in db.Products
                            where c.Id == id
                            select new
                            {
                                Id = c.Id,
                                Name = c.Name,
                                Category = c.Category.Name,
                                Price = c.Price,
                                Producer = c.Producer.Name,
                                Quantity = c.Quantity,
                                Discount = c.Discount,
                                Image = "http://ushop.somee.com/Content/Client/img/" + c.Image
                            });
            return Ok(product);
        }

        [HttpPost]
        public string Post([FromBody] Account account)
        {
            Account product = db.Accounts.SingleOrDefault(c => c.UserName == account.UserName && c.PassWord == account.PassWord);
            if (product != null)
            {
                return JsonConvert.SerializeObject("Login Successfull!!");
            }
            return JsonConvert.SerializeObject("Wrong!!");
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}