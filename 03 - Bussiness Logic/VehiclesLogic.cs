using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
    public class VehiclesLogic : BaseLogic
    {
        public List<VehicleModel> GetAllVehicles()
        {
            return db.Vehicles.Select(v => new VehicleModel(v)).ToList();
        }

        public VehicleModel? GetVehicle(int id)
        {
            return db.Vehicles.Where(v => v.VehicleId == id).Select(v => new VehicleModel(v)).SingleOrDefault();
        }

        public VehicleModel AddVehicle(VehicleModel vehicleModel)
        {
            Vehicle vehicleDB = vehicleModel.ConvertToVehicle();
            db.Vehicles.Add(vehicleDB);
            db.SaveChanges();
            vehicleModel.VehicleID = vehicleDB.VehicleId;
            return vehicleModel;
        }

        public void RemoveVehicle(int id)
        {
            Vehicle? vehicleToDelete = db.Vehicles.SingleOrDefault(v => v.VehicleId == id);
            if (vehicleToDelete == null)
                return;
            db.Vehicles.Remove(vehicleToDelete);
            db.SaveChanges();
        }

        public VehicleModel? FullVehicleUpdate(VehicleModel vehicleModel)
        {
            Vehicle? vehicleDB = db.Vehicles.SingleOrDefault(v => v.VehicleId == vehicleModel.VehicleID);

            if (vehicleDB == null)
                return null;
            vehicleDB.VehicleId = vehicleModel.VehicleID;
            vehicleDB.VehicleTypeId = vehicleModel.VehicleTypeID;
            vehicleDB.BranchId = vehicleModel.BranchID;
            vehicleDB.CurrentMileage = vehicleModel.CurrentMileage;
            vehicleDB.VehicleImageName = vehicleModel.ImageName;
            vehicleDB.VehicleImagePath = vehicleModel.ImagePath;
            vehicleDB.RentWorking = vehicleModel.RentWorking;
            vehicleDB.RentAvailable = vehicleModel.RentAvailable;
            db.SaveChanges();

            return vehicleModel;
        }

        public VehicleModel? PartialVehicleUpdate(VehicleModel vehicleModel)
        {
            Vehicle? vehicleDB = db.Vehicles.SingleOrDefault(v => v.VehicleId == vehicleModel.VehicleID);

            if (vehicleDB == null)
                return null;

            if (vehicleModel.CurrentMileage != null)
                vehicleDB.CurrentMileage = vehicleModel.CurrentMileage;

            if (vehicleModel.ImageName != null)
                vehicleDB.VehicleImageName = vehicleModel.ImageName;

            if (vehicleModel.ImageName != null)
                vehicleDB.VehicleImagePath = vehicleModel.ImageName;

            if (vehicleModel.RentWorking != null)
                vehicleDB.RentWorking = vehicleModel.RentWorking;

            if (vehicleModel.RentAvailable != null)
                vehicleDB.RentAvailable = vehicleModel.RentAvailable;

            db.SaveChanges();
            return vehicleModel;
        }
    }
}
