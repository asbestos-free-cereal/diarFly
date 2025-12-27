using System;
using System.Diagnostics;
using Avalonia.Controls;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace diarFly;

public class DataSaved
{
    public async void ShowWarning(Window Owner)
    {
        var Box = MessageBoxManager
            .GetMessageBoxStandard("Data Saved", "Data saved. The application will now restart.",
                ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Success);

        var Result = await Box.ShowAsPopupAsync(Owner);
        ;

        if (Result == ButtonResult.Ok)
        {
            string exePath = Process.GetCurrentProcess().MainModule.FileName;
            Console.WriteLine("Restart");
            Process.Start(new ProcessStartInfo(exePath) { UseShellExecute = true });
            Environment.Exit(0);
        }
    }
}