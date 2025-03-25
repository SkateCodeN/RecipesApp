import React,{useState} from "react";
import { Link } from 'react-router-dom';
//import "./Navbar.css";

const Navbar = () => {
    const [isActive,setIsActive] = useState(false);

    const handleToggle = () =>{
        setIsActive( (prev) => !prev);
    }

    return (
        <nav className="navbar" role="navigation" aria-label="main navigation" >
            <div className="navbar-brand">
                <Link to="/" className="navbar-item">
                    Home
                </Link>

                {/* Navbar button/ burger */}
                <button 
                    role="button"
                    className={`navbar-burger ${isActive ? 'is-active' : ''}`}
                    onClick={handleToggle}
                    aria-label="menu"
                    aria-expanded={isActive ? 'true' : 'false'}
                    data-target='navbarMenu'
                >
                    <span aria-hidden="true"></span>
                    <span aria-hidden="true"></span>
                    <span aria-hidden="true"></span>
                </button>

            </div>
            <div id="navbarMenu" className={`navbar-menu ${isActive ? "is-active" : ""}`}>
                <div className="navbar-end">
                        <Link to="/apiRecipe" className="navbar-item">
                            Test 
                        </Link>
                        <Link to="/recipesList" className="navbar-item">
                            Recipes
                        </Link>
                        <Link to="/createRecipe" className="navbar-item">
                            Create Recipe
                        </Link>
                        <Link to="/tasty" className="navbar-item">
                            Tasty
                        </Link>
                </div>
            </div>
        </nav>
    );
}

export default Navbar;
