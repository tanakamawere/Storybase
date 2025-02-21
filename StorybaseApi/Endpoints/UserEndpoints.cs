using Storybase.Core;
using Storybase.Core.DTOs;
using Storybase.Core.Interfaces;
using Storybase.Core.Models;

namespace StorybaseApi.Endpoints;

public static class UserEndpoints
{
    public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        //Get User by id
        app.MapGet(EndpointStrings.GetUserById, async Task<Results<Ok<User>, BadRequest>> (IUserRepository repository, int id) =>
        {
            var User = await repository.GetByIdAsync(id);
            if (User == null)
            {
                return TypedResults.BadRequest();
            }
            return TypedResults.Ok(User);
        });

        //Create a new User
        app.MapPost(EndpointStrings.CreateUser, async Task<Results<Ok<string>, BadRequest>> (IUserRepository repository, User createUser) =>
        {
            await repository.AddAsync(createUser);
            return TypedResults.Ok("User created successfully");
        });
        //Update a User
        app.MapPut(EndpointStrings.UpdateUser, async Task<Results<Ok<string>, BadRequest>> (IUserRepository repository, User updateUser) =>
        {
            await repository.UpdateAsync(updateUser);
            return TypedResults.Ok("User updated successfully");
        });
        //Delete
        app.MapDelete(EndpointStrings.DeleteUser, async Task<Results<Ok<string>, BadRequest>> (IUserRepository repository, int id) =>
        {
            await repository.DeleteAsync(id);
            return TypedResults.Ok("User deleted successfully");
        });
        //Search
        app.MapGet(EndpointStrings.SearchUsers, async Task<Results<Ok<IEnumerable<User>>, BadRequest>> (IUserRepository repository, string query) =>
        {
            var Users = await repository.SearchAsync(query);
            return TypedResults.Ok(Users);
        });
        //Get all users
        app.MapGet(EndpointStrings.GetAllUsers, async Task<Results<Ok<IEnumerable<User>>, BadRequest>> (IUserRepository repository) =>
        {
            var Users = await repository.GetAllAsync();
            return TypedResults.Ok(Users);
        });
        //Check if user exists
        app.MapPost(EndpointStrings.CheckIfUserExists, async Task<Results<Ok<bool>, BadRequest>> (IUserRepository repository, UserDto user) =>
        {
            var response = await repository.CheckIfUserExistsAsync(user);
            if (response)
            {
                return TypedResults.Ok(true);
            }
            return TypedResults.Ok(false);
        });

        return app;
    }
}
