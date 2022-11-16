using System;
using System.Collections.Generic;

namespace WeatherAPI.Models;

public partial class Table
{
    public int Key { get; set; }

    public string LocalizedName { get; set; } = null!;

    public double Weather { get; set; }
}
