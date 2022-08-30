using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using statistique.Interfaces;
using statistique.Services;
using statistique.Services.RabbitMQ;
using statistique2.DBConnextion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using WebApplication2.DTO;
using WebApplication2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace statistique.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FamousController : ControllerBase
    {
        private readonly IFamousViewService _famousViewService ;
           
        public FamousController( IFamousViewService famousViewService)
        {
            this._famousViewService = famousViewService;
        }
        [HttpGet("all")]
        public IEnumerable<FamousView> Get()
        {
            return _famousViewService.GetAllFamous(); 
        }

        // GET api/<ValuesController>/5
        // POST api/<ValuesController>
        [HttpPost("createFamous")]
        public string  createFamous([FromBody] FamousView Famous)
        {
            Famous.Id = Guid.NewGuid();
            return _famousViewService.SaveFamous(Famous);
        }    

        // PUT 
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            using (var context = new AppDbContext())
            {

            }

            // DELETE api/<ValuesController>/5
         
        }
    }
}
