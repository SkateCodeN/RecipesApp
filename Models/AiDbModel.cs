using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace NoteApp.Models
{
    [Table("airecipes")]
    public class AiRecipe
    {
        [Column("id")]
        public int Id {get; set;}

        [Column("jsondata")]
        public List<JsonRecipes>? Data {get; set;}

        [Column("recipe_count")]
        public int? Recipe_Count {get; set;}
        

    }

   
    public class JsonRecipes 
    {
        [JsonPropertyName("name")]
        public string? Name {get; set;}

        [JsonPropertyName("description")]
        public string? Description {get; set;}

        
        [JsonPropertyName("ingredients")]
        public List<Ingredient>? Ingredients {get; set;}

        [JsonPropertyName("prep_time")]
        public string? PrepTime {get; set;}

        [JsonPropertyName("cook_time")]
        public string? CookTime {get; set;}

        [JsonPropertyName("instructions")]
        public List<string>? Instructions {get; set;}
    }
    
    public class Ingredient
    {
        [JsonPropertyName("ingredient")]
        public string? RecipeIngredient {get; set;}

        [JsonPropertyName("amount")]
        public string? Amount {get; set;}

        
    }
}