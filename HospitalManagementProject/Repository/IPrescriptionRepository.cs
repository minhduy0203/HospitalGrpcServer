using HospitalManagementProject.Models;

namespace HospitalManagementProject.Repository
{
	public interface IPrescriptionRepository
	{
		public Prescription Add(Prescription prescription , int appointmentId);
	}
}
