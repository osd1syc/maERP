﻿using Asp.Versioning;
using maERP.Application.Dtos.Warehouse;
using maERP.Application.Features.Warehouse.Commands.CreateWarehouseCommand;
using maERP.Application.Features.Warehouse.Commands.DeleteWarehouseCommand;
using maERP.Application.Features.Warehouse.Commands.UpdateWarehouseCommand;
using maERP.Application.Features.Warehouse.Queries.GetWarehouseDetailQuery;
using maERP.Application.Features.Warehouse.Queries.GetWarehousesQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace maERP.Server.Controllers.Api.V1;

[ApiController]
[Authorize]
[ApiVersion(1.0)]
[Route("/api/v{version:apiVersion}/[controller]")]
public class WarehousesController(IMediator mediator) : ControllerBase
{
    // GET: api/<WarehousesController>
    [HttpGet]
    public async Task<List<WarehouseListDto>> Get()
    {
        var warehouses = await mediator.Send(new GetWarehousesQuery());
        return warehouses;
    }

    // GET api/<WarehousesController>/5
    [HttpGet("{id}")]
    public async Task<WarehouseDetailDto> GetDetails(int id)
    {
        return await mediator.Send(new GetWarehouseDetailQuery { Id = id });
    }

    // POST api/<WarehousesController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Create(CreateWarehouseCommand createWarehouseCommand)
    {
        var response = await mediator.Send(createWarehouseCommand);
        return CreatedAtAction(nameof(Get), new { id = response });
    }

    // PUT api/<WarehousesController>/5
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<WarehouseDetailDto>> Update(int id, UpdateWarehouseCommand updateWarehouseCommand)
    {
        updateWarehouseCommand.Id = id;
        await mediator.Send(updateWarehouseCommand);
        return NoContent();
    }

    // DELETE api/<WarehousesController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteWarehouseCommand { Id = id };
        await mediator.Send(command);
        return NoContent();
    }
}
