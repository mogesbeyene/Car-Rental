using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
    public abstract class BaseLogic : IDisposable
    {
        protected readonly CarRentalCompanyContext db = new CarRentalCompanyContext();

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
