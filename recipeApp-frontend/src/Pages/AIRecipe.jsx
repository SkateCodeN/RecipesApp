import React, { useState, useEffect} from "react";
import "./RecipesList.css";

const AIRecipe = () => {
    const [recipes, setRecipes] = useState({});
    useEffect(() => {
        getRecipes();
    }, []);

    const getRecipes = async () => {

        try {
            const response = await fetch("http://localhost:5234/api/recipes/ai/randomList");
            if (!response.ok) {
                throw new Error("No connection to localhost:5234");
            }
            const data = await response.json();
            setRecipes(data);
            console.log("Data", data);
        }
        catch(error)
        {
            console.log('Error fetching recipes', error);
        }

    }

    if(!recipes) return <p>Loading data</p>

    return (
        <div className="container">
            <div className="container is-max-tablet">
                <div className="card" style={{display:"flex", gap:"20px"}}>
                   <p>{recipes && recipes.result}</p>
                </div>
            </div>
        </div>
    )
}

export default AIRecipe;