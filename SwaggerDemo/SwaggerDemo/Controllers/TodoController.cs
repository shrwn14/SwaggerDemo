using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SwaggerDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private static  List<Todo> Todos = new List<Todo>()
        {
            new Todo { Description =  "Attend Daily Stand-up", DateCreated = DateTime.Now},
            new Todo { Description =  "Call Client", DateCreated = DateTime.Now},
            new Todo { Description =  "Finish assigned task", DateCreated = DateTime.Now},
        };

        private readonly ILogger<TodoController> _logger;

        public TodoController(ILogger<TodoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Todo> Get()
        {
            return Todos.OrderByDescending(x => x.DateCreated);
        }

        [HttpPost]
        public IActionResult Post(string description)
        {
            Todos.Add(new Todo { Description = description, DateCreated = DateTime.Now });
            return Ok();
        }
    }
}
