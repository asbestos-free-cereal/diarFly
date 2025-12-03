using System;
using System.Diagnostics;
using Avalonia.Controls;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace diarFly
{
    public class Warnings
    {
        public async void ShowWarning()
        {
            var box = MessageBoxManager
                .GetMessageBoxStandard("Warning", "Couldn't find a file containing your data. New one will be created.",
                    ButtonEnum.OkAbort, MsBox.Avalonia.Enums.Icon.Error);

            var result = await box.ShowAsync();
            if (result == ButtonResult.Abort)
            {
                System.Environment.Exit(0);
            }
            else if (result == ButtonResult.Ok)
            {
                Console.WriteLine("test");
                string exePath = Process.GetCurrentProcess().MainModule.FileName;
                //TODO tworzenie pliku zapisu

                var Info = MessageBoxManager
                    .GetMessageBoxStandard("Info", "The application will now restart.", ButtonEnum.Ok,
                        MsBox.Avalonia.Enums.Icon.Info);

                var result2 = await Info.ShowAsync();
                if (result2 == ButtonResult.Ok)
                {
                    Process.Start(new ProcessStartInfo(exePath) { UseShellExecute = true });
                    Environment.Exit(0);
                }
            }
        }
    }
}