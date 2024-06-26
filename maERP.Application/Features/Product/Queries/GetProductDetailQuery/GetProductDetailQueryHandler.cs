﻿using AutoMapper;
using maERP.Application.Contracts.Logging;
using maERP.Application.Contracts.Persistence;
using maERP.Application.Dtos.Product;
using maERP.Application.Exceptions;
using MediatR;

namespace maERP.Application.Features.Product.Queries.GetProductDetailQuery;

public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, ProductDetailDto>
{
    private readonly IMapper _mapper;
    private readonly IAppLogger<GetProductDetailQueryHandler> _logger;
    private readonly IProductRepository _productRepository;

    public GetProductDetailQueryHandler(IMapper mapper,
        IAppLogger<GetProductDetailQueryHandler> logger,
        IProductRepository productRepository)
    {
        _mapper = mapper;
        _logger = logger;
        _productRepository = productRepository;
    }
    public async Task<ProductDetailDto> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);

        if(product == null)
        {
            throw new NotFoundException("NotFoundException", "Product not found.");
        }

        var data = _mapper.Map<ProductDetailDto>(product);

        _logger.LogInformation("All Productes are retrieved successfully.");
        return data;
    }
}