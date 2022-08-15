using Application.Interface;
using FluentValidation;
using MediatR;

namespace Application.Point.Command;

public class CreatePointCommand : IRequest
{
    public decimal Longitude { get; set; }
    public decimal Latitude { get; set; }
    public string? Title { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Website { get; set; }
}

public class CreatePointCommandHandler : IRequestHandler<CreatePointCommand>
{
    private readonly IPOIContext _poiContext;

    public CreatePointCommandHandler(IPOIContext poiContext)
    {
        _poiContext = poiContext;
    }
    
    public async Task<Unit> Handle(CreatePointCommand request, CancellationToken cancellationToken)
    {
        var point = new Domain.Entities.Point
        {
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            Title = request.Title,
            Address = request.Address,
            Phone = request.Phone,
            Website = request.Website,
        };

        await _poiContext.Points.AddAsync(point);
        await _poiContext.SaveChangeAsync();
        
        return Unit.Value;
    }
}

public class CreatePointCommandValidator : AbstractValidator<CreatePointCommand>
{
    public CreatePointCommandValidator()
    {
        RuleFor(a => a.Address)
            .MaximumLength(10)
            .WithMessage("địa chỉ không quá 10 ký tự");
        
        RuleFor(a => a.Title)
            .MaximumLength(10)
            .WithMessage("tiêu đề không quá 10 ký tự");
        
        RuleFor(a => a.Phone)
            .MaximumLength(10)
            .WithMessage("số điện thoại không quá 10 ký tự");
        
        RuleFor(a => a.Website)
            .MaximumLength(10)
            .WithMessage("website không quá 10 ký tự");
    }
}