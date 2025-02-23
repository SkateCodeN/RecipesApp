import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import { BrowserRouter, Route,Routes} from 'react-router-dom'
import './App.css'
import RecipesList from './Pages/RecipesList'
import CreateRecipe from './Pages/CreateRecipe'
import Navbar from './components/Navbar'
import Home from './components/Home'
function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <BrowserRouter>
        <Navbar />
        
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/recipesList" element={<RecipesList />} />
          <Route path="/createRecipe" element={<CreateRecipe />} />
        </Routes>
      </BrowserRouter>
      
    </>
  )
}

export default App
