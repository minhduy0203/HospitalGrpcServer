using HospitalManagementProject.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementProject.Repository
{
	public class AppointmentRepository : IAppointmentRepository
	{
		private HospitalDBContext context;

		public AppointmentRepository(HospitalDBContext context)
		{
			this.context = context;
		}

		public Appointment AddAppointment(Appointment appointment)
		{
			context.Appointments.Add(appointment);
			context.SaveChanges();
			return appointment;
		}

		public Appointment DeleteAppointment(int id)
		{
			Appointment appointment = context.Appointments.FirstOrDefault(a => a.Id == id);
			if (appointment != null)
			{
				context.Appointments.Remove(appointment);
				context.SaveChanges();
			}
			return appointment;
		}

		public IQueryable<Appointment> GetAll()
		{
			return context.Appointments;
		}

		public Appointment GetAppointment(int id)
		{
			return context.Appointments
				.Include(a => a.Shift)
				.Include(a => a.MedStaff)
				.ThenInclude(m => m.User)
				.Include(a => a.Patient)
				.ThenInclude(p => p.User)
				.FirstOrDefault(a => a.Id == id)

				;
		}

		public Appointment UpdateAppointment(Appointment appointment)
		{
			context.Entry<Appointment>(appointment).State = EntityState.Modified;
			context.SaveChanges();
			return appointment;
		}

		public Appointment UpdateAppointmentState(int id, Status status)
		{
			Appointment appointment = context.Appointments.FirstOrDefault(a => a.Id == id);
			if (appointment != null)
			{
				appointment.Status = status;
				context.SaveChanges();
			}
			return appointment;
		}
	}
}
