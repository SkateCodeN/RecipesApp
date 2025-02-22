import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import RecipesList from './Pages/RecipesList'
import CreateRecipe from './Pages/CreateRecipe'
function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <CreateRecipe />
    </>
  )
}

export default App
