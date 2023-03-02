using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
    public class VehicleTypeModel
    {
        public int VehicleTypeID { get; set; }

        public string? Manufacturer { get; set; }

        public string? Model { get; set; }

        public decimal? DailyCost { get; set; }

        public decimal? DayLateCost { get; set; }

        public DateTime? ManufactureYear { get; set; }

        public string? Chalk { get; set; }

        public VehicleTypeModel() { }

        public VehicleTypeModel(VehicleType vehicle)
        {
            VehicleTypeID = vehicle.VehicleTypeId;
            Manufacturer = vehicle.Manufacturer;
            Model = vehicle.Model;
            DailyCost = vehicle.DailyCost;
            DayLateCost = vehicle.DayLateCost;
            ManufactureYear = vehicle.ManufactureYear;
            Chalk = vehicle.Chalk;
        }

        public VehicleType ConvertToVehicleType()
        {
            VehicleType vehicleType = new VehicleType
            {
                VehicleTypeId = VehicleTypeID,
                Manufacturer = Manufacturer,
                Model = Model,
                DailyCost = DailyCost,
                DayLateCost = DayLateCost,
                ManufactureYear = ManufactureYear,
                Chalk = Chalk
            };
            return vehicleType;
        }
    }
}
