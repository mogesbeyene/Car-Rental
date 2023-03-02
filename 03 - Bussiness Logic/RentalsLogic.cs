using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
    public class RentalsLogic : BaseLogic
    {
        public List<RentalModel> GetAllRentals()
        {
            return db.Rentals.Select(r => new RentalModel(r)).ToList();
        }

        public RentalModel? GetRental(int id)
        {
            return db.Rentals.Where(r => r.RentalId == id).Select(r => new RentalModel(r)).SingleOrDefault();
        }

        public RentalModel AddRental(RentalModel rentalModel)
        {
            Rental rentalDB = rentalModel.ConvertToRental();
            db.Rentals.Add(rentalDB);
            db.SaveChanges();
            rentalModel.RentalID = rentalDB.RentalId;
            return rentalModel;
        }

        public void RemoveRental(int id)
        {
            Rental? rentalToDelete = db.Rentals.SingleOrDefault(r => r.RentalId == id);
            if (rentalToDelete == null)
                return;
            db.Rentals.Remove(rentalToDelete);
            db.SaveChanges();
        }

        public RentalModel? FullRentalUpdate(RentalModel rentalModel)
        {
            Rental? rentalDB = db.Rentals.SingleOrDefault(p => p.RentalId == rentalModel.RentalID);

            if (rentalDB == null)
                return null;
            rentalDB.RentalId = rentalModel.RentalID;
            rentalDB.StartDate = rentalModel.StartDate;
            rentalDB.ReturnDate = rentalModel.ReturnDate;
            rentalDB.ActualReturnDate = rentalModel.ActualReturnDate;
            rentalDB.VehicleId = rentalModel.VehicleID;
            rentalDB.UserId = rentalModel.UserID;
            db.SaveChanges();

            return rentalModel;
        }

        public RentalModel? PartialRentalUpdate(RentalModel rentalModel)
        {
            Rental? rentalDB = db.Rentals.SingleOrDefault(p => p.RentalId == rentalModel.RentalID);

            if (rentalDB == null)
                return null;

            if (rentalModel.StartDate != null)
                rentalDB.StartDate = rentalModel.StartDate;

            if (rentalModel.ReturnDate != null)
                rentalDB.ReturnDate = rentalModel.ReturnDate;

            if (rentalModel.ActualReturnDate != null)
                rentalDB.ActualReturnDate = rentalModel.ActualReturnDate;

            db.SaveChanges();
            return rentalModel;
        }
    }
}
