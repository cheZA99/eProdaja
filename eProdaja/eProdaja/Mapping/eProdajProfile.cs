using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Mapping
{
    public class eProdajProfile : Profile
    {
        public eProdajProfile()
        {
            CreateMap<Database.Korisnici, Model.Korisnici>();
        }
    }
}
