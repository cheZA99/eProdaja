using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseReadController<T, Tsearch>: ControllerBase where T : class where Tsearch : class
    {
        protected readonly IReadService<T, Tsearch> _service;
        public BaseReadController(IReadService<T, Tsearch> service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual IEnumerable<T> Get([FromQuery]Tsearch search)
        {
            return _service.Get(search);
        }

        [HttpGet(template: "{id}")]
        public virtual T GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}
