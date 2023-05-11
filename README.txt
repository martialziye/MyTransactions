For strarting the project,make sure you have the .NET Core SDK(.Net 7) installed on your machine. If you haven't installed it yet, you can download and install it from the official website: https://dotnet.microsoft.com/download/dotnet-core

Open a terminal (command prompt or PowerShell on Windows, Terminal on macOS/Linux).

Navigate to the directory containing your ASP.NET Core Web API project. For example:

cd path/to/your/project

Run the following command to restore any missing NuGet packages and build the project:

dotnet build

After the build is successful, run the following command to start the Web API server:

dotnet run

The Web API server will start, and you should see a message with the URL where the application is running (usually http://localhost:5297).

To test the API, you can use a tool like curl, Postman, or you could use swagger UI that I integreted in the project with the following url "http://localhost:5297/swagger/index.html". 

You can test it by using "http://localhost:5297/api/transactions"as the end point for your postman