namespace Storybase.Core;

public class EndpointStrings
{
    //LiteraryWorkPurchase Endpoints
    public const string GetPurchaseById = "api/purchases/getpurchase";
    public const string CreatePurchase = "api/purchases/create";
    public const string UpdatePurchase = "api/purchases/update";
    public const string DeletePurchase = "api/purchases/delete";
    public const string SearchPurchases = "api/purchases/search";
    public const string GetAllPurchases = "api/purchases";
    //Get all purchases by user
    public const string GetPurchasesByUser = "api/purchases/user";
    //GetPurchaseByAuthUserIdAndLiteraryWorkIdAsync
    public const string GetPurchaseByAuthUserIdAndLiteraryWorkId = "api/purchases/getbyauthlit";


    //Reading Progress Endpoints
    public const string GetReadingProgressById = "api/rdprog/get";
    public const string CreateReadingProgress = "api/rdprog/create";
    public const string UpdateReadingProgress = "api/rdprog/update";
    public const string DeleteReadingProgress = "api/rdprog/delete";
    public const string SearchReadingProgresss = "api/rdprog/search";
    public const string GetAllReadingProgresss = "api/rdprog";

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
    public const string CheckIfUserExists = "api/users/exists";

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
    public const string GetWriterLiteraryByAuthId = "api/writers/lwbyauthid";
    public const string IsUserNameTaken = "api/writers/isUserNameTaken";
    public const string HasWriterProfile = "api/writers/hasprofile";
    public const string GetWriterProfileByUserName = "api/writers/username";
    public const string GetWriterProfileById = "api/writers/id";

    //Literary Work Endpoints
    public const string GetAllLiteraryWorks = "api/literaryworks";
    public const string GetLiteraryWorkById = "api/literaryworks/getliterarywork";
    public const string CreateLiteraryWork = "api/literaryworks/create";
    public const string UpdateLiteraryWork = "api/literaryworks/update";
    //Soft delete or archiving
    public const string DeleteLiteraryWork = "api/literaryworks/delete";
    public const string SearchLiteraryWorks = "api/literaryworks/search";
    public const string GetByGenre = "api/literaryworks/genre";
    public const string GetByType = "api/literaryworks/type";
    public const string GetByAuthor = "api/literaryworks/author";
    //Unarchive litwork
    public const string UnarchiveLiteraryWork = "api/literaryworks/unarchive";

    //Genres
    public const string GetAllGenres = "api/genres";
    public const string GetGenreById = "api/genres/getgenre";

    //Get library of user
    public const string GetLibrary = "api/library";
    //Payment endpoints
    public const string InitializePayment = "api/payments/init";
    public const string CheckPaymentStatus = "api/payments/check";
    public const string InitializeMobilePayment = "api/payments/initmobile";

    //Payments endpoints
    public const string GetPaymentById = "api/payments/getpayment";
    public const string GetPaymentByTransactionId = "api/payments/getbytransactionid";
    public const string ResultUrlPaynow = "/api/payment/result";

    //Payouts Request endpoints
    public const string GetPayoutById = "api/payoutreq/getpayout";
    public const string CreatePayout = "api/payoutreq/create";
    public const string UpdatePayout = "api/payoutreq/update";
    public const string DeletePayout = "api/payoutreq/delete";
    public const string SearchPayouts = "api/payoutreq/search";
    public const string GetAllPayouts = "api/payoutreq";
    public const string GetPayoutsByUserAuthId = "api/payoutreq/user";
    public const string ConfirmPayout = "api/payoutreq/confirm";

    //Sales endpoints
    public const string GetWriterSales = "api/sales/get";

    //User Payout Methods
    public const string GetUserPayoutMethods = "api/payout-methods/get";
    public const string AddUserPayoutMethod = "api/payout-methods/add";
    public const string UpdateUserPayoutMethod = "api/payout-methods/update";

    //General endpoints
    public const string Search = "api/search";
}
