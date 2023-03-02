using System;
using System.Collections.Generic;

namespace CarRental;

public partial class Vehicle
{
    public int VehicleId { get; set; }

    public int VehicleTypeId { get; set; }

    public int BranchId { get; set; }

    public int? CurrentMileage { get; set; }

    public string? VehicleImageName { get; set; }

    public string? VehicleImagePath { get; set; }

    public bool? RentWorking { get; set; }

    public bool? RentAvailable { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual VehicleType VehicleType { get; set; } = null!;
}
