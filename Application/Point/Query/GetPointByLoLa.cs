using Application.Interface;
using AutoMapper;
using MediatR;

namespace Application.Point.Query;

public class GetPointByLoLa : IRequest<PointDTO>
{
    public decimal Longtitude { get; set; }
    public decimal Latitude { get; set; }
}

public class GetPointByLoLaHandler : IRequestHandler<GetPointByLoLa, PointDTO>
{
    private readonly IPOIContext _poiContext;
    private readonly IMapper _mapper;
    
    public GetPointByLoLaHandler(IPOIContext poiContext,
        IMapper mapper)
    {
        _poiContext = poiContext;
        _mapper = mapper;
    }
    
    public async Task<PointDTO> Handle(GetPointByLoLa request, CancellationToken cancellationToken)
    {
        var point = await _poiContext.Points.FindAsync(request.Latitude, request.Longtitude);

        if (point == null)
            throw new System.Exception("Không tìm thấy tọa độ");

        var dto = _mapper.Map<PointDTO>(point);

        return dto;
    }
}