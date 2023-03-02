using System;
using System.Collections.Generic;

namespace CarRental;

public partial class Branch
{
    public int BranchId { get; set; }

    public string? AddressName { get; set; }

    public decimal? AccurateLocation { get; set; }

    public string? BranchName { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; } = new List<Vehicle>();
}
