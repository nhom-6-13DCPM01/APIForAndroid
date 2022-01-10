﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIForAndroid.Models;
using Newtonsoft.Json;

namespace APIForAndroid.Controllers
{
    public class OrderController : ApiController
    {
        private CandybugWinformEntities DBCandyBug = new CandybugWinformEntities();
        private int maDonHang;

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

        [Route("getMaxIdOrder")]
        [HttpGet]
        public int GetIdOrder()
        {
            int a = 0;
            var danhSach = DBCandyBug.Oders.ToList();

            foreach (var item in danhSach)
            {
                if (item.Id > a)
                    a = item.Id;
            }

            return a;
        }

        [Route("getTongSoLuongOrderChuaDuyet")]
        [HttpGet]
        public int GetTongSoLuongOrderChuaDuyet()
        {
            int soLuong = DBCandyBug.Oders.Where(h => h.Status.Equals("CHƯA DUYỆT")).Count();
            return soLuong;
        }

        [Route("getOrderInfoList")]
        [HttpGet]
        public void GetOrderInfoList()
        {
            var danhSach = DBCandyBug.OrderInfoes.Select(u => new
            {

            });
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        [Route("createOrder")]
        [HttpPost]
        public IHttpActionResult CreateOrder([FromBody] Oder order)
        {
            if (!order.Equals(null))
            {
                Oder oder = new Oder()
                {
                    IdAcc = order.IdAcc,
                    DateCreate = order.DateCreate,
                    Status = order.Status,
                    DeliveryDate = order.DeliveryDate,
                    Address = order.Address,
                    SDT = order.SDT
                };
                Oder oderFind = DBCandyBug.Oders.Add(oder);
                DBCandyBug.SaveChanges();
                maDonHang = oderFind.Id;
                return Ok(oderFind);
            }
            return null;
        }

        [Route("addOrderInfo")]
        [HttpPost]
        public void addOrderInFo([FromBody] OrderInfo orderInfo)
        {
            OrderInfo order = new OrderInfo()
            {
                IdOrder = maDonHang,
                IdProduct = orderInfo.IdProduct,
                Quantity = orderInfo.Quantity,
                Total = orderInfo.Total
            };
            DBCandyBug.OrderInfoes.Add(orderInfo);
            DBCandyBug.SaveChanges();
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