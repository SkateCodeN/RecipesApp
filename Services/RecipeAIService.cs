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
using System.Text;

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

        // public async Task<AIResponse> GetAIData2()
        // {
        //     int number = 5;
        //     string userMessage = $@"I will give you a number, your output will be a JSON, and a number of real random 
        //     recipe/recipes. Output its name, description, ingredients and amounts as a list, cook time, prep time, and
        //     instructions. 
        //     Only output a valid JSON, no other words are necessary
        //     Number of recipes is {number}";

        //     string url = "https://chatgpt-42.p.rapidapi.com/gpt4";

        //     //create an anonymous obj for the payload
        //     var payloadObj = new
        //     {
        //         messages = new[]
        //         {
        //             new { role= "user", content = userMessage}
        //         },
        //         web_access = false
        //     };

        //     // Serialize the object into a JSON string
        //     string jsonPayload2 = JsonSerializer.Serialize(payloadObj);

        //     var request = new HttpRequestMessage
        //     {
        //         Method = HttpMethod.Post,
        //         RequestUri = new Uri(url),
        //         Headers =
        //         {
        //             { "x-rapidapi-key", ApiKey },
        //             { "x-rapidapi-host",  "chatgpt-42.p.rapidapi.com"},
        //         },
        //         Content = new StringContent(jsonPayload2)
        //         {
        //             Headers =
        //             {
        //                 ContentType = new MediaTypeHeaderValue("application/json")
        //             }
        //         }
        //     };


        //     using (var response = await _httpClient.SendAsync(request))
        //     {
        //         using (var stream = await response.Content.ReadAsStreamAsync())
        //         using (var reader = new StreamReader(stream))
        //         {
        //             char[] buffer = new char[8192];
        //             int read;
        //             var fullResponseBuilder = new StringBuilder();

        //             while ((read = await reader.ReadAsync(buffer, 0, buffer.Length)) > 0)
        //             {
        //                 fullResponseBuilder.Append(buffer, 0, read);
        //             }

        //             string fullResponse = fullResponseBuilder.ToString();
        //             // Deserialize fullResponse...
        //             var options = new JsonSerializerOptions
        //             {
        //                 PropertyNameCaseInsensitive = true,
        //             };

        //             var aiResponse = JsonSerializer.Deserialize<AIResponse>(fullResponse, options);
        //             return aiResponse;
        //         }


        //         // }
        //         // else
        //         // {
        //         //     throw new TimeoutException("Timeout...");
        //         // } 

        //     }
        // }

        public async Task<AIResponse> GetAIData2()
        {
            int number = 5;
            string userMessage = $@"I will give you a number, your output will be a JSON, and a number of real random 
recipe/recipes. Output its name, description, ingredients and amounts as a list, cook time, prep time, and
instructions. 
Only output a valid JSON, no other words are necessary.
Number of recipes is {number}";

            string url = "https://chatgpt-42.p.rapidapi.com/gpt4";

            // build the payload
            var payload = new
            {
                messages = new[] {
                new { role = "user", content = userMessage }
            },
                web_access = false
            };
            string jsonPayload = JsonSerializer.Serialize(payload);

            // create the request
            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json")
            };
            request.Headers.Add("x-rapidapi-key", ApiKey);
            request.Headers.Add("x-rapidapi-host", "chatgpt-42.p.rapidapi.com");

            // send and start reading as soon as headers arrive
            using var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync();
            using var reader = new StreamReader(stream);

            var buffer = new StringBuilder();
            while (!reader.EndOfStream)
            {
                string? line = await reader.ReadLineAsync();
                if (line == null) break;
                buffer.AppendLine(line);

                // break as soon as we heuristically detect a complete JSON object
                if (IsJsonComplete(buffer.ToString()))
                    break;
            }

            string fullJson = buffer.ToString();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var aiResponse = JsonSerializer.Deserialize<AIResponse>(fullJson, options)
                             ?? throw new InvalidOperationException("Failed to deserialize AIResponse");

            return aiResponse;
        }

        private bool IsJsonComplete(string json)
        {
            // Simple heuristic: count { and }—when they balance, we likely have the full object
            int opens = json.Count(c => c == '{');
            int closes = json.Count(c => c == '}');
            return opens > 0 && opens == closes;
        }
    }

}

