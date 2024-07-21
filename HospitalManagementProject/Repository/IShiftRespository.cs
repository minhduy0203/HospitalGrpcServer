using HospitalManagementProject.Models;

namespace HospitalManagementProject.Repository
{
	public interface IShiftRespository
	{

		public IQueryable<Shift> GetAll();
	}
}
