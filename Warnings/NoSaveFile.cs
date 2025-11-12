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
                .GetMessageBoxStandard("Warning", "Save file doesn't exist", ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Error);

            var result = await box.ShowAsync();
            if (result ==  ButtonResult.Ok)
            {
                System.Environment.Exit(0);
            }
        }
    }
    
    
}

