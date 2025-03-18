import { BrowserRouter, Route,Routes} from 'react-router-dom'

import RecipesList from './Pages/RecipesList'
import CreateRecipe from './Pages/CreateRecipe'
import Navbar from './components/Navbar'
import Home from './components/Home'
function App() {

  return (
    <div >
      <BrowserRouter>
        <Navbar />
        
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/recipesList" element={<RecipesList />} />
          <Route path="/createRecipe" element={<CreateRecipe />} />
        </Routes>
      </BrowserRouter>
      
    </div>
  )
}

export default App
