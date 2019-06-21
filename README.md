# Introduction 
An application used to manage carpools for your company. This is the backend API half of the system. The WebClient is a separate project. With some setup and code changes, Carpül can become your company's carpool management tool. This app is the API  Carpül is powered by the following technologies:
1.	ASP .Net Core 2.2
2.	ApplicationInsights for tracing and logging
3.	Swagger API interface
4.	JWT authentication
5.	Moq testing framework
6.	.Net core dependency injection
7.	Entity Framework Core

# Build and Test
Setup needed config changes in the appsettings.json file, open in Visual Studio, and run the solution.

This project was built by a team of three developers for their senior capstone project at Oregon State University.

# Considerations
One big piece that is missing that I would definitely add if given more time was password hashing. As of now the authentication assumes clear-text passwords in the database, which we all know is a huge security-flaw. Password hashing may come in the future, or in another project.
