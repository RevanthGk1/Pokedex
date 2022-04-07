=========================================================================

System Requirements:

For running the project on local machine:

    .NET SDK - 6.0 - Dowload here: https://dotnet.microsoft.com/en-us/download

For running the Docker container:

    Docker : Download here: https://docs.docker.com/get-docker/

==========================================================================

Running the Project

1. Dowload the project source code from Github.
2. Navigate to the "RunProject" folder in the downloaded Pokedex project. 

Windows local machine:

    One Step Set up: Execute the "RunPokedex_Local.bat" file.
    
    (or Run the below commands manually - Path: Pokedex)
    
    dotnet build
    
    dotnet run --urls=http://localhost:5000/ 
    
    
	
Docker:

    One Step Set up: Execute the "RunPokedex_Docker.bat" file.
    
    (or Run the below commands manually - Path: Pokedex\Pokedex)
    
    docker build -t pokedex:v1 .
    
    docker run -it --rm -p 5000:80 pokedex:v1
    
	

Accessing the Endpoints:


If chrome is installed, execute the "StartChrome.bat" file to open chrome with proper url Or Open the preferred browser with below urls.

		For Swagger:  http://localhost:5000/swagger/index.html
    
		For accessing the Api:
    
			Endpoint 1 : Getting Pokemon Details with standard description: 
			http://localhost:5000/Pokemon/v1/Standard/<PokemonName>
			Ex:http://localhost:5000/Pokemon/v1/Standard/onix

			Endpoint 2 : Getting Pokemon Details with modified/translated description: 
			http://localhost:5000/Pokemon/v1/Translated/<PokemonName>
			Ex:http://localhost:5000/Pokemon/v1/Translated/onix
	

=============================================================================
