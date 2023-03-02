using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CarRental
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Manager")] //Must be manager 
    public class BranchesController : ControllerBase
    {
        private readonly BranchesLogic branchLogic = new BranchesLogic();

        [HttpGet]
        public IActionResult GetAllBranches()
        {
            try
            {
                List<BranchModel> branches = branchLogic.GetAllBranches();
                return Ok(branches);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetBranch(int id)
        {
            try
            {
                BranchModel? branch = branchLogic.GetBranch(id);
                if (branch == null)
                    return NotFound($"Branch ID:{id} not found");
                return Ok(branch);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddBranch(BranchModel branchModel)
        {
            try
            {
                BranchModel addedBranch = branchLogic.AddBranch(branchModel);
                return Created($"api/branches/{addedBranch.BranchID}", addedBranch);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteBranch(int id)
        {
            try
            {
                branchLogic.RemoveBranch(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        public void Dispose()
        {
            branchLogic.Dispose();
        }
    }
}
