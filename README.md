# RecipesApp
This is the classic Recipe App that is the MVP to something more. ASP .NET Core 8 Backend with Vite React Frontend

1.Run dotnet rebuild to build app in terminal

2.go to recipeApp-frontend and run npm install

3. Run the docker-compose file in folder docker-db
    after creating a db.env file. 
Created some scripts to run both fronend and 


Run scripts to start the application:

Note for #3 you have to create a db.env file inside the docker-db folder
create the following variables with your desired settings
POSTGRES_DB=[your_db_name]
POSTGRES_USER=[your_username]
POSTGRES_PASSWORD=[your_password]

For the ai db you will also need the following: 

TODO: 

then in the terminal head over to /docker-db and run the docker-composer file with
    docker-compose up -d 

3/14/2025
    Linux:

    Implemented a shell script to run both and backend

    to run you must first make the shell script executable
    with:
        chmod +x start-all.sh
    
    run with the following command: 
        ./start-all

    ###########################################################

    Windows: 

    First create an env.bat file in the root of the app
    create the following two variables 
    coreAppPath 
    vitePath 

    the file should look like this :
    -----------------------------------------------------------
    @echo off
    set coreAppPath =""
    set vitePath=""
    -----------------------------------------------------------
    use the following command:
    start start-all.bat

4/14/2025
TODO: Lets build the structure as well ie lets make sure we have a roadmap of 
where we want to take this, we need an MVP drawn out

-We need to create a suggester that takes a random numbe of recipes 

4/21/2025
-I have been creating recipes with some descriptions

4/22/More nonsense since I have been coding quite a lot on VB.net and at work, also
I have been studying for .Net core

4/23/25 I have been uploading more recipes, some mock and some that are not 
to the database using the webapp. SO that should count for updates made for this app.

4/24/25 
Kein Bock man, its hard to continue to write code this week

4/25/25
Have been studying PHP, will probably keep until interview

4/26/25
Nothing new we keep studying

4.27.25 
I have been talking to ChatGPT voice to make sure I get terminology correct and
and can explain different technologies with a firm grasp of the positives and
negatives of each.

4/28/25
Had a great interview for transcat, it was Bret Smith, the engineering manager 
that I had a conversation with. The flow was great and we really got into a 
relaxed tone. He was positive that I was the right fit and even said I would be 
his top choice. That felt great.

5/2/25
Stopped for a while now I needed to get back in the game.So hopefully, here I am 

5/3/25
Still no desire to code on this, will have to come back and make sure I at least continue to update it. I am creating new recipes so there is that.

5/4/25
no new update

5/5/25
Almost there