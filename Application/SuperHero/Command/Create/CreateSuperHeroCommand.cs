using Application.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.SuperHero.Command.Create
{
    public class CreateSuperHeroCommand : IRequest
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class CreateSuperHeroCommandHandler : IRequestHandler<CreateSuperHeroCommand>
    {
        private readonly IAppContext _context;

        public CreateSuperHeroCommandHandler(IAppContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateSuperHeroCommand request, CancellationToken cancellationToken)
        {
            var hero = new Domain.Entities.SuperHero
            {
                Name = request.Name,
                Age = request.Age,
            };

            _context.SuperHeroes.Add(hero);
            await _context.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
