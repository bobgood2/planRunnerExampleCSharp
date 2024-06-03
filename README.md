# planRunnerExampleCSharp

This example runs a client and a server, with a trivial implementation of what you might want to do on the client side.  The only file you should change is Program.cs, and the server should be unmodified, and the client library should be unchanged.

But you can add more API entry points, and try different kinds of plans with this set up, and see how it works.


# Set up the python server that executes plans
Install Python.
Download this repo

Set up server...
* cd C:\repos\planRunnerExampleCSharp\Plan_Server
create a virtual environment and activate it (recommended)
* python -m venv env
* env\Scripts\activate

install plan runner package and other needed requirements:
* pip install "ast_transform @ git+https://github.com/goodw21985/ApiConductor.git@master#egg=ast_transform&subdirectory=AstTransformation"


run the server
* python Plan_Server.py

you should see this printed:
2024-06-03 14:40:58,182 - ApiConductorServer - INFO - websockets started

# Run the c# client
open the solution downloaded from the repo in visual studio
set Plan_Client as the startup project
run the program

on the server you will see:

2024-06-03 14:41:56,999 - ApiConductorServer - INFO - exec code started
2024-06-03 14:41:57,000 - ApiConductorServer - INFO - call request: _C0 = search_email(a=2)
2024-06-03 14:41:57,044 - ApiConductorServer - INFO - completion _C0: 102
2024-06-03 14:41:57,045 - ApiConductorServer - INFO - call request: _C2 = search_email(a=112)
2024-06-03 14:41:57,048 - ApiConductorServer - INFO - completion _C2: 212
2024-06-03 14:41:57,049 - ApiConductorServer - INFO - return: 212
2024-06-03 14:41:57,050 - ApiConductorServer - INFO - exec code complete

# Notes

AppConductorClient is meant to be a distribution with the package, meaning that as the server API changes, so will this library.
Program.cs is the code that gets integrated into your application



