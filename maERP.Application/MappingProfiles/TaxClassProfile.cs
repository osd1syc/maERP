﻿using AutoMapper;
using maERP.Application.Dtos.TaxClass;
using maERP.Application.Features.TaxClass.Commands.CreateTaxClassCommand;
using maERP.Application.Features.TaxClass.Commands.DeleteTaxClassCommand;
using maERP.Application.Features.TaxClass.Commands.UpdateTaxClassCommand;
using maERP.Domain.Models;

namespace maERP.Application.MappingProfiles;

public class TaxClassProfile : Profile
{
    public TaxClassProfile()
    {
        CreateMap<TaxClass, TaxClassListDto>();
        CreateMap<TaxClass, TaxClassDetailDto>();
        
        CreateMap<CreateTaxClassCommand, TaxClass>();
        CreateMap<DeleteTaxClassCommand, TaxClass>();
        CreateMap<UpdateTaxClassCommand, TaxClass>();
    }
}