=============================================================================

System Requirements:

For running the project on local machine:

    .NET SDK - 6.0 - Dowload here: https://dotnet.microsoft.com/en-us/download

For running the Docker container:

    Docker : Download here: https://docs.docker.com/get-docker/

==============================================================================

Running the Project

1. Dowload the project source code from Github: https://github.com/RevanthGk1/Pokedex-Challenge-Pvt-Rep.git
2. Navigate to the "RunProject" folder in the downloaded Pokedex project. 

Windows local machine:

    Execute the "RunPokedex_Local.bat" file.
	
Docker:

    Execute the "RunPokedex_Docker.bat" file.
	

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
	

=================================================================================
