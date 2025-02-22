using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
namespace NoteApp.Models
{
    [Table("recipes")]
    public class Recipe
    {
        [Column("id")]
        public int Id {get; set;}

        [Column("name")]
        public string Name {get; set;} = string.Empty;

        [Column("description")]
        public string? Description {get; set;}
        [Column("createddate")]
        public DateTime? CreateDate { get; set; }

        [Column("lastuseddate")]
        public DateTime? LastUsedDate { get; set; }

    }
}