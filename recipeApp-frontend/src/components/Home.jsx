

const Home = () => {
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
                    <div className="card is-flex">
                        <div style={{width:"60%",backgroundColor:"red"}}>
                            <h2>Recipe Name</h2>
                        </div>
                        
                        <div style={{width:"30%",backgroundColor:"blue"}}>
                            <h3>Monday</h3>
                        </div>
                        
                        <div className="is-flex" style={{gap:"10px"}}>
                            <button 
                                className="button is-danger" 
                                type="button"
                                title="delete recipe"
                            >
                                <img src='../../src/assets/delete.png' width={"20px"} />
                            </button>
                            <button 
                                title="replace recipe"
                                className="button is-warning" 
                                type="button"
                            >
                                <img src='../../src/assets/replace.png' width={"20px"} />
                            </button>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    )
}

export default Home;