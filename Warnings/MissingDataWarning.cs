using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json.Serialization;
using System.Text.Json;
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
                ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Error);

        var Result = await Box.ShowAsPopupAsync(Owner);
    }
}