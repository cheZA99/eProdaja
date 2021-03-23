using eProdaja.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    /*Ukoliko trebamo sutra koristit graphQL, mi to nismo u mnogucnoti ukoliko se nas kod
     nalazi u kontrolerima  jer narusavamo ostatak aplikacije ako uradimo neke promjene. Taj problem se rijesava 
    interfacima*/
    public interface IProizvodService
    {
        public IEnumerable<Proizvod> Get();
        public Proizvod GetById(int id);
        public Proizvod Insert(Proizvod proizvod);
        public Proizvod Update(int id, Proizvod proizvod);

    }
}
