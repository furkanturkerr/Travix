namespace WebAPI.Services;

public interface IOpenAIService
{
    Task<string> CreateMessageWithOpenAIAsync(string message);
}