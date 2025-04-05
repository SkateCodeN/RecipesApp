import React,{useState} from "react";
import Recipe from "./Recipe";

const RecipeList =({count}) =>{
    
    const [recipeList, setRecipeList] = useState([]);
    console.log(`count is ${count}`);

    let newList = [];
    
    for(let i = 0; i < count; i++){
        newList.push(<Recipe key={i} />);
    }
    
   
    
    return(
        <div>
            { 
                newList
            }
        </div>
    )
}

export default RecipeList;