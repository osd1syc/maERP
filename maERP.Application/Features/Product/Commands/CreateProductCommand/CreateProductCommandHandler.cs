﻿using AutoMapper;
using maERP.Application.Contracts.Logging;
using maERP.Application.Contracts.Persistence;
using maERP.Application.Exceptions;
using MediatR;

namespace maERP.Application.Features.Product.Commands.CreateProductCommand;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IAppLogger<CreateProductCommandHandler> _logger;
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IMapper mapper,
        IAppLogger<CreateProductCommandHandler> logger,
        IProductRepository productRepository)
    {
        _mapper = mapper;
        _logger = logger;
        _productRepository = productRepository;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateProductCommandValidator(_productRepository);
        var validationResult = await validator.ValidateAsync(request);

        if(validationResult.Errors.Any())
        {
            _logger.LogWarning("Validation errors in create request for {0} - {1}", nameof(CreateProductCommand), request.Name);
            throw new ValidationException("Invalid Product", validationResult);
        }

        var productToCreate = _mapper.Map<Domain.Models.Product>(request);

        await _productRepository.CreateAsync(productToCreate);

        return productToCreate.Id;
    }
}