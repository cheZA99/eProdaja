using AutoMapper;
using eProdaja.Database;
using eProdaja.Model;
using eProdaja.Model.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class ProizvodiService: BaseCRUDService<Model.Proizvodi,Database.Proizvodi, ProizvodiSearchObject, ProizvodiInsertRequest, ProizvodiUpdateRequest>,IProizvodiService
    {
        public ProizvodiService(eProdajaContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IEnumerable<Model.Proizvodi> Get(ProizvodiSearchObject searchObject = null)
        {

            var entity = Context.Set<Database.Proizvodi>().AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchObject?.Naziv))//objekat moze biti null
                entity = entity.Where(x => x.Naziv.Contains(searchObject.Naziv));

            if (searchObject.JedinicaMjereID.HasValue)
                entity = entity.Where(x => x.JedinicaMjereId == searchObject.JedinicaMjereID);

            if (searchObject.VrstaID.HasValue)
                entity = entity.Where(x => x.VrstaId == searchObject.VrstaID);

            if (searchObject?.IncludeJedinicaMjere == true)
                entity = entity.Include("JedinicaMjere");

            var list = entity.ToList();
            return _mapper.Map<List<Model.Proizvodi>>(list);
        }
    }
}
