using Avalonia.Controls;
using System.Text.Json;
using System.IO;
using diarFly;

namespace diarFly;

public partial class MainWindow : Window
{


    
    public class FlightStats
    {
        public int Flights { get; set; }
    }

 
    public MainWindow()
    {
        InitializeComponent();
        var path = "/test.json";
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            var stats = JsonSerializer.Deserialize<FlightStats>(jsonData);
        
            Flights.Text = stats.Flights.ToString();
        }
        else
        {
            var warning = new Warnings();
                warning.ShowWarning();
        }

    }
}