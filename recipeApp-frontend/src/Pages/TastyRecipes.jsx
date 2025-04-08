//Todo a form component and a recipes component
// The form takes in a param to send to the backend
// The tasty recipes component receives a JSon an outputs recipes 
import React, { useState } from "react";

const TastyRecipes = () => {

    const [tag, setTag] = useState("");
    const [recipes, setRecipes] = useState([]);
     
    const handleInputChange = (e) => {
        setParam(e.target.value);
    }

    const getRecipes = async () => {

        try {
             //POST: /api/recipes/tastyApi/randomList
            const response = await fetch("http://localhost:5234/api/recipes/tastyApi/randomList",{
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: {
                    Tags: tag
                }
            });
            if (!response.ok) {
                throw new Error("No connection to localhost:5234");
            }
            const data = await response.json();
            setRecipes(data);
            console.log("Data", data);
        }
        catch (error) {
            console.log('Error fetching recipes', error);
        }

    }

    const handleSubmit = () =>{

    }

    return (
        <div className="container">
            <div className="card">
                <label for="paramInput">Input Params for Recipe:</label>
                <input type="text" id="paramInput" value={param} onChange={handleInputChange}></input>
                <button type="button" className="button is-primary" onClick={handleSubmit} >Submit</button>
            </div>
            <div className="container">
                <p>Test response from api</p>
                <p>Param sent: {recipes && recipes}</p>
            </div>
        </div>

    )
}

export default TastyRecipes;