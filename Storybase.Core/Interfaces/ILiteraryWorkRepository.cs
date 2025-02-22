﻿using Storybase.Core.DTOs;
using Storybase.Core.Models;

namespace Storybase.Core.Interfaces;

public interface ILiteraryWorkRepository : IRepository<LiteraryWork>
{
    Task<IEnumerable<LiteraryWork>> GetByGenreAsync(int genreId);
    Task<IEnumerable<LiteraryWork>> GetByTypeAsync(LiteraryWorkType type);
    Task<IEnumerable<LiteraryWork>> GetByAuthorAsync(int authorId);
    Task AddDtoAsync(LiteraryWorkDto entity);
    Task UpdateDtoAsync(LiteraryWorkDto entity);
    Task SoftDelete(int id);
    Task Unarchive(int id);
}

