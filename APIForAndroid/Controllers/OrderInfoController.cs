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
    public class OrderInfoController : ApiController
    {
        private CandybugWinformEntities DBCandyBug = new CandybugWinformEntities();

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var danhSach = (from u in DBCandyBug.OrderInfoes
                            where u.IdOrder == id
                            select new
                            {
                                IdOrder = u.IdOrder,
                                NameProduct = u.Product.Name,
                                Quantity = u.Quantity,
                                Total = u.Total
                            }).ToList();
            return Ok(danhSach);
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        [Route("addOrderInfo")]
        [HttpPost]
        public String addOrderInfo([FromBody] OrderInfo orderInfo)
        {
            OrderInfo orderAdd = new OrderInfo()
            {
                IdOrder = orderInfo.IdOrder,
                IdProduct = orderInfo.IdProduct,
                Quantity = orderInfo.Quantity,
                Total = orderInfo.Total
            };

            DBCandyBug.OrderInfoes.Add(orderAdd);
            DBCandyBug.SaveChanges();
            return "Xin cảm ơn bạn đã ủng hộ";
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public void Delete(int id)
        {

        }
    }
}