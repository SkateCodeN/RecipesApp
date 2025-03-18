import React, { useState} from "react";
//import "./RecipesList.css";

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
        <div className="container" style={{width:"300px",padding:"20px 0"}}>
            <div className="card" >
                <div className="card-content">
                    <div className="container">
                        
                        <h3 style={{color:"yellow"}}>New Recipe</h3>

                    </div>
                    

                    <div className="field">
                        <label className="label" htmlFor="name-box">Name</label>
                        <div className="control">
                            <input 
                                id="name-box" 
                                type="text" 
                                className="input"
                                value={recipeName}
                                onChange={(e) => setRecipeName(e.target.value)}
                            />
                        </div>
                    </div>

                    <div className="field">
                        <label className="label" htmlFor="description-box">Description</label>
                        <div className="control">
                            <input 
                                id="description-box" 
                                className="input"
                                type="text" 
                                value={description}
                                onChange={(e) => setDescription(e.target.value)}
                            />
                        </div>
                    
                    </div>

                    <div className="field">
                        <div className="control">
                            <button 
                                type="button" 
                                className="button is-link"
                                onClick={handleCreateClick}
                            >
                                Create
                            </button>
                        </div>
                        
                    </div>
                </div>
            </div>
        </div>

    )
}

export default CreateRecipe;