# Welcome, friend!

Thank you for consulting my repository. This repository includes various projects showcasing handy implementations, best practices and general tips and tricks to help you on your way using .NET (core), databases and Docker.

As of now you will find 2 projects in this repository that will help you get started. A nice and cozy API, as well as a database. Both projects are meant to be ran as Docker containers.


## Requirements
These projects may require the following to run:
- Docker
- Dot Net (Core 6.0) SDK('s)

Additionally I use the following tools:
- Visual Studio (Code)
- SQL Server Management Studio
Note: Feel free to use any other tools that get the job done if preferred.

## Projects
This repository is meant to be used as perrsonal documentation and as a showcase for people who may not yet have experience in the topics discussed. I will do my best to split projects into smaller pieces and fit together bigger projects that will put the pieces together in a nice lifelike sample.
Note: Not every detail is split into it's own project.

### API(s)
Here you will find all APIs that are included in this project. I will do my best to name the APIs closely to their intent. You will also find a General API that will be a sum of all parts. 

#### GeneralAPI
This API is the sum of all parts. It is a dockerized API that communicates with a dockerized database.

Build instructions:
1. docker build --rm -t *<iskelmaikels_playground/isk.generalapi>*:latest .
2. docker run --rm -p 5000:5000 -p 5001:5001 -e ASPNETCORE_HTTP_PORT=https://+:5001  -e ASPNETCORE_HTTP_URLS=http://+:5000 *<iskelmaikels_playground/isk.generalapi>*
3. Run a browser and navigate to localhost:5000/Weatherforecase to see the sample api
### Database(s)

Currently there is only one database. It is dockerized and can be run with the following command(s):
1. docker build -t *<iskelmaikels_playground/isk.generalapidb>* .
2. docker run -d -p 1433:1433 --name mssqldb_generated *<iskelmaikels_playground/isk.generalapidb>*:latest
Note: the image name parameter can be changed to fit your needs.

### Website(s)
Not yet implemented.



Finally, references for sources used:
- https://stackedit.io/app#

