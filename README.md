# RecipeBookWebApp

A small ASP.NET Core MVC recipe manager built in the same spirit as the JokesWebApp tutorial project from Shad Sluiter.

## Features

- Add recipes
- Edit recipes
- Delete recipes
- View recipe details
- Search by title, category, or ingredient
- Store:
  - recipe title
  - category
  - servings
  - prep time
  - cook time
  - ingredients and measurements
  - instructions
  - notes
  - source / URL
- Automatic total-time calculation
- SQLite database created automatically on first run

## Requirements

- Visual Studio Code 1.136
- ASP.NET and web development workload
- .NET 10 SDK

## Run

1. Open the project folder in Visual Studio Code.
2. Open terminal: View --> Terminal
3. Restore the NuGet packages: dotnet restore
4. Build the project: dotnet build
5. Run the application: dotnet run
6. Open the localhost address shown in the terminal in your web browser.
7. When finished testing, press Ctrl+C in the terminal to stop the application.

The database file `recipes.db` will be created automatically.

## Architecture

This deliberately mirrors the simple MVC structure of the Jokes app:

- `Models/Recipe.cs`
- `Data/ApplicationDbContext.cs`
- `Controllers/RecipesController.cs`
- `Views/Recipes/...`

That makes it useful as a second practice project after the ASP.NET MVC Jokes tutorial.

## Future improvements

Good next steps would be:

- normalized Ingredient and RecipeIngredient tables
- units of measure as structured data
- recipe photos
- tags
- favorites
- authentication / per-user recipe collections
- SQL Server instead of SQLite
- pagination
- ingredient-based filtering

## License

Copyright © 2026 Christopher Bock.

This project is licensed under the MIT License. See the LICENSE file for details.
