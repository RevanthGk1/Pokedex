@echo off
cd..
cd Pokedex
dotnet build
dotnet run --urls=http://localhost:5000/ 
pause
::& start chrome "https://localhost:7293/swagger/index.html"