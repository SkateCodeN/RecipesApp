import React, { useState, useEffect} from "react";
import "./RecipesList.css";

const ApiRecipe = () => {
    const [recipes, setRecipes] = useState({});
    useEffect(() => {
        getRecipes();
    }, []);

    const getRecipes = async () => {

        try {
            const response = await fetch("http://localhost:5234/api/recipes/test");
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
        <div className="recipes-container">
            <p>Testing</p>
            <p>Loading...</p>
            <p>Testing 2</p>
        </div>
    )
}

export default ApiRecipe;