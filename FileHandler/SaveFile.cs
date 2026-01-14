using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace diarFly;

public class SaveFile : SaveFilePath
{
    public SaveFile()
    {
        var Temp = new FlightStatsStruct
        {
            Flights = 0,
            FlightsList = new List<FlightInfo>
            {
                new FlightInfo("", "", "", "", "")
            }
        };
        var Json = JsonSerializer.Serialize(Temp);
        File.WriteAllText(Get(), Json);
    }
}