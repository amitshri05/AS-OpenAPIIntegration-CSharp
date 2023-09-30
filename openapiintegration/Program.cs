using System;
using System.Threading.Tasks;
using OpenAI_API;
using OpenAI_API.Completions;

class Program
{
    static async Task Main(string[] args)
    {
        var openAiApiKey = ""; // Replace with your OpenAI API key
        var openAiApiVersion = "2020-08-01"; // Replace with the desired API version

        APIAuthentication aPIAuthentication = new APIAuthentication(openAiApiKey);
        OpenAIAPI openAiApi = new OpenAIAPI(aPIAuthentication);
      

        try
        {
            string prompt = "Once upon a time";
            string model = "text-davinci-003";
            int maxTokens = 50;

            var completionRequest = new CompletionRequest
            {
                Prompt = prompt,
                Model = model,
                MaxTokens = maxTokens
            };

            var completionResult = await openAiApi.Completions.CreateCompletionAsync(completionRequest);
            var generatedText = completionResult.Completions[0].Text; //completionResult.Choices[0].Text.Trim();

            Console.WriteLine("Generated text:");
            Console.WriteLine(generatedText);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
