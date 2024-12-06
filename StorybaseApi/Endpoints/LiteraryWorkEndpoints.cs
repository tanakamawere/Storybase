using Storybase.Core;
using Storybase.Core.Interfaces;
using Storybase.Core.Models;

namespace StorybaseApi.Endpoints;

public static class LiteraryWorkEndpoints
{
    public static IEndpointRouteBuilder MapLiteraryWorkEndpoints(this IEndpointRouteBuilder app)
    {
        //Get literary work by id
        app.MapGet(EndpointStrings.GetLiteraryWorkById, async Task<Results<Ok<LiteraryWork>, BadRequest>> (ILiteraryWorkRepository repository, int id) =>
        {
            var literaryWork = await repository.GetByIdAsync(id);
            if (literaryWork == null)
            {
                return TypedResults.BadRequest();
            }
            return TypedResults.Ok(literaryWork);
        });

        //Create a new literary work
        app.MapPost(EndpointStrings.CreateLiteraryWork, async Task<Results<Ok<string>, BadRequest>> (ILiteraryWorkRepository repository, LiteraryWork createLiteraryWork) =>
        {
            await repository.AddAsync(createLiteraryWork);
            return TypedResults.Ok("Literary work created successfully");
        });
        //Update a literary work
        app.MapPut(EndpointStrings.UpdateLiteraryWork, async Task<Results<Ok<string>, BadRequest>> (ILiteraryWorkRepository repository, LiteraryWork updateLiteraryWork) =>
        {
            await repository.UpdateAsync(updateLiteraryWork);
            return TypedResults.Ok("Literary work updated successfully");
        });
        //Delete
        app.MapGet(EndpointStrings.DeleteLiteraryWork, async Task<Results<Ok<string>, BadRequest>> (ILiteraryWorkRepository repository, int id) =>
        {
            await repository.DeleteAsync(id);
            return TypedResults.Ok("Literary work archived successfully");
        });
        //Unarchive
        app.MapGet(EndpointStrings.UnarchiveLiteraryWork, async Task<Results<Ok<string>, BadRequest>> (ILiteraryWorkRepository repository, int id) =>
        {
            await repository.Unarchive(id);
            return TypedResults.Ok("Literary work unarchived successfully");
        });
        //Search
        app.MapGet(EndpointStrings.SearchLiteraryWorks, async Task<Results<Ok<IEnumerable<LiteraryWork>>, BadRequest>> (ILiteraryWorkRepository repository, string query) =>
        {
            var literaryWorks = await repository.SearchAsync(query);
            return TypedResults.Ok(literaryWorks);
        });
        //Get all literary works
        app.MapGet(EndpointStrings.GetAllLiteraryWorks, async Task<Results<Ok<IEnumerable<LiteraryWork>>, BadRequest>> (ILiteraryWorkRepository repository) =>
        {
            var literaryWorks = await repository.GetAllAsync();
            return TypedResults.Ok(literaryWorks);
        });
        //Get literary works by genre
        app.MapGet(EndpointStrings.GetByGenre, async Task<Results<Ok<IEnumerable<LiteraryWork>>, BadRequest>> (ILiteraryWorkRepository repository, int genreId) =>
        {
            var literaryWorks = await repository.GetByGenreAsync(genreId);
            return TypedResults.Ok(literaryWorks);
        });
        //Get literary works by author
        app.MapGet(EndpointStrings.GetByAuthor, async Task<Results<Ok<IEnumerable<LiteraryWork>>, BadRequest>> (ILiteraryWorkRepository repository, int authorId) =>
        {
            var literaryWorks = await repository.GetByAuthorAsync(authorId);
            return TypedResults.Ok(literaryWorks);
        });
        //Get literary works by type
        app.MapGet(EndpointStrings.GetByType, async Task<Results<Ok<IEnumerable<LiteraryWork>>, BadRequest>> (ILiteraryWorkRepository repository, LiteraryWorkType type) =>
        {
            var literaryWorks = await repository.GetByTypeAsync(type);
            return TypedResults.Ok(literaryWorks);
        });


        return app;
    }
}
