using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIForAndroid.Controllers
{
    public class OrderController : ApiController
    {
        private CandybugWinformEntities DBCandyBug = new CandybugWinformEntities();
        private int maDonHang = 0;

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        [Route("getOrderInfoList")]
        [HttpGet]
        public void GetOrderInfoList()
        {

        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        [Route("createOrder")]
        [HttpPost]
        public String CreateOrder([FromBody] Oder order)
        {
            if (!order.Equals(null))
            {
                Oder oder = new Oder()
                {
                    IdAcc = order.IdAcc,
                    DateCreate = DateTime.Now,
                    Status = order.Status,
                    DeliveryDate = null,
                    Address = order.Address,
                    SDT = order.SDT
                };
                Oder oderFind = DBCandyBug.Oders.Add(oder);
                DBCandyBug.SaveChanges();
                maDonHang = oderFind.Id;
                return JsonConvert.SerializeObject("Bạn đã có hóa đơn của mình");
            }
            return JsonConvert.SerializeObject("Xin lỗi bạn có thể báo cáo lỗi với bên mình để chúng mình khắc phục");
        }

        [Route("addOrderInfo")]
        [HttpPost]
        public void addOrderInFo([FromBody] OrderInfo orderInfo)
        {

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