using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
    public class VehicleModel
    {
        public int VehicleID { get; set; }

        public int VehicleTypeID { get; set; }

        public int BranchID { get; set; }

        public int? CurrentMileage { get; set; }

        public string? ImageName { get; set; }

        public string? ImagePath { get; set; }

        public bool? RentWorking { get; set; }

        public bool? RentAvailable { get; set; }

        public VehicleModel() { }

        public VehicleModel(Vehicle vehicle)
        {
            VehicleID = vehicle.VehicleId;
            VehicleTypeID = vehicle.VehicleTypeId;
            BranchID = vehicle.BranchId;
            CurrentMileage= vehicle.CurrentMileage;
            ImageName= vehicle.VehicleImageName;
            ImagePath= vehicle.VehicleImagePath;
            RentWorking = vehicle.RentWorking;
            RentAvailable = vehicle.RentAvailable;         
        }

        public Vehicle ConvertToVehicle()
        {
            Vehicle vehicle = new Vehicle
            {
                VehicleId = VehicleID,
                VehicleTypeId = VehicleTypeID,
                BranchId = BranchID,
                CurrentMileage = CurrentMileage,
                VehicleImageName = ImageName,
                VehicleImagePath = ImagePath,
                RentWorking = RentWorking,
                RentAvailable = RentAvailable
            };
            return vehicle;
        }
    }
}
