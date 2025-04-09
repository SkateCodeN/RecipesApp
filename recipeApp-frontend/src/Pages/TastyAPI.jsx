import React, { useState, useEffect } from 'react';
import RecipeCards from '../components/RecipeCards.jsx'
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
                <h2>Random List:</h2>

                <RecipeCards recipes={recipes} />

            </div>
        </>
    )
}

export default TastyAPI;