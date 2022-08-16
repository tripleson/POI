using Application.Interface;
using AutoMapper;
using MediatR;

namespace Application.Point.Query;

public class GetPointByLoLa : IRequest<Domain.Entities.Point>
{
    public decimal Longtitude { get; set; }
    public decimal Latitude { get; set; }
}

public class GetPointByLoLaHandler : IRequestHandler<GetPointByLoLa, Domain.Entities.Point>
{
    private readonly IPOIContext _poiContext;
    private readonly IMapper _mapper;
    
    public GetPointByLoLaHandler(IPOIContext poiContext,
        IMapper mapper)
    {
        _poiContext = poiContext;
        _mapper = mapper;
    }
    
    public async Task<Domain.Entities.Point> Handle(GetPointByLoLa request, CancellationToken cancellationToken)
    {
        var point = await _poiContext.Points.FindAsync(request.Latitude, request.Longtitude);

        if (point == null)
            throw new System.Exception("Không tìm thấy tọa độ");

        return point;
    }
}