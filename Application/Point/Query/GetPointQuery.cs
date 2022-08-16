using Application.Interface;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Point.Query;

public class GetPointQuery : IRequest<List<Domain.Entities.Point>>
{
    public decimal Longitude { get; set; }
    public decimal Latitude { get; set; }
    public string? Title { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Website { get; set; }
}

public class GetPointQueryHandler : IRequestHandler<GetPointQuery, List<Domain.Entities.Point>>
{
    private readonly IMapper _mapper;
    private readonly IPOIContext _poiContext;
    
    public GetPointQueryHandler(IMapper mapper,
        IPOIContext poiContext)
    {
        _mapper = mapper;
        _poiContext = poiContext;
    }
    
    public async Task<List<Domain.Entities.Point>> Handle(GetPointQuery request, CancellationToken cancellationToken)
    {
        var data = _poiContext.Points.AsQueryable();

        if (request.Longitude != 0)
        {
            data = data.Where(a => a.Longitude == request.Longitude);
        }

        if (request.Latitude != 0)
        {
            data = data.Where(a => a.Latitude == request.Latitude);
        }

        if (!string.IsNullOrEmpty(request.Title))
        {
            data = data.Where(a => a.Title == request.Title);
        }
        
        if (!string.IsNullOrEmpty(request.Address))
        {
            data = data.Where(a => a.Address == request.Address);
        }
        
        if (!string.IsNullOrEmpty(request.Phone))
        {
            data = data.Where(a => a.Phone == request.Phone);
        }
        
        if (!string.IsNullOrEmpty(request.Website))
        {
            data = data.Where(a => a.Website == request.Website);
        }
        
        return await data.ToListAsync();
    }
}