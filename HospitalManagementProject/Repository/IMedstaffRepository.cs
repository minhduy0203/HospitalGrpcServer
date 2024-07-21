using HospitalManagementProject.Models;

namespace HospitalManagementProject.Repository
{
	public interface IMedstaffRepository
	{

		public IQueryable<MedStaff> GetAll();
	}
}
