﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EcommerceOsorio.Models;
using EcommerceOsorio.DAL;

namespace EcommerceOsorio.Controllers
{
    [RoutePrefix("api/produtos")]
    public class ValuesController1 : ApiController
    {
        // GET api/produtos/todos
        [Route("Todos")]
        public List<Produto> Get()
        {
            return ProdutoDAO;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}