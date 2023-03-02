using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
    public class RentalModel
    {
        public int RentalID { get; set; }

        public int VehicleID { get; set; }

        public int UserID { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public DateTime? ActualReturnDate { get; set; }

        public decimal? DayLateCost { get; set; }

        public RentalModel() { }

        public RentalModel(Rental rental)
        {
            RentalID = rental.RentalId;
            VehicleID = rental.VehicleId;
            UserID = rental.UserId;
            StartDate = rental.StartDate;
            ReturnDate = rental.ReturnDate;
            ActualReturnDate= rental.ActualReturnDate;
        }

        public Rental ConvertToRental()
        {
            Rental rental = new Rental
            {
                VehicleId = VehicleID,
                UserId = UserID,
                StartDate = StartDate,
                ReturnDate = ReturnDate,
                ActualReturnDate = ActualReturnDate
            };
            return rental;
        }
    }
}
