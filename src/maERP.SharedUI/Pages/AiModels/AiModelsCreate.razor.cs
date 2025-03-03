using System.Net.Http.Json;
using maERP.Domain.Dtos.AiModel;
using maERP.Domain.Wrapper;
using maERP.SharedUI.Contracts;
using maERP.SharedUI.Validators;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace maERP.SharedUI.Pages.AiModels;

public partial class AiModelsCreate
{
    [Inject]
    public required NavigationManager NavigationManager { get; set; }
    
    [Inject]
    public required ISnackbar Snackbar { get; set; }

    [Inject]
    public required IHttpService HttpService { get; set; }
    
    [Inject]
    public required AiModelCreateValidator Validator { get; set; }
    
    public MudForm? _form;
    public AiModelCreateDto AiModelCreate = new();
    
    protected async Task OnValidSubmit()
    {
        if (_form is not null)
        {
            await _form.Validate();
            
            if (_form.IsValid)
            {
                await Save();
            }
        }
    }

    protected async Task Save()
    {
        var httpResponseMessage = await HttpService.PostAsJsonAsync<AiModelCreateDto>("/api/v1/AiModels", AiModelCreate);
        var result = await httpResponseMessage.Content.ReadFromJsonAsync<Result<int>>() ?? null;
        
        if (result != null)
        {
            if (result.Succeeded)
            {
                Snackbar.Add("AI Model gespeichert", Severity.Success);
                NavigateToList();
            }
            else
            {
                foreach (var errorMessage in result.Messages)
                {
                    Snackbar.Add("SERVER: " + errorMessage, Severity.Error);
                }
            }
        }
        else
        {
            Snackbar.Add("AI Model konnte nicht gespeichert werden", Severity.Error);
        }
    }

    public void NavigateToList()
    {
        StateHasChanged();
        NavigationManager.NavigateTo("/AiModels");
    }
}