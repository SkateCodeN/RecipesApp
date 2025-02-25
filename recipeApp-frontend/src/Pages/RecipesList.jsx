import React, { useState, useEffect} from "react";
import "./RecipesList.css";

const RecipesList = () => {
    const [recipes, setRecipes] = useState([]);
    useEffect(() => {
        getRecipes();
    }, []);

    const getRecipes = async () => {

        try {
            const response = await fetch("http://localhost:5234/api/recipes");
            if (!response.ok) {
                throw new Error("No connection to localhost:5234");
            }
            const data = await response.json();
            setRecipes(data);
        }
        catch(error)
        {
            console.log('Error fetching recipes', error);
        }

    }

    if(!recipes) return <p>Loading data</p>

    return (
        <div className="recipes-container">
            {recipes.map((recipe) => (
                <div key={recipe.id} className="recipe-card">
                    <h2 className="recipe-name">{recipe.name}</h2>
                    <p>{recipe.description}</p>
                </div>
            )) }

        </div>
    )
}

export default RecipesList;