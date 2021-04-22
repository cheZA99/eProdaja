using AutoMapper;
using eProdaja.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class BaseReadService<T, TDb, TSearch> : IReadService<T, TSearch> where T : class where TDb : class where TSearch : class//T must be reference type tj. da je T parametar klasa
    {
        public eProdajaContext Context { get; set; }
        protected readonly IMapper _mapper;
        public BaseReadService (eProdajaContext context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }
        public virtual IEnumerable<T> Get(TSearch serach = null)
        {
            var entity = Context.Set<TDb>();
            var list = entity.ToList();
            return _mapper.Map<List<T>>(list);
        }

        public virtual T GetById(int id)
        {
            var entity = Context.Set<TDb>();
            var fnd = entity.Find(id);
            return _mapper.Map<T>(fnd);
        }
    }
}
