import { BrowserRouter, Route,Routes} from 'react-router-dom'

import RecipesList from './Pages/RecipesList'
import CreateRecipe from './Pages/CreateRecipe'
import Navbar from './components/Navbar'
import Home from './components/Home'
import ApiRecipe from './Pages/ApiRecipe'
import TastyAPI from "./Pages/TastyAPI";
import AIRecipe from './Pages/AIRecipe'
import AiDbRecipe from './Pages/AiDbRecipe'
import TastyRecipeSearch from './Pages/TastyRecipes'
function App() {

  return (
    <div >
      <BrowserRouter>
        <Navbar />
        
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/recipesList" element={<RecipesList />} />
          <Route path="/createRecipe" element={<CreateRecipe />} />
          <Route path='/apiRecipe' element={<ApiRecipe />} />
          <Route path='/tasty' element={<TastyAPI />} />
          <Route path='/aiDbRecipes' element={<AiDbRecipe />} />
          <Route path='/aiRecipes' element={<AIRecipe />} />
          <Route path='/searchTasty' element={ <TastyRecipeSearch />} />
        </Routes>
      </BrowserRouter>
      
    </div>
  )
}

export default App
