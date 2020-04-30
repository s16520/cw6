using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using cw6.Models;

namespace cw6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        
        [HttpGet]
        public IActionResult GetStudents()
        {
            var list = new List<Student>()
            {
                new Student{Index="s11", FirstName="Jan", LastName="Kowalski"},
                new Student{Index="2", FirstName="Andrzej", LastName="Malewicz"},
                new Student{Index="ss3", FirstName="Krzysztof", LastName="Andrzejewicz"}

            };

            return Ok(list);
        }

    }
}