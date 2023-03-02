using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
    public class VehicleTypesLogic : BaseLogic
    {
        public List<VehicleTypeModel> GetAllVehicleTypes()
        {
            return db.VehicleTypes.Select(v => new VehicleTypeModel(v)).ToList();
        }

        public VehicleTypeModel? GetVehicleType(int id)
        {
            return db.VehicleTypes.Where(v => v.VehicleTypeId == id).Select(v => new VehicleTypeModel(v)).SingleOrDefault();
        }

        public VehicleTypeModel AddVehicleType(VehicleTypeModel vehicleTypeModel)
        {
            VehicleType vehicleTypeDB = vehicleTypeModel.ConvertToVehicleType();
            db.VehicleTypes.Add(vehicleTypeDB);
            db.SaveChanges();
            vehicleTypeModel.VehicleTypeID = vehicleTypeDB.VehicleTypeId;
            return vehicleTypeModel;
        }

        public void RemoveVehicleType(int id)
        {
            VehicleType? vehicleTypeToDelete = db.VehicleTypes.SingleOrDefault(v => v.VehicleTypeId == id);
            if (vehicleTypeToDelete == null)
                return;
            db.VehicleTypes.Remove(vehicleTypeToDelete);
            db.SaveChanges();
        }

        public VehicleTypeModel? FullVehicleTypeUpdate(VehicleTypeModel vehicleTypeModel)
        {
            VehicleType? vehicleTypeDB = db.VehicleTypes.SingleOrDefault(v => v.VehicleTypeId == vehicleTypeModel.VehicleTypeID);

            if (vehicleTypeDB == null)
                return null;

           // vehicleTypeDB.VehicleTypeId = vehicleTypeModel.VehicleTypeID;
            vehicleTypeDB.Manufacturer = vehicleTypeModel.Manufacturer;
            vehicleTypeDB.Model = vehicleTypeModel.Model;
            vehicleTypeDB.DailyCost = vehicleTypeModel.DailyCost;
            vehicleTypeDB.DayLateCost = vehicleTypeModel.DayLateCost;
            vehicleTypeDB.ManufactureYear = vehicleTypeModel.ManufactureYear;
            vehicleTypeDB.Chalk = vehicleTypeModel.Chalk;
            
            db.SaveChanges();
            return vehicleTypeModel;
        }

        public VehicleTypeModel? PartialVehicleTypeUpdate(VehicleTypeModel vehicleTypeModel)
        {
            VehicleType? vehicleTypeDB = db.VehicleTypes.SingleOrDefault(v => v.VehicleTypeId == vehicleTypeModel.VehicleTypeID);

            if (vehicleTypeDB == null)
                return null;

            if (vehicleTypeModel.Manufacturer != null)
                vehicleTypeDB.Manufacturer = vehicleTypeModel.Manufacturer;

            if (vehicleTypeModel.Model != null)
                vehicleTypeDB.Model = vehicleTypeModel.Model;

            if (vehicleTypeModel.DailyCost != null)
                vehicleTypeDB.DailyCost = vehicleTypeModel.DailyCost;

            if (vehicleTypeModel.DayLateCost != null)
                vehicleTypeDB.DayLateCost = vehicleTypeModel.DayLateCost;

            if (vehicleTypeModel.ManufactureYear != null)
                vehicleTypeDB.ManufactureYear = vehicleTypeModel.ManufactureYear;

            if (vehicleTypeModel.Chalk != null)
                vehicleTypeDB.Chalk = vehicleTypeModel.Chalk;
            
            db.SaveChanges();
            return vehicleTypeModel;
        }
    }
}
