using System.IO;
using System.Text.Json;
using Avalonia.Controls;
using Avalonia.Interactivity;
namespace diarFly;

public partial class AddFlightWindow : Window
{
    public AddFlightWindow()
    {
        InitializeComponent();
    }

    private void SaveData(object sender, RoutedEventArgs e)
    {
        var OwnerWindow = this;
        var Temp = FlightDate.SelectedDate;

        if (Temp != null && Plane.Text != "" && To.Text != "" && From.Text != "" && Airline.Text != "")
        {
            string Date = Temp.ToString().Remove(10);
            new SaveFileUpdater(Plane.Text, From.Text, To.Text, Date, Airline.Text);
            var Warning = new DataSaved();
            Warning.ShowWarning(OwnerWindow);
        }
        else
        {
            var Warning = new MissingDataWarning();

            Warning.ShowWarning(OwnerWindow);
        }
    }
}