﻿using maERP.Application.Dtos.Warehouse;
using MediatR;

namespace maERP.Application.Features.Warehouse.Commands.UpdateWarehouseCommand;

public class UpdateWarehouseCommand : IRequest<int>
{
    public int Id { get; set; }     
    public string Name { get; set; } = string.Empty;
}