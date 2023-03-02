using System;
using System.Collections.Generic;

namespace CarRental;

public partial class Rental
{
    public int RentalId { get; set; }

    public int VehicleId { get; set; }

    public int UserId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public DateTime? ActualReturnDate { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual VehicleType Vehicle { get; set; } = null!;
}
