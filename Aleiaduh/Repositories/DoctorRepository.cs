using Aleiaduh.DataAccess;
using Aleiaduh.Models;
using Aleiaduh.Repositories.IRepositories;

namespace Aleiaduh.Repositories
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        private readonly ApplicationDbContext applicationDb;
        public DoctorRepository(ApplicationDbContext applicationDb) : base(applicationDb)
        {
            this.applicationDb = applicationDb;
        }
    }
}
