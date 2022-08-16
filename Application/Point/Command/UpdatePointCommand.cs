using Application.Interface;
using Application.Point.Query;
using FluentValidation;
using MediatR;

namespace Application.Point.Command;

public class UpdatePointCommand : CreatePointCommand
{
}

public class UpdatePointCommandHandler : IRequestHandler<UpdatePointCommand>
{
    private readonly IPOIContext _poiContext;
    private readonly IMediator _mediator;

    public UpdatePointCommandHandler(IPOIContext poiContext,
        IMediator mediator)
    {
        _poiContext = poiContext;
        _mediator = mediator;
    }
    
    public async Task<Unit> Handle(UpdatePointCommand request, CancellationToken cancellationToken)
    {
        var point = await _mediator.Send(new GetPointByLoLa()
        {
            Longtitude = request.Longitude,
            Latitude = request.Latitude,
        });

        if (point == null)
            throw new System.Exception("Không tìm thấy tọa độ phù hợp");

        point.Address = request.Address;
        point.Phone = request.Phone;
        point.Title = request.Title;
        point.Website = request.Website;

        _poiContext.Points.Update(point);
        await _poiContext.SaveChangeAsync();

        return Unit.Value;
    }
}

public class UpdatePointCommandValidator : AbstractValidator<UpdatePointCommand>
{
    public UpdatePointCommandValidator()
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