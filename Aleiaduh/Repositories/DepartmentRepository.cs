using Aleiaduh.DataAccess;
using Aleiaduh.Models;
using Aleiaduh.Repositories.IRepositories;

namespace Aleiaduh.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private readonly ApplicationDbContext applicationDb;
        public DepartmentRepository(ApplicationDbContext applicationDb) : base(applicationDb)
        {
            this.applicationDb = applicationDb;
        }
    }
}
