using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.SuperHero.Query;
using AutoMapper;

namespace Application.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Domain.Entities.SuperHero, SuperHereosDTO>();
        }
    }
}
