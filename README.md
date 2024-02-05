
# Movies API

Api create for evaluation purpose. Below you will find assessment's requirements.

## Authors

- [@gonzaferrando](https://www.github.com/gonzaferrando)

## Tech Stack

Net Core 6, Entity Framework (Code First), InMemory Database.

## Assessment requirements

Please create a .Net 6 Web Api for managing a list of movies, which allows you to view and edit information about Movies, Actors, and Movie Ratings.

Backend Requirements:

● Have endpoints that allow you to create, retrieve, update, and delete records

● Use Entity Framework Core (in-memory db, sqlite, whatever you want), with a code first approach, for CRUD (Create Retrieve Update Delete) operations and the database should be seeded with some dummy data

● Have at least 3 entity types:

○ Movies

○ Actors

○ MovieRatings

and they should have the appropriate relationships with each other.
For example, a Movie could have a list of actors or a list of ratings or no ratings.

● Must expose a swagger endpoint, with full documentation for each API endpoint

● Must allow you to do partial searches for Movies or Actors, based on name.

● Must be able to view all Movies an Actor has been in, and list all Actors in a given Movie.

● Must require an API secret/token and validate it, when trying to Create/Update/Delete entities via corresponding API endpoints. Searching/listing shouldn't check for the API token/secret. You can hard code the secret.

● Properly validate requests and return appropriate HTTP responses and response codes, based on the invocation result (ie: if an error happened or if trying to access a restricted endpoint, without the API secret, the right HTTP code is returned)

