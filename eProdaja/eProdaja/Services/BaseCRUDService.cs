using AutoMapper;
using eProdaja.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    //paziti da se doda baza na baseCRUD!!
    public class BaseCRUDService<T, TDb,TSearch, TInsert, TUpdate> : BaseReadService<T, TDb, TSearch>, ICRUDService<T, TSearch, TInsert, TUpdate>
         where T : class where TSearch : class where TUpdate : class where TInsert : class where TDb : class
    {
        public BaseCRUDService(eProdajaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public virtual T Insert(TInsert request)
        {
            var set = Context.Set<TDb>();
            var entity = _mapper.Map<TDb>(request);//mapirmo objekat poslan requestom
            set.Add(entity);//kad smo ga mapirali dodajemo ga u set
            Context.SaveChanges();
            return _mapper.Map<T>(entity);//mapiramo ga u odredjeni tip podatka koji  je prosljedjen...
        }

        public virtual T Update(int id, TUpdate request)
        {
            //prvo trebamo ucitat podatak, pa onda update...
            var set = Context.Set<TDb>();
            var entity = set.Find(id);
            _mapper.Map(request, entity);//mapiramo request u entity

            Context.SaveChanges();
            return _mapper.Map<T>(entity);

        }
    }
}
