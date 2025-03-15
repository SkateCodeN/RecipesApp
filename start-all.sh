#!/bin/bash

# run the backend
dotnet run --project ./RecipesApp &

#run the frontend
cd ./recipeApp-frontend && npm run dev  &

# wait for background processes.
wait
