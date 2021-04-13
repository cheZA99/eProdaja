using AutoMapper;
using eProdaja.Database;
using eProdaja.FIlters;
using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class KorisniciService : IKorisniciService
    {
        public eProdajaContext Context { get; set; }
        protected readonly IMapper _mapper;
        public KorisniciService(eProdajaContext context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }
        public List<Model.Korisnici> Get()
        {
            //iz te liste sto imamo select(in memory) convert u nas models 
            return Context.Korisnicis.ToList().Select(x => _mapper.Map<Model.Korisnici>(x)).ToList();
        }

        public Model.Korisnici Insert(KorisniciInsertRequest request)
        {
            throw new UserException("Lozinka nije ispravna");
        }

        //private Model.Korisnici ToModel (Korisnici korisnici)
        //{
        //    return new Model.Korisnici()
        //    {
        //        KorisnikId = korisnici.KorisnikId,
        //        Ime = korisnici.Ime,
        //        Prezime = korisnici.Prezime,
        //        KorisnickoIme = korisnici.KorisnickoIme,
        //        Email = korisnici.Email,
        //        Telefon = korisnici.Telefon
        //    };
        //}
    }   
}
