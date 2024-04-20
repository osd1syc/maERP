﻿using FluentValidation;
using maERP.Application.Contracts.Persistence;

namespace maERP.Application.Features.TaxClass.Commands.DeleteTaxClassCommand;

public class DeleteTaxClassCommandValidator : AbstractValidator<DeleteTaxClassCommand>
{
    private readonly ITaxClassRepository _taxClassRepository;

    public DeleteTaxClassCommandValidator(ITaxClassRepository taxClassRepository)
    {
        _taxClassRepository = taxClassRepository;

        RuleFor(p => p.Id)
            .NotNull()
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
    }
}