using FluentValidation;
using maERP.Domain.Dtos.TaxClass;
using maERP.Domain.Validators;

namespace maERP.SharedUI.Validators;

public class TaxClassCreateValidator : TaxClassBaseValidator<TaxClassCreateDto>
{
    /*public AiModelInputValidator()
    {
    }*/
    
    // Client-specific validation method
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<TaxClassCreateDto>.CreateWithOptions(
            (TaxClassCreateDto)model, 
            x => x.IncludeProperties(propertyName)));
        
        return result.IsValid ? 
            Array.Empty<string>() : 
            result.Errors.Select(e => e.ErrorMessage);
    };
}