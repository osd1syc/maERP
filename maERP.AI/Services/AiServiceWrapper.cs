using maERP.Application.Contracts.Ai;
using maERP.Domain.Entities;
using maERP.Domain.Enums;

namespace maERP.AI.Services;

public class AiServiceWrapper : IAiServiceWrapper
{
    AiService _aiService;
    AiPrompt _aiPrompt;
    
    public AiServiceWrapper()
    {
        _aiPrompt = new AiPrompt();
    }

    public void SetPrompt(AiPrompt aiPrompt)
    {
        _aiPrompt = aiPrompt;
    }

    public void SetClass()
    {
        if (_aiPrompt.AiModelType == AiModelType.ChatGPT4o)
        {
            _aiService = new ChatGptService();
        }
        else if (_aiPrompt.AiModelType == AiModelType.Claude35)
        {
            _aiService = new ClaudeService();
        }
        else
        {
            throw new Exception("AiModelType not supported");
        }
    }
    
    public void StartNewChat()
    {
        _aiService.StartNewChat();
    }
    
    public async Task<string> AskAsync(string prompt)
    {
        return await _aiService.AskAsync(prompt);
    }
}