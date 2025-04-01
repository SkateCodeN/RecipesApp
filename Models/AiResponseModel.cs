// This is to help me deserialize responses from 
// the AI api call

using System.Text.Json.Serialization;
using NoteApp.Models;

public class AiRecipeResponse
{
    [JsonPropertyName("recipes")]
    public List<JsonRecipes> Recipes {get; set;}
}