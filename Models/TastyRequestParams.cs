namespace NoteApp.Models
{
    public class TastyRequestParams
    {
        public string? Tags { get; set; }
        public string? NameOrIngredients { get; set; }


    }
}

//Setting type safety for the incoming params from the front end. THis class is used in the controller 
// logic. 