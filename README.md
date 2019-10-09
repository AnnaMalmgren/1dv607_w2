# Instructions

The application is written in C# (.NET Core SDK, https://dotnet.microsoft.com/download). The IDE used for development is Visual Studio Code (and extension C# for Visual Studio Code (powered by OmniSharp), https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp.)
External dependencies in the code is NewtonSoft.Json. 

## Run the application

You need to have .Net Core installed, the app is published as a Framework-dependent executable.

Open the folden EXE_win10-x64 and double click on 1dv607_ws.exe.

To compile the code with another runtime use (with CLI):

- Locate to the source code folder in the CLI. 
- write dotnet publish -c Release -r in the CLI
- after -r you enter the runtime you want to publish, ex: dotnet publish -c Release -r win10-x64
(runtime catalog : https://docs.microsoft.com/en-us/dotnet/core/rid-catalog)


