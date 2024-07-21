using HospitalManagementProject.Models;

namespace HospitalManagementProject.Repository
{
	public class ShiftRepository : IShiftRespository
	{
		private HospitalDBContext context;

		public ShiftRepository(HospitalDBContext context)
		{
			this.context = context;
		}

		public IQueryable<Shift> GetAll()
		{
			return context.Shifts.AsQueryable();
		}
	}
}
