import React, { useState, useEffect } from 'react';

const TastyAPI = () => {
    const [recipes, setRecipes] = useState([]);
    useEffect(() => {
        getRecipes();
    }, []);

    const getRecipes = async () => {

        try {
            const response = await fetch("http://localhost:5234/api/recipes/randomList");
            if (!response.ok) {
                throw new Error("No connection to localhost:5234");
            }
            const data = await response.json();
            setRecipes(data);
            console.log(data);
        }
        catch (error) {
            console.log('Error fetching recipes', error);
        }

    }

    return (
        <>
            <div className='container'>

                { recipes.results && recipes.results.map((recipe) => (
                    <div key={recipe.id} className='card' style={{width:"400px"}}>
                        <div className='card-img'  >
                            <figure className='image is-4by3"'>
                                <img src={recipe.thumbnail_url}
                                    alt={recipe.slug}
                                   
                                />
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
                            
                            <a href="#" class="card-footer-item">Save</a>
                            <a href="#" class="card-footer-item">Edit</a>
                            <a href="#" class="card-footer-item">Delete</a>
                        </footer>
                        
                    </div>
                ))}

            </div>
        </>
    )
}

export default TastyAPI;