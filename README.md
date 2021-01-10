# Example .NET Core Api Solution
This is an example .NET Core API solution which can be used as a starting point for people to look at when they want to create their own API solution using .NET Core.  
It showcases real world uses for the following:
* .NET Core API
* Swagger
* Entity Framework
* Fluent Validation
* Auto Mapper
* Blob Storage
* xUnit, Mock, and Fluent Assertions
* The Repository Pattern

Before running it is required to have a Local SQL DB, the connection string must then be added in to appsettings.json. as per below.
```json
	  "ConnectionStrings": {
            "ClientContext": "Replace with a local SQL DB connection string"
         },
```
It is also required to download and run the Azure Storage Emulator which can be found [here](https://docs.microsoft.com/en-us/azure/storage/common/storage-use-emulator).  

A person looking to improve and take this solution further could do the following:
* Tests, Tests, Tests
* Add a PUT endpoint for updating details
* Improve/add error handling
* Extend functionality - for example the blob stoarge uploader is fairly simple, how about taking the data from the CSV files and then saving them to the DB before uploading to blob storage?
* Make the code more DRY (especially in the repository)
* Add a front end to replace Swagger
* Add Authentication to the API endpoints
