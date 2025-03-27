using System.Collections.Generic;
using System.Text.Json.Serialization;

public class AIResponse
{
    [JsonPropertyName("result")]
    public string? Result {get; set;}

    [JsonPropertyName("status")]
    public bool? Status {get; set;}

    [JsonPropertyName("server_code")]
    public string? Server_Code {get; set;}

}