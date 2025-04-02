
const Recipe = () => {


    return (
        <div className="card is-flex">
            <div style={{ width: "60%", backgroundColor: "red" }}>
                <h2>Recipe Name</h2>
            </div>

            <div style={{ width: "30%", backgroundColor: "blue" }}>
                <h3>Monday</h3>
            </div>

            <div className="is-flex" style={{ gap: "10px" }}>
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
    )
}

export default Recipe;