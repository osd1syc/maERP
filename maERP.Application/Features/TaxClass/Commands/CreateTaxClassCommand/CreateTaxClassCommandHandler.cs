﻿using AutoMapper;
using maERP.Application.Contracts.Logging;
using maERP.Application.Contracts.Persistence;
using maERP.Application.Exceptions;
using MediatR;

namespace maERP.Application.Features.TaxClass.Commands.CreateTaxClassCommand;

public class CreateTaxClassCommandHandler : IRequestHandler<CreateTaxClassCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IAppLogger<CreateTaxClassCommandHandler> _logger;
    private readonly ITaxClassRepository _taxClassRepository;

    public CreateTaxClassCommandHandler(IMapper mapper,
        IAppLogger<CreateTaxClassCommandHandler> logger,
        ITaxClassRepository taxClassRepository)
    {
        _mapper = mapper;
        _logger = logger;
        _taxClassRepository = taxClassRepository;
    }

    public async Task<int> Handle(CreateTaxClassCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateTaxClassCommandValidator(_taxClassRepository);
        var validationResult = await validator.ValidateAsync(request);

        if(validationResult.Errors.Any())
        {
            _logger.LogWarning("Validation errors in create request for {0} - {1}", nameof(CreateTaxClassCommand), request.TaxRate);
            throw new ValidationException("Invalid TaxClass", validationResult);
        }

        var taxClassToCreate = _mapper.Map<Domain.Models.TaxClass>(request);

        await _taxClassRepository.CreateAsync(taxClassToCreate);

        return taxClassToCreate.Id;
    }
}