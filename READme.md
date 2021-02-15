## Description

Session control for [ASPNET-CORE-MVC-AOP-APP](https://github.com/cenkgokturk/ASPNET-CORE-MVC-AOP-APP). When a user logins, session is written to the database and a token is generated. Later on, when user wants to access the profile page, user's info is retrieved using the token.

## Features

- Set a new session for the given user
- Return a user using the session token
- 

## How to Install

1. Install [ASPNET-CORE-MVC-AOP-APP](https://github.com/cenkgokturk/ASPNET-CORE-MVC-AOP-APP) and follow all the given steps
2. Download the Session app from GitHub
3. Open the app in Visual Studio 
4. Open Microsoft SQL Server Managment Studio
5. Connect to your local SQL Server
6. Under the database created in the main project, execute the following queries to create necessary table

    ```java
    CREATE TABLE UserSessions(
    	ID INT IDENTITY PRIMARY KEY,
    	Usermail nvarchar(100),
    	LoginDate nvarchar(100),
    	IsLoggedIn INT
    );
    ```

7. Select Add → Project Reference after right clicking onn ASPNETAOP
8. Choice the ASPNETAOP-Session project and click on