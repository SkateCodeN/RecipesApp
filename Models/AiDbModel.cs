using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
namespace NoteApp.Models
{
    [Table("airecipes")]
    public class AiRecipe
    {
        [Column("id")]
        public int Id {get; set;}

        [Column("jsondata")]
        public string? JsonData {get; set;}

        [Column("recipe_count")]
        public int? Recipe_Count {get; set;}
        

    }
}