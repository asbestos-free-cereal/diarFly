using System;
using System.Collections.Generic;

namespace diarFly;

public struct FlightStatsStruct
{
    public int Flights { get; set; }
    public List<FlightInfo>  FlightsList { get; set; }

}


public class FlightInfo
{

    public FlightInfo(string _Plane, string _From , string _To,string __Date,  string _Airline)
    {
        Plane = _Plane;
        From = _From;
        To = _To;
        Date = __Date;
        Airline = _Airline;
    }

    public FlightInfo(){}
 public string Plane { get; set; }
 public string From { get; set; }
 public  string To { get; set; }
 public string Date { get; set; }
 public string Airline { get; set; }
}