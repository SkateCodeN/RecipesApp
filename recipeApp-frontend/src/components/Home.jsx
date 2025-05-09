import React,{useState} from "react";
import RecipeList from "./RecipeList";
const Home = () => {
    const [recipeCount, setRecipeCount] = useState(0);

    const handleInputChange = (e) => {
        setRecipeCount(e.target.value);
    }
    return (
        <div className="is-flex is-flex-direction-column">
            <div className="container">
                <div className="container 
                    is-max-tablet
                    is-flex 
                    is-justify-content-center
                    is-align-content-center
                ">
                    <div className="card" style={{gap:"20px"}}>
                        <h1 className="is-size-3">Recipe Generator</h1>

                        <div className="is-flex" style={{ width:"400px" }}>
                            <input
                                className="input is-normal"
                                type="text"
                                placeholder="Enter Count"
                                onChange={handleInputChange}
                            />
                            <button className="button is-primary">Get Recipes</button>
                        </div>

                    </div>
                </div>
            </div>
            <div className="container" style={{padding:"20px 0"}}>

                {/* the recipe list will go here */}
                <div className="container is-max-tablet">
                    {/* Here is the styling for each recipe, you can delete and replace */}
                    <RecipeList count={recipeCount} />
                </div>
            </div>
        </div>
    )
}

export default Home;