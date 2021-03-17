using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Controllers
{
    [ApiController]//meta atribut od .NET-a, koji govori serveru da ova klasa moze da uroavlja requestovima
    [Route("[controller]")]//
    public class ProizvodController : ControllerBase
    {
        private static List<Proizvod> proizvodi;

        static ProizvodController()
        {
            proizvodi = new List<Proizvod>()
           {
               new Proizvod
               {
                   Id= 1,
                   Name="Lapotop"
               },
                new Proizvod
                {
                    Id = 2,
                    Name = "Mis"
                },
            };
        }
        [HttpGet]
        public IEnumerable<Proizvod> Get()
        {
            return proizvodi;
        }
        [HttpGet(template: "{id}")]//vraca uneseni proizvod
        public Proizvod GetById(int id)
        {
            return proizvodi.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]

        public Proizvod Insert(Proizvod proizvod)
        {
            proizvodi.Add(proizvod);
            return proizvod;
        }

        [HttpPut(template: "{id}")]//update za uneseni proizvod

        public Proizvod Update(int id, Proizvod proizvod)
        {
            var current = proizvodi.FirstOrDefault(x => x.Id == id);
            current.Name = proizvod.Name;
            return current;
        }
    }

    public class Proizvod
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
