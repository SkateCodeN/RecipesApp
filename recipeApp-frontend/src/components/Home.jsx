const Home = () => {
    return (
        <>
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
        </>
    )
}

export default Home;