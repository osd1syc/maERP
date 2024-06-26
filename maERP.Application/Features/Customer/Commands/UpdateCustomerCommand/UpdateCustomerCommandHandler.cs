﻿using AutoMapper;
using maERP.Application.Contracts.Logging;
using maERP.Application.Contracts.Persistence;
using maERP.Application.Exceptions;
using MediatR;

namespace maERP.Application.Features.Customer.Commands.UpdateCustomerCommand;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IAppLogger<UpdateCustomerCommandHandler> _logger;
    private readonly ICustomerRepository _customerRepository;


    public UpdateCustomerCommandHandler(IMapper mapper,
        IAppLogger<UpdateCustomerCommandHandler> logger,
        ICustomerRepository customerRepository)
    {
        _mapper = mapper;
        _logger = logger;
        _customerRepository = customerRepository;
    }

    public async Task<int> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateCustomerCommandValidator(_customerRepository);
        var validationResult = await validator.ValidateAsync(request);

        if(validationResult.Errors.Any())
        {
            _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(CreateCustomerCommand), request.Id);
            throw new ValidationException("Invalid Customer", validationResult);
        }

        var customerToUpdate = _mapper.Map<Domain.Models.Customer>(request);

        await _customerRepository.UpdateAsync(customerToUpdate);

        return customerToUpdate.Id;
    }
}