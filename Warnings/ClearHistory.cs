using System.IO;
using Avalonia.Controls;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace diarFly;

public class ClearHistory : RestartWarning
{
    public async void ShowWarning(Window Owner)
    {
        var Box = MessageBoxManager
            .GetMessageBoxStandard("Warning",
                "Are you sure you want to clear your flight history? This cannot be undone.",
                ButtonEnum.YesNo, Icon.Stop);

        var Result = await Box.ShowAsPopupAsync(Owner);


        if (Result == ButtonResult.Yes)
        {
            string Path = new SaveFilePath().Get();
            File.Delete(Path);
            Restart(Owner, "Info", "History cleared.\nThe application will now restart.");
        }
    }
}