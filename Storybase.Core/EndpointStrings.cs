﻿namespace Storybase.Core;

public class EndpointStrings
{
    //LiteraryWorkPurchase Endpoints
    public const string GetPurchaseById = "api/purchases/getpurchase";
    public const string CreatePurchase = "api/purchases/create";
    public const string UpdatePurchase = "api/purchases/update";
    public const string DeletePurchase = "api/purchases/delete";
    public const string SearchPurchases = "api/purchases/search";
    public const string GetAllPurchases = "api/purchases";

    //Bookmarks Endpoints
    public const string GetBookmarkById = "api/bookmarks/getbookmark";
    public const string CreateBookmark = "api/bookmarks/create";
    public const string UpdateBookmark = "api/bookmarks/update";
    public const string DeleteBookmark = "api/bookmarks/delete";
    public const string SearchBookmarks = "api/bookmarks/search";

    //User Endpoints
    public const string GetUserById = "api/users/getuser";
    public const string CreateUser = "api/users/create";
    public const string UpdateUser = "api/users/update";
    public const string DeleteUser = "api/users/delete";
    public const string SearchUsers = "api/users/search";
    public const string GetAllUsers = "api/users";

    //Chapter Endpoints
    public const string GetChapterById = "api/chapters/getchapter";
    public const string CreateChapter = "api/chapters/create";
    public const string UpdateChapter = "api/chapters/update";
    public const string DeleteChapter = "api/chapters/delete";
    public const string SearchChapters = "api/chapters/search";

    //Writer endpoints
    public const string GetWriterById = "api/writers/getwriter";
    public const string CreateWriter = "api/writers/create";
    public const string UpdateWriter = "api/writers/update";
    public const string DeleteWriter = "api/writers/delete";
    public const string SearchWriters = "api/writers/search";
    public const string GetWriterLiteraryWorks = "api/writers/literaryworks";

    //Literary Work Endpoints
    public const string GetAllLiteraryWorks = "api/literaryworks";
    public const string GetLiteraryWorkById = "api/literaryworks/getliterarywork";
    public const string CreateLiteraryWork = "api/literaryworks/create";
    public const string UpdateLiteraryWork = "api/literaryworks/update";
    public const string DeleteLiteraryWork = "api/literaryworks/delete";
    public const string SearchLiteraryWorks = "api/literaryworks/search";
    public const string GetByGenre = "api/literaryworks/genre";
    public const string GetByType = "api/literaryworks/type";
    public const string GetByAuthor = "api/literaryworks/author";
}
