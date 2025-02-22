import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import RecipesList from './Pages/RecipesList'
function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <RecipesList />
    </>
  )
}

export default App
