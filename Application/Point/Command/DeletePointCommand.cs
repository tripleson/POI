using Application.Interface;
using Application.Point.Query;
using MediatR;

namespace Application.Point.Command;

public class DeletePointCommand : IRequest
{
    public decimal Longtitude { get; set; }
    public decimal Latitude { get; set; } 
}

public class DeletePointCommandHandler : IRequestHandler<DeletePointCommand>
{
    private readonly IMediator _mediator;
    private readonly IPOIContext _poiContext;
    
    public DeletePointCommandHandler(IMediator mediator,
        IPOIContext poiContext)
    {
        _mediator = mediator;
        _poiContext = poiContext;
    }
    
    public async Task<Unit> Handle(DeletePointCommand request, CancellationToken cancellationToken)
    {
        var point = await _mediator.Send(new GetPointByLoLa
        {
            Longtitude = request.Longtitude,
            Latitude = request.Latitude,
        });

        if (point == null)
            throw new System.Exception("Khum tìm thấy tọa độ nhé");

        _poiContext.Points.Remove(point);
        await _poiContext.SaveChangeAsync();
        
        return Unit.Value;
    }
}