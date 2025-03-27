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
        private readonly String? ApiKey;
        public RecipeAIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            ApiKey = Environment.GetEnvironmentVariable("ApiSettings__ApiKey");
        }

        public async Task<string> GetAIData()
        {
            int number = 7;
            string userMessage = $@"I will give you a number, your output will be a JSON (total element in JSON is amount is number) 
            of a real recipe/recipes. Output its name, description, ingredients and amounts, cook time, prep time,
             and instructions. The output should be in JSON format.  Number is {number}";

            string url = "https://chatgpt-42.p.rapidapi.com/gpt4";

            string jsonPayload = $@"{{
                ""messages"": [
                    {{
                        ""role"": ""user"",
                        ""content"": ""{userMessage}""
                    }}
                ],
                ""web_access"": true
            }}";

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(url),
                Headers =
                {
                    { "x-rapidapi-key", ApiKey },
                    { "x-rapidapi-host",  "chatgpt-42.p.rapidapi.com"},
                },
                Content = new StringContent(jsonPayload)
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue("application/json")
                    }
                }
            };
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }


        public async Task<AIResponse> GetAIData2()
        {
            int number = 5;
            string userMessage = $@"I will give you a number, your output will be a JSON (total element in JSON is amount is number) 
            of a real recipe/recipes. Output its name, description, ingredients and amounts, cook time, prep time,
             and instructions. The output should be in JSON format, strict JSON nothing else.  Number is {number}";

            string url = "https://chatgpt-42.p.rapidapi.com/o3mini";

            string jsonPayload = $@"{{
                ""messages"": [
                    {{
                        ""role"": ""user"",
                        ""content"": ""{userMessage}""
                    }}
                ],
                ""web_access"": true
            }}";

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
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                using var reader = new StreamReader(stream);
                string fullResponse = await reader.ReadToEndAsync();
                //var body = await response.Content.ReadAsStringAsync();
                var body = fullResponse;
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                
                var aiResponse = JsonSerializer.Deserialize<AIResponse>(body,options);
                return aiResponse;
            }
        }


    }
    
}

