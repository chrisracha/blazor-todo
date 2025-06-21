# Blazor To-Do App

### A modern, interactive Todo list application built with Blazor Server that allows users to manage their tasks in real-time.
![To-Do](https://raw.githubusercontent.com/chrisracha/blazor-todo/refs/heads/main/sample.png)
----
#### Features

*	User Authentication
*	Complete identity system with login, registration, and account management
*	Password reset functionality
*	Todo Management
*	Create, read, update, and delete todo items
*	Mark items as complete/incomplete with real-time updates
*	User-specific todo lists
*	Changes sync automatically across browser sessions

#### Prerequisites

* .NET 9.0 SDK
* SQL Server (LocalDB or full instance)
* Visual Studio 2022 (recommended) or compatible IDE

#### Installation

1.  Clone the repository
    ```bash
    git clone [https://github.com/yourusername/TestApp.git](https://github.com/yourusername/TestApp.git)
    cd TestApp
    ```
2.  Update the connection string in `appsettings.json`
3.  Apply migrations
    ```bash
    dotnet ef database update
    ```
4.  Run the application
    ```bash
    dotnet run
    ```
