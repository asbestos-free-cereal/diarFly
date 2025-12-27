using Avalonia.Controls;
using System.Text.Json;
using System.IO;
using System.Linq;
using Avalonia.Interactivity;

namespace diarFly;

public partial class MainWindow : Window
{
    public MainWindow()

    {
        InitializeComponent();
    }

    private void OpenNewWindow(object sender, RoutedEventArgs e)
    {
        var Window = new AddFlightWindow();
        var OwnerWindow = this;
        Window.ShowDialog(OwnerWindow);
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        var SaveFile = new SaveFilePath();


        if (SaveFile.Exists())
        {
            string JsonData = File.ReadAllText(SaveFile.Get());
            var Stats = JsonSerializer.Deserialize<FlightStatsStruct>(JsonData);
            Flights.Text = Stats.Flights.ToString();

            if (Stats.Flights != 0)
            {
                var TopAirlineList =
                (
                    Stats.FlightsList.GroupBy(item => item.Airline).Select(itemGroup =>
                        new { Airline = itemGroup.Key, Count = itemGroup.Count() })
                ).ToList().OrderBy(item => item.Count).ToList();


                string TopAirlineString = TopAirlineList.Last().Airline + " (" + TopAirlineList.Last().Count + ")";

                TopAirline.Text = TopAirlineString;


                var TopToList =
                (
                    Stats.FlightsList.GroupBy(item => item.To).Select(itemGroup =>
                        new { To = itemGroup.Key, Count = itemGroup.Count() })
                ).ToList().OrderBy(item => item.Count).ToList();


                string TopDestinationString = TopToList.Last().To + " (" + TopToList.Last().Count + ")";

                TopDestination.Text = TopDestinationString;

                var TopAircraftList =
                (
                    Stats.FlightsList.GroupBy(item => item.Plane).Select(itemGroup =>
                        new { Plane = itemGroup.Key, Count = itemGroup.Count() })
                ).ToList().OrderBy(item => item.Count).ToList();


                string TopAircraftString = TopAircraftList.Last().Plane + " (" + TopAircraftList.Last().Count + ")";

                TopAircraft.Text = TopAircraftString;

                string[] FlightHistory = new string[Stats.Flights];


                for (int i = 1; i < Stats.Flights + 1; i++)
                {
                    string Temp = Stats.FlightsList[i].Date;
                    Temp += " "+ Stats.FlightsList[i].From;
                    Temp += " -> " + Stats.FlightsList[i].To;
                    Temp += "   " + Stats.FlightsList[i].Plane;
                    Temp += " " + Stats.FlightsList[i].Airline;
                    FlightHistory[i - 1] = Temp;
                }


                History.ItemsSource = FlightHistory;
            }

            else
            {
                TopAircraft.Text = "n/a";
                TopAirline.Text = "n/a";
                TopDestination.Text = "n/a";
            }
        }
        else
        {
            var Warning = new NoSaveFileWarning();
            var OwnerWindow = this;
            Warning.ShowWarning(OwnerWindow);
        }
    }
}