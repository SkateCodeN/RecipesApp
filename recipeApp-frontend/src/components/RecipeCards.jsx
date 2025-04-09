// This can take in a Json for those tasty recipe API and output a
// card list of those recipes
import './RecipeCards.css'
const RecipeCards = ({ recipes }) => {

    return (
        <div className="grid is-col-min-15" style={{margin:"20px 0"}}>

            {recipes.results && recipes.results.map((recipe) => (
                <div className="cell" key={recipe.name}>
                    <div  className='card' style={{ width: "400px" }}>
                        <div className='card-img' >
                            <figure className='image is-4by3"'>
                                <img src={recipe.thumbnail_url}
                                    alt={recipe.slug}
                                    style={{height:"400px"}}
                                />
                            </figure>
                        </div>

                        <div className='card-content '>
                            <div className='media'>
                                <div className='media-content is-flex is-align-items-center' style={{height:"70px"}}>
                                    <p className='title is-4'>{recipe.name}</p>
                                </div>
                            </div>

                            <div className='content scrollable-content' style={{height:"200px"}} >
                                {recipe.description}
                            </div>

                        </div>
                        <footer className='card-footer'>

                            <a href="#" className="card-footer-item">Add</a>
                            <a href="#" className="card-footer-item">Edit</a>
                            <a href="#" className="card-footer-item">Delete</a>
                        </footer>

                    </div>
                </div>

            ))}

        </div>

    )
}

export default RecipeCards;