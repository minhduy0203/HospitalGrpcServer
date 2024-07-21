using HospitalManagementProject.Models;

namespace HospitalManagementProject.Repository
{
	public class MedstaffRepository : IMedstaffRepository
	{
		private HospitalDBContext context;

		public MedstaffRepository(HospitalDBContext context)
		{
			this.context = context;
		}

		public IQueryable<MedStaff> GetAll()
		{
			return context.MedStaffs.AsQueryable();
		}
	}
}
