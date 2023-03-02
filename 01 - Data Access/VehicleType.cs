using System;
using System.Collections.Generic;

namespace CarRental;

public partial class VehicleType
{
    public int VehicleTypeId { get; set; }

    public string? Manufacturer { get; set; }

    public string? Model { get; set; }

    public decimal? DailyCost { get; set; }

    public decimal? DayLateCost { get; set; }

    public DateTime? ManufactureYear { get; set; }

    public string? Chalk { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; } = new List<Vehicle>();
}
