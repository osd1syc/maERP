﻿using maERP.Application.Contracts.Persistence;
using maERP.Application.Exceptions;
using maERP.Domain.Models;
using maERP.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace maERP.Persistence.Repositories;

public class SalesChannelRepository : GenericRepository<SalesChannel>, ISalesChannelRepository
{
    public SalesChannelRepository(ApplicationDbContext context) : base(context)
    {

    }

    public async Task<SalesChannel> GetDetails(int id)
    {
        var salesChannel = await _context.SalesChannel
            .Include(s => s.Warehouse)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (salesChannel == null)
        {
            throw new NotFoundException("SalesChannel not found", id);
        }
        
        salesChannel.WarehouseId = salesChannel.Warehouse.Id;

        return salesChannel;
    }

    /*
    public async Task<SalesChannelDetailDto> AddWithDetailsAsync(SalesChannelCreateDto salesChannelCreateDto)
    {
        var salesChannel = _mapper.Map<SalesChannel>(salesChannelCreateDto);
        salesChannel.Warehouse = await _context.Warehouse.FirstOrDefaultAsync(w => w.Id == salesChannelCreateDto.WarehouseId);

        _context.Add(salesChannel);
        await _context.SaveChangesAsync();
        var salesChannelDetailDto = _mapper.Map<SalesChannelDetailDto>(salesChannel);

        return salesChannelDetailDto;
    }

    public async Task UpdateWithDetailsAsync(int id, SalesChannelUpdateDto salesChannelUpdateDto)
    {
        if (!await Exists(id))
        {
            throw new NotFoundException("SalesChannel not found", id);
        }

        var salesChannel = _mapper.Map<SalesChannel>(salesChannelUpdateDto);
        salesChannel.Warehouse = await _context.Warehouse.FirstOrDefaultAsync(w => w.Id == salesChannelUpdateDto.WarehouseId);

        _context.Update(salesChannel);
        await _context.SaveChangesAsync();
    }
    */
}