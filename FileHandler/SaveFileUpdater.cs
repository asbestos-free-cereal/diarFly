using System.IO;
using System.Numerics;
using System.Text.Json;

namespace diarFly;

public class SaveFileUpdater : SaveFilePath
{
    public SaveFileUpdater(string Plane, string From, string To, string Date, string Airline)
    {
        string JsonData = File.ReadAllText(Get());
        var Stats = JsonSerializer.Deserialize<FlightStatsStruct>(JsonData);
        Stats.Flights += 1;
        Stats.FlightsList.Add(new FlightInfo(Plane, From, To, Date, Airline));
        var Json = JsonSerializer.Serialize(Stats);
        File.WriteAllText(Get(), Json);
    }
}