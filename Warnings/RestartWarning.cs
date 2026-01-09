using System;
using System.Diagnostics;
using Avalonia.Controls;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace diarFly;

public abstract class RestartWarning
{
    public async void Restart(Window Owner, string Title, string Message)
    {
        var Info = MessageBoxManager
            .GetMessageBoxStandard(Title, Message,
                ButtonEnum.Ok, Icon.Success);

        var Result = await Info.ShowAsPopupAsync(Owner);
        if (Result == ButtonResult.Ok)
        {
            string exePath = Process.GetCurrentProcess().MainModule.FileName;
            Process.Start(new ProcessStartInfo(exePath) { UseShellExecute = true });
            Environment.Exit(0);
        }
    }
}