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


Executing Unit Tests & Generating Code Coverage Results in XML:

Navigate to path: Pokedex\Pokedex.Tests  and execute below command:

	dotnet test --collect:"XPlat Code Coverage"

The above command creates a folder "TestResults" and nested unique folder with coverage.cobertura.xml


=============================================================================

**Things that could be different for production:**

1. Have a different config for production (appsettings.production.json & appsettings.development.json)
	Maintain different connection strings/Urls/Generic Error templates
2. Some level of authorization (may be token based) just to avoid/slow down DDOS attacks.
3. Coordinate with the external API team to get better StatusCodes and messages in the response.
4. Use of third party Caching service/DB like MemCache/Redis etc. instead of InMemory Cache.
5. Have proper Logging layer (into DB)
6. Have all the static values like External Endpoints, Special values etc in the Database rather than appsettings.json file for the flexibility to modify them when needed.
7. Errors showing up with stack trace when error/exceptions occur in dev environment but in production 
	I would just give out errors with statuscode & message externally but logging into DB for later use for devs.
8. Log the Performance Metrics for API : Latency, Requests per minute, Failure rate.,
	For this we could maintain a API-Monitoring tool internally or there are also many tools available in the market.
9. Set-Up auto-scaling in the server (in prometheus/Nginx etc)


Design Decisions:

-> All the Errors/Exception shall be handled by the ExceptionFilter on the controller and stack trace to be logged for errors.

-> Stack trace showing up related to "Internal Server Error" is curbed deliberately. Just a Status Code of 500 is shown to the consumer. But the stack trace is logged.

=============================================================================




