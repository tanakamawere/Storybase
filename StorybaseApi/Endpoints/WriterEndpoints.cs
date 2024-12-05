using Storybase.Core;
using Storybase.Core.DTOs;
using Storybase.Core.Interfaces;
using Storybase.Core.Models;
using StorybaseApi.Repositories;

namespace StorybaseApi.Endpoints;

public static class WriterEndpoints
{
    public static IEndpointRouteBuilder MapWriterEndpoints(this IEndpointRouteBuilder app)
    {
        //Get Writer by id
        app.MapGet(EndpointStrings.GetWriterById, async Task<Results<Ok<Writer>, BadRequest>> (IWriterRepository repository, int id) =>
        {
            var Writer = await repository.GetByIdAsync(id);
            if (Writer == null)
            {
                return TypedResults.BadRequest();
            }
            return TypedResults.Ok(Writer);
        });

        //Create a new Writer
        app.MapPost(EndpointStrings.CreateWriter, async Task<Results<Ok<string>, BadRequest>> (IWriterRepository repository, IUserRepository userRepository, WriterDto createWriter) =>
        {
            //Get user object from db from Auth0UserId
            User user = await userRepository.GetByAuth0UserIdAsync(createWriter.Auth0UserId);

            Writer writer = new()
            {
                UserId = createWriter.UserId,
                UserName = createWriter.UserName,
                User = user,
                Bio = createWriter.Bio,
                ContactInfo = createWriter.ContactInfo
            };

            await repository.AddAsync(writer);
            return TypedResults.Ok("Writer created successfully");
        });
        //Update a Writer
        app.MapPut(EndpointStrings.UpdateWriter, async Task<Results<Ok<string>, BadRequest>> (IWriterRepository repository, IUserRepository userRepository, WriterDto updateWriter) =>
        {
            //Get user object from db from Auth0UserId
            User user = await userRepository.GetByAuth0UserIdAsync(updateWriter.Auth0UserId);

            //Update the writer object
            Writer writer = new()
            {
                Id = updateWriter.Id,
                UserId = updateWriter.UserId,
                UserName = updateWriter.UserName,
                User = user,
                Bio = updateWriter.Bio,
                ContactInfo = updateWriter.ContactInfo
            };

            await repository.UpdateAsync(writer);
            return TypedResults.Ok("Writer updated successfully");
        });
        //Delete
        app.MapDelete(EndpointStrings.DeleteWriter, async Task<Results<Ok<string>, BadRequest>> (IWriterRepository repository, int id) =>
        {
            await repository.DeleteAsync(id);
            return TypedResults.Ok("Writer deleted successfully");
        });
        //Search
        app.MapGet(EndpointStrings.SearchWriters, async Task<Results<Ok<IEnumerable<Writer>>, BadRequest>> (IWriterRepository repository, string query) =>
        {
            var Writers = await repository.SearchAsync(query);
            return TypedResults.Ok(Writers);
        });
        //Get writers literary works
        app.MapGet(EndpointStrings.GetWriterLiteraryWorks, async Task<Results<Ok<IEnumerable<LiteraryWork>>, BadRequest>> (IWriterRepository repository, int id) =>
        {
            var literaryWorks = await repository.GetLiteraryWorksAsync(id);
            return TypedResults.Ok(literaryWorks);
        });
        //Check if username is taken
        app.MapGet(EndpointStrings.IsUserNameTaken, async Task<Results<Ok<bool>, BadRequest>> (IWriterRepository repository, string userName) =>
        {
            var isTaken = await repository.IsUserNameTakenAsync(userName);
            return TypedResults.Ok(isTaken);
        });
        //Check if the user already has a writer profile
        app.MapGet(EndpointStrings.HasWriterProfile, async Task<Results<Ok<bool>, BadRequest>> (IWriterRepository repository, string userId) =>
        {
            var hasProfile = await repository.HasWriterProfileAsync(userId);
            return TypedResults.Ok(hasProfile);
        });

        return app;
    }
}
