import React from "react";
import { Link } from 'react-router-dom';
//import "./Navbar.css";

const Navbar = () => {
    return (
        <nav className="navbar" role="navigation" aria-label="main navigation" >
            <div className="navbar-brand">
                <Link to="/" className="navbar-item">
                    Home
                </Link>
            </div>
            <div className="navbar-menu">
                <div className="navbar-end">
                        <Link to="/" className="navbar-item">
                            Home
                        </Link>
                        <Link to="/recipesList" className="navbar-item">
                            Recipes
                        </Link>
                        <Link to="/createRecipe" className="navbar-item">
                            Create Recipe
                        </Link>
                </div>
            </div>
        </nav>
    );
}

export default Navbar;
