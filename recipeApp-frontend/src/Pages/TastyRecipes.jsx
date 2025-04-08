//Todo a form component and a recipes component
// The form takes in a param to send to the backend
// The tasty recipes component receives a JSon an outputs recipes 
import React, { useState } from "react";

const TastyRecipes = () => {

    const [tag, setTag] = useState("");
    const [recipes, setRecipes] = useState({});
     
    const handleInputChange = (e) => {
        setTag(e.target.value);
    }

    const getRecipes = async () => {

        try {
             //POST: /api/recipes/tastyApi/randomList
            const response = await fetch("http://localhost:5234/api/recipes/tastyApi/randomList",{
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({
                    Tags: tag,
                    NameOrIngredients:""

                })
            });
            if (!response.ok) {
                throw new Error("No connection to localhost:5234");
            }
            const data = await response.json();
            setRecipes(data);
            console.log("Data", data.results);
        }
        catch (error) {
            console.log('Error fetching recipes', error);
        }

    }

    const handleSubmit = () =>{
        getRecipes();
    }

    return (
        <div className="container">
            <div className="card is-flex is-flex-row">
                <label htmlFor="paramInput">Input Params for Recipe:</label>
                <input type="text" id="paramInput" value={tag} onChange={handleInputChange}></input>
                <button type="button" className="button is-primary" onClick={handleSubmit} >Submit</button>
            </div>
            <div className="container">
                
                
            </div>
        </div>

    )
}

export default TastyRecipes;