using System;
using Avalonia.Controls;
using System.Text.Json;
using System.IO;
using diarFly;
using System.Runtime.InteropServices;

namespace diarFly;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        var SaveFile = new SaveFilePath();
        InitializeComponent();
        
        if (SaveFile.Exists())
        {
            string jsonData = File.ReadAllText(SaveFile.Get());
            var Stats = JsonSerializer.Deserialize<FlightStatsStruct>(jsonData);
            Flights.Text = Stats.Flights.ToString();
        }
        else
        {
            var warning = new Warnings();
            warning.ShowWarning();
        }
    }
}