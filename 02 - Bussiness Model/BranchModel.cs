using System.ComponentModel.DataAnnotations;

namespace CarRental
{
    public class BranchModel
    {
        [Required(ErrorMessage = "Missing name")]
        public int BranchID { get; set; }

        public string? Address { get; set; }

        public decimal? Location { get; set; }

        public string? Name { get; set; }

        public BranchModel() { }

        public BranchModel(Branch branch)
        {
            BranchID = branch.BranchId;
            Address = branch.AddressName;
            Location = branch.AccurateLocation;
            Name = branch.BranchName;
        }

        //To save in DB
        public Branch ConvertToBranch()
        {
            Branch branch = new Branch
            {
                BranchId = BranchID,
                AddressName = Address,
                AccurateLocation = Location,
                BranchName = Name
            };
            return branch;
        }
    }
}
