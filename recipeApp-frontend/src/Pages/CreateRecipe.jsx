import React, { useState} from "react";
import "./RecipesList.css";

const CreateRecipe = () => {

    const [recipeName, setRecipeName] = useState("");
    const [description, setDescription] = useState("");

    const handleCreateClick = () => {
        const payload = createPayload(recipeName, description);
        createRecipe(payload);
    }

    const createPayload = (name, description) => {
        const payload = {
            name: name,
            description: description
        };

        return payload;
    }

    const createRecipe = async (payload) => {
        try {
            const response = await fetch("http://localhost:5234/api/recipes", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(payload)
            });

            if (!response.ok) {
                throw new Error("Error contacting localhost at 5234 to create recipe");
            }

            const data = await response.json();
            alert(data);
            // Optionally, clear the form fields
            setRecipeName("");
            setDescription("");
        }
        catch (error) {
            console.log("Error sending payload to Db to create recipe", error)
        }
    }
    return (
        <div className="recipes-container">
            <div className="recipe-card">
                <div>
                    <h3 className="recipe-name">New Recipe</h3>
                    <label className="recipe-name" htmlFor="name-box">Name</label>
                    <input 
                        id="name-box" 
                        type="text" 
                        value={recipeName}
                        onChange={(e) => setRecipeName(e.target.value)}
                    />
                </div>

                <div>
                    <label className="recipe-name" htmlFor="description-box">Description</label>
                    <input 
                        id="description-box" 
                        type="text" 
                        value={description}
                        onChange={(e) => setDescription(e.target.value)}
                    />
                </div>
                <div>
                    <button type="button" onClick={handleCreateClick}>Create</button>
                </div>

            </div>
        </div>

    )
}

export default CreateRecipe;