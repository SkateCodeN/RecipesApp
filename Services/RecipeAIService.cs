using System.Net.Http;
using System.Threading.Tasks;
//using Newtonsoft.Json; <--- JSON serializer
using System.Text.Json;
using NoteApp.Controllers;
using System.Text.Json.Serialization;
using NoteApp.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Runtime.CompilerServices;
using System.Net.Http.Headers;

namespace NoteApp.Services
{
    public class RecipeAIService
    {
        private readonly HttpClient _httpClient;
        private readonly string? ApiKey;
        public RecipeAIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            //_httpClient.Timeout = TimeSpan.FromSeconds(80);
            ApiKey = Environment.GetEnvironmentVariable("ApiSettings__ApiKey2");
        }

        public async Task<AIResponse> GetAIData2()
        {
            int number = 5;
            string userMessage = $@"I will give you a number, your output will be a JSON, and a number of real random 
            recipe/recipes. Output its name, description, ingredients and amounts as a list, cook time, prep time, and
            instructions. 
            Only output a valid JSON, no other words are necessary
            Number of recipes is {number}";

            string url = "https://chatgpt-42.p.rapidapi.com/gpt4";

            //create an anonymous obj for the payload
            var payloadObj =  new {
                messages = new[]
                {
                    new { role= "user", content = userMessage}
                },
                web_access = false
            };

            // Serialize the object into a JSON string
            string jsonPayload2 = JsonSerializer.Serialize(payloadObj);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(url),
                Headers =
                {
                    { "x-rapidapi-key", ApiKey },
                    { "x-rapidapi-host",  "chatgpt-42.p.rapidapi.com"},
                },
                Content = new StringContent(jsonPayload2)
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue("application/json")
                    }
                }
            };
            using (var response = await _httpClient.SendAsync(request,HttpCompletionOption.ResponseHeadersRead))
            {
                //We use a stream to wait for the full response from the AI API
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                using var reader = new StreamReader(stream);
                string fullResponse = await reader.ReadToEndAsync();

                var readTask = response.Content.ReadAsStringAsync();
                // var timeoutTask = Task.Delay(TimeSpan.FromSeconds(20));

                // if(await Task.WhenAny(readTask, timeoutTask) == readTask)
                // {
                //string fullResponse = await readTask;

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    };

                    var aiResponse = JsonSerializer.Deserialize<AIResponse>(fullResponse,options);
                    return aiResponse;
                // }
                // else
                // {
                //     throw new TimeoutException("Timeout...");
                // } 
                
            }
        }


    }
    
}

