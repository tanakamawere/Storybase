using CommunityToolkit.Mvvm.Input;
using MvvmHelpers;
using StorybaseLibrary.Interfaces;
using StorybaseLibrary.Models;
using StorybaseMobile.Pages;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace StorybaseMobile.ViewModels;

public partial class HomePageViewModel : BaseViewModel
{
    public ObservableRangeCollection<Book> Books { get; set; } = new();
    public HomePageViewModel(IApiRepository api)
    {
        apiRepository = api;

        Title = "Home";

        GetBooks();
    }

    // Get list of books from api
    [RelayCommand]
    public async Task GetBooks()
    {
        IsBusy = true;
        Books.Clear();
        try
        {
            var books = await apiRepository.GetBooksAsync();
            Books.AddRange(books);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    public async Task GoToBookDetails(Book book)
    {
        if (book != null)
        {
            await Shell.Current.GoToAsync(nameof(BookDetailsPage), true, new Dictionary<string, object>
            {
                { "bookSelected", book }
            });
        }
    }
}
