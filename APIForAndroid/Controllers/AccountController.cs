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
    public class AccountController : ApiController
    {
        CandybugWinformEntities db = new CandybugWinformEntities();
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

        [HttpPost]
        public string Login([FromBody] Account account)
        {
            Account product = db.Accounts.SingleOrDefault(c => c.UserName == account.UserName && c.PassWord == account.PassWord);
            if (product != null)
            {
                return JsonConvert.SerializeObject("Login Successfull!!");
            }
            return JsonConvert.SerializeObject("Wrong the Username or Password!!");
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