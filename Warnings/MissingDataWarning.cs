using Avalonia.Controls;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace diarFly;

public class MissingDataWarning
{
    public async void ShowWarning(Window Owner)
    {
        var Box = MessageBoxManager
            .GetMessageBoxStandard("Error", "Please fill out all fields.",
                ButtonEnum.Ok, Icon.Error);

        await Box.ShowAsPopupAsync(Owner);
    }
}