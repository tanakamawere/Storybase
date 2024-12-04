using Storybase.Core;
using Storybase.Core.Interfaces;
using Storybase.Core.Models;

namespace StorybaseApi.Endpoints;

public static class UserEndpoints
{
    public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        //Get User by id
        app.MapGet(EndpointStrings.GetUserById, async Task<Results<Ok<User>, BadRequest>> (IRepository<User> repository, int id) =>
        {
            var User = await repository.GetByIdAsync(id);
            if (User == null)
            {
                return TypedResults.BadRequest();
            }
            return TypedResults.Ok(User);
        });

        //Create a new User
        app.MapPost(EndpointStrings.CreateUser, async Task<Results<Ok<string>, BadRequest>> (IRepository<User> repository, User createUser) =>
        {
            await repository.AddAsync(createUser);
            return TypedResults.Ok("User created successfully");
        });
        //Update a User
        app.MapPut(EndpointStrings.UpdateUser, async Task<Results<Ok<string>, BadRequest>> (IRepository<User> repository, User updateUser) =>
        {
            await repository.UpdateAsync(updateUser);
            return TypedResults.Ok("User updated successfully");
        });
        //Delete
        app.MapDelete(EndpointStrings.DeleteUser, async Task<Results<Ok<string>, BadRequest>> (IRepository<User> repository, int id) =>
        {
            await repository.DeleteAsync(id);
            return TypedResults.Ok("User deleted successfully");
        });
        //Search
        app.MapGet(EndpointStrings.SearchUsers, async Task<Results<Ok<IEnumerable<User>>, BadRequest>> (IRepository<User> repository, string query) =>
        {
            var Users = await repository.SearchAsync(query);
            return TypedResults.Ok(Users);
        });
        //Get all users
        app.MapGet(EndpointStrings.GetAllUsers, async Task<Results<Ok<IEnumerable<User>>, BadRequest>> (IRepository<User> repository) =>
        {
            var Users = await repository.GetAllAsync();
            return TypedResults.Ok(Users);
        });

        return app;
    }
}
