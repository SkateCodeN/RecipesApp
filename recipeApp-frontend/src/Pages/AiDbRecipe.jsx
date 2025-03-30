import React, { useState, useEffect } from "react";


const AiDbRecipe = () => {
    const [recipes, setRecipes] = useState([]);
    useEffect(() => {
        getRecipes();
    }, []);

    const getRecipes = async () => {

        try {
            const response = await fetch("http://localhost:5234/api/recipes/aidb");
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

    if (!recipes) return <p>Loading data</p>

    return (
        <div className="container">
            <div className="container is-max-tablet">

                {
                    recipes && recipes[0].data.map((recipe) => (

                        <div key={recipe.name} className='card' style={{ width: "400px" }}>
                            <div className='card-img'>
                                <figure className='image is-4by3"'>
                                    <h3>Ai Gen</h3>
                                </figure>
                            </div>

                            <div className='card-content'>
                                <div className='media'>
                                    <div className='media-content'>
                                        <p className='title is-4'>{recipe.name}</p>
                                    </div>
                                </div>

                                <div className='content' >
                                    {recipe.description}
                                </div>

                            </div>
                            <footer className='card-footer'>

                                <a href="#" className="card-footer-item">Save</a>
                                <a href="#" className="card-footer-item">Edit</a>
                                <a href="#" className="card-footer-item">Delete</a>
                            </footer>

                        </div>
                    ))
                }

            </div>
        </div>
    )
}

export default AiDbRecipe;