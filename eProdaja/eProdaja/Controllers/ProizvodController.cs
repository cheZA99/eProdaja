using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Controllers
{
    [ApiController]//meta atribut od .NET-a, koji govori serveru da ova klasa moze da uroavlja requestovima
    [Route("[controller]")]//na koji nacin cemo izvrisiti neku metodu, tj ruta
    public class ProizvodController : ControllerBase
    {
        //paziti da interface bude public
        public IProizvodService _proizvodService { get; set; }
        
        public ProizvodController(IProizvodService proizvodService)
        {
            //ovde dobije konkretnu instancu (addtransient)
            _proizvodService = proizvodService;
        }

        [HttpGet]
        public IEnumerable<Proizvod> Get()
        {
            return _proizvodService.Get();
        }

        [HttpGet(template: "{id}")]
        public Proizvod GetById(int id)
        {
            return _proizvodService.GetById(id);
        }

        [HttpPost]
        public Proizvod Insert(Proizvod proizvod)
        {
            return _proizvodService.Insert(proizvod);
        }

        [HttpPut(template: "{id}")]//update za uneseni proizvod

        public Proizvod Update(int id, Proizvod proizvod)
        {
            return _proizvodService.Update(id,proizvod);
        }
    }

    public class Proizvod
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
