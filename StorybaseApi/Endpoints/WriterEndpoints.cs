using Storybase.Core;
using Storybase.Core.Interfaces;
using Storybase.Core.Models;

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
        app.MapPost(EndpointStrings.CreateWriter, async Task<Results<Ok<string>, BadRequest>> (IWriterRepository repository, Writer createWriter) =>
        {
            await repository.AddAsync(createWriter);
            return TypedResults.Ok("Writer created successfully");
        });
        //Update a Writer
        app.MapPut(EndpointStrings.UpdateWriter, async Task<Results<Ok<string>, BadRequest>> (IWriterRepository repository, Writer updateWriter) =>
        {
            await repository.UpdateAsync(updateWriter);
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
        app.MapGet(EndpointStrings.GetWriterLiteraryWorks, async Task<Results<Ok<IEnumerable<LiteraryWork>>, BadRequest>> (IWriterRepository repository, int writerId) =>
        {
            var literaryWorks = await repository.GetLiteraryWorksAsync(writerId);
            return TypedResults.Ok(literaryWorks);
        });

        return app;
    }
}
