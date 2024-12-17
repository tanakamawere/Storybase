using MudBlazor;
using Storybase.Components.Shared;
using System.Threading.Tasks;

namespace Storybase.Components.Services;

public class DialogHelperService
{
    private readonly IDialogService _dialogService;

    public DialogHelperService(IDialogService dialogService)
    {
        _dialogService = dialogService;
    }

    public async Task<bool> RemoveDeleteConfirmationDialog(string contentText, string buttonText)
    {
        var parameters = new DialogParameters<ConfirmationDialog>
        {
            { x => x.ContentText, contentText },
            { x => x.ButtonText, buttonText },
        };

        var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };

        var dialog = await _dialogService.ShowAsync<ConfirmationDialog>("Remove", parameters, options);
        var result = await dialog.Result;
        return !result.Canceled;
    }
}

