using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using Avalonia.Controls;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace diarFly
{
    public class NoSaveFileWarning
    {
        public async void ShowWarning(Window Owner)
        {
            var Box = MessageBoxManager
                .GetMessageBoxStandard("Warning", "Couldn't find a file containing your data. New one will be created.",
                    ButtonEnum.OkCancel, MsBox.Avalonia.Enums.Icon.Error);

            var Result = await Box.ShowAsPopupAsync(Owner);
            ;

            if (Result == ButtonResult.Cancel)
            {
                System.Environment.Exit(0);
            }

            else if (Result == ButtonResult.Ok)
            {
                string exePath = Process.GetCurrentProcess().MainModule.FileName;

                var Temp = new FlightStatsStruct
                {
                    Flights = 0,
                    FlightsList = new List<FlightInfo>
                    {
                        new FlightInfo("", "", "", "", "")
                    }
                };
                var Json = JsonSerializer.Serialize(Temp);
                var Path = new SaveFilePath();
                File.WriteAllText(Path.Get(), Json);
                var Info = MessageBoxManager
                    .GetMessageBoxStandard("Info", "The application will now restart.", ButtonEnum.Ok,
                        MsBox.Avalonia.Enums.Icon.Info);

                Result = await Info.ShowAsPopupAsync(Owner);
                if (Result == ButtonResult.Ok)
                {
                    Console.WriteLine("Restart");
                    Process.Start(new ProcessStartInfo(exePath) { UseShellExecute = true });
                    Environment.Exit(0);
                }
            }
        }
    }
}