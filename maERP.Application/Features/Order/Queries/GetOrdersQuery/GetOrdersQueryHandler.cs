﻿using AutoMapper;
using maERP.Application.Contracts.Logging;
using maERP.Application.Contracts.Persistence;
using maERP.Application.Dtos.Order;
using MediatR;

namespace maERP.Application.Features.Order.Queries.GetOrdersQuery;

public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, List<OrderListDto>>
{
    private readonly IMapper _mapper;
    private readonly IAppLogger<GetOrdersQueryHandler> _logger;
    private readonly IOrderRepository _orderRepository;

    public GetOrdersQueryHandler(IMapper mapper,
        IAppLogger<GetOrdersQueryHandler> logger, 
        IOrderRepository orderRepository)
    {
        _mapper = mapper;
        _logger = logger;
        _orderRepository = orderRepository; 
    }
    public async Task<List<OrderListDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        // Query the database
        var orderes = await _orderRepository.GetAllAsync();

        // Convert data objects to DTO objects
        var data = _mapper.Map<List<OrderListDto>>(orderes);

        // Return list of DTO objects
        _logger.LogInformation("All Orderes are retrieved successfully.");
        return data;
    }
}