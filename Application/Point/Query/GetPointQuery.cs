using Application.Interface;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Point.Query;

public class GetPointQuery : IRequest<List<PointDTO>>
{
}

public class GetPointQueryHandler : IRequestHandler<GetPointQuery, List<PointDTO>>
{
    private readonly IMapper _mapper;
    private readonly IPOIContext _poiContext;
    
    public GetPointQueryHandler(IMapper mapper,
        IPOIContext poiContext)
    {
        _mapper = mapper;
        _poiContext = poiContext;
    }
    
    public async Task<List<PointDTO>> Handle(GetPointQuery request, CancellationToken cancellationToken)
    {
        var data = await _poiContext.Points.ToListAsync();

        var dto = _mapper.Map<List<PointDTO>>(data);

        return dto;
    }
}