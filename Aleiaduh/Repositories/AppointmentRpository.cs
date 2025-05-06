using Aleiaduh.DataAccess;
using Aleiaduh.Models;
using Aleiaduh.Repositories.IRepositories;

namespace Aleiaduh.Repositories
{
    public class AppointmentRpository : Repository<Appointment>, IAppointmentRepository
    {
        private readonly ApplicationDbContext applicationDb;
        public AppointmentRpository(ApplicationDbContext applicationDb) : base(applicationDb)
        {
            this.applicationDb = applicationDb;
        }
    }
}
