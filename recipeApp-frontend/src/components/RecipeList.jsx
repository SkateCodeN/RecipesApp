import React,{useState} from "react";
import Recipe from "./Recipe";

const RecipeList =({count}) =>{
    
    const [recipeList, setRecipeList] = useState([]);

    const test =() =>{
        for(let i = 0; i < count; i++){
            return <Recipe />
        }
    }
   
    
    return(
        <div>
            { 
                test()
            }
        </div>
    )
}

export default RecipeList;