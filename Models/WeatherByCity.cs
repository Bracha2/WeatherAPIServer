using System;
using System.Collections.Generic;

namespace WeatherAPI.Models;

public partial class WeatherByCity
{
    public int Key { get; set; }

    public string Weather { get; set; }

    public int Temperature { get; set; }
}
