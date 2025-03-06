using AutoMapper;
using maERP.Application.Contracts.Logging;
using maERP.Application.Contracts.Persistence;
using maERP.Domain.Wrapper;
using MediatR;

namespace maERP.Application.Features.TaxClass.Commands.TaxClassUpdate;

public class TaxClassUpdateHandler : IRequestHandler<TaxClassInputCommand, Result<int>>
{
    private readonly IMapper _mapper;
    private readonly IAppLogger<TaxClassUpdateHandler> _logger;
    private readonly ITaxClassRepository _taxClassRepository;


    public TaxClassUpdateHandler(IMapper mapper,
        IAppLogger<TaxClassUpdateHandler> logger,
        ITaxClassRepository taxClassRepository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _taxClassRepository = taxClassRepository ?? throw new ArgumentNullException(nameof(taxClassRepository));
    }

    public async Task<Result<int>> Handle(TaxClassInputCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating tax class with ID: {Id}", request.Id);
        
        var result = new Result<int>();
        
        // Validate incoming data
        var validator = new TaxClassUpdateValidator(_taxClassRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.BadRequest;
            result.Messages.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));
            
            _logger.LogWarning("Validation errors in update request for {0}: {1}", 
                nameof(TaxClassInputCommand), 
                string.Join(", ", result.Messages));
                
            return result;
        }

        try
        {
            // Map to domain entity
            var taxClassToUpdate = _mapper.Map<Domain.Entities.TaxClass>(request);
            
            // Update in database
            await _taxClassRepository.UpdateAsync(taxClassToUpdate);
            
            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Ok;
            result.Data = taxClassToUpdate.Id;
            
            _logger.LogInformation("Successfully updated tax class with ID: {Id}", taxClassToUpdate.Id);
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.InternalServerError;
            result.Messages.Add($"An error occurred while updating the tax class: {ex.Message}");
            
            _logger.LogError("Error updating tax class: {Message}", ex.Message);
        }

        return result;
    }
}
