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
        <div className="container">
            <div className="container is-max-tablet">
                <div className="card" style={{display:"flex", gap:"20px"}}>
                    {/* <img src={recipes.meals[0].strMealThumb} width={"200px"}/> */}

                    <div style={{display:"flex", flexDirection:"column"}}>
                        <h2>{recipes.meals[0].strMeal}</h2>
                        <div>
                            <p>
                                {recipes.meals[0].strInstructions}
                            </p>
                            <p>{recipes.meals[0].strCategory}</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default ApiRecipe;