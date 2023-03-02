using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
    public class BranchesLogic : BaseLogic
    {
        public List<BranchModel> GetAllBranches()
        {
            return db.Branches.Select(b => new BranchModel(b)).ToList();
        }

        public BranchModel? GetBranch(int id)
        {
            return db.Branches.Where(b => b.BranchId == id).Select(b => new BranchModel(b)).SingleOrDefault();
        }

        public BranchModel AddBranch(BranchModel branchModel)
        {
            Branch branchDB = branchModel.ConvertToBranch();
            db.Branches.Add(branchDB);
            db.SaveChanges();
            branchModel.BranchID = branchDB.BranchId;
            return branchModel;
        }

        public void RemoveBranch(int id)
        {
            Branch? branchToDelete = db.Branches.SingleOrDefault(b => b.BranchId == id);
            if (branchToDelete == null)
                return;
            db.Branches.Remove(branchToDelete);
            db.SaveChanges();
        }
    }
}
