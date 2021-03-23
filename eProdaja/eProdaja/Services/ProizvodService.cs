using eProdaja.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class ProizvodService : IProizvodService
    {
        private static List<Proizvod> proizvodi;

        static ProizvodService()
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


        public IEnumerable<Proizvod> Get()
        {
            return proizvodi;
        }

        public Proizvod GetById(int id)
        {
            return proizvodi.FirstOrDefault(x => x.Id == id);
        }

        public Proizvod Insert(Proizvod proizvod)
        {
            proizvodi.Add(proizvod);
            return proizvod;
        }

        public Proizvod Update(int id, Proizvod proizvod)
        {
            var current = proizvodi.FirstOrDefault(x => x.Id == id);
            current.Name = proizvod.Name;
            return current;
        }
    }
}

