using Application.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FluentValidation;

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

    public class CreateSuperHeroCommandValidator : AbstractValidator<CreateSuperHeroCommand>
    {
        public CreateSuperHeroCommandValidator()
        {
            RuleFor(a => a.Age)
                .GreaterThanOrEqualTo(18)
                .WithMessage("Age should be greater than or equal to 18");

            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("Name length should be not empty okeeeeeeee");

            RuleFor(a => a.Name)
                .MaximumLength(10)
                .WithMessage("Name length should be less than 10");
        }
    }
}
