using Application.Interface;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SuperHero.Query
{
    public class GetSuperHeroesQuery : IRequest<List<SuperHereosDTO>>
    {
    }

    public class GetSuperheroesQueryHandler : IRequestHandler<GetSuperHeroesQuery, List<SuperHereosDTO>>
    {
        private readonly IAppContext _context;
        private readonly IMapper _mapper;

        public GetSuperheroesQueryHandler(IAppContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SuperHereosDTO>> Handle(GetSuperHeroesQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.SuperHeroes.ToListAsync();

            //var dto = data.Select(a =>
            //{
            //    return _mapper.Map<SuperHereosDTO>(a);
            //}).ToList();

            var dto = _mapper.Map<List<SuperHereosDTO>>(data);

            return dto;
        }
    }
}
