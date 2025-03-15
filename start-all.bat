@echo off

REM Start the NET core backend in a new window
start dotnet run --project ./

REM Change directory to the frontend folder
cd recipeApp-frontend


REM Start the vite dev server 
start npm run dev

REM keep command line window open
pause
