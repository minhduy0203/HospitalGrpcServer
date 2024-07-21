using HospitalManagementProject.Models;

namespace HospitalManagementProject.Repository
{
	public interface IAppointmentRepository
	{
		public Appointment GetAppointment(int id);
		public IQueryable<Appointment> GetAll();
		public Appointment AddAppointment(Appointment appointment);
		public Appointment DeleteAppointment(int id);
		public Appointment UpdateAppointment(Appointment appointment);

		public Appointment UpdateAppointmentState(int id, Status status);
	}
}
