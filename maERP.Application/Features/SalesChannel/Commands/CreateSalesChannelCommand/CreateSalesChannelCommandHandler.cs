﻿using AutoMapper;
using maERP.Application.Contracts.Logging;
using maERP.Application.Contracts.Persistence;
using maERP.Application.Exceptions;
using MediatR;

namespace maERP.Application.Features.SalesChannel.Commands.CreateSalesChannelCommand;

public class CreateSalesChannelCommandHandler : IRequestHandler<CreateSalesChannelCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IAppLogger<CreateSalesChannelCommandHandler> _logger;
    private readonly ISalesChannelRepository _salesChannelRepository;

    public CreateSalesChannelCommandHandler(IMapper mapper,
        IAppLogger<CreateSalesChannelCommandHandler> logger,
        ISalesChannelRepository salesChannelRepository)
    {
        _mapper = mapper;
        _logger = logger;
        _salesChannelRepository = salesChannelRepository;
    }

    public async Task<int> Handle(CreateSalesChannelCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateSalesChannelCommandValidator(_salesChannelRepository);
        var validationResult = await validator.ValidateAsync(request);

        if(validationResult.Errors.Any())
        {
            _logger.LogWarning("Validation errors in create request for {0} - {1}", nameof(CreateSalesChannelCommand), request.Name);
            throw new ValidationException("Invalid SalesChannel", validationResult);
        }

        var salesChannelToCreate = _mapper.Map<Domain.Models.SalesChannel>(request);

        await _salesChannelRepository.CreateAsync(salesChannelToCreate);

        return salesChannelToCreate.Id;
    }
}