using System;
using Avalonia.Controls;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace diarFly
{
    public class NoSaveFileWarning : RestartWarning
    {
        public async void ShowWarning(Window Owner)
        {
            var Box = MessageBoxManager
                .GetMessageBoxStandard("Warning", "Couldn't find a file containing your data. New one will be created.",
                    ButtonEnum.OkCancel, Icon.Error);

            var Result = await Box.ShowAsPopupAsync(Owner);


            if (Result == ButtonResult.Cancel)
            {
                Environment.Exit(0);
            }

            else if (Result == ButtonResult.Ok)
            {
                new SaveFile();
                Restart(Owner, "Info", "File created.\nThe application will now restart.");
            }
        }
    }
}