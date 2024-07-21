using HospitalManagementProject.Models;

namespace HospitalManagementProject.Repository
{
	public class PrescriptionRepository : IPrescriptionRepository
	{

		private HospitalDBContext context;

		public PrescriptionRepository(HospitalDBContext context)
		{
			this.context = context;
		}

		public Prescription Add(Prescription prescription, int appointmentId)
		{
			Appointment appointment = context.Appointments.FirstOrDefault(x => x.Id == appointmentId);
			if (appointment != null)
			{

				context.Prescriptions.Add(prescription);
				context.SaveChanges();

				appointment.PrescriptionId = prescription.Id;
				context.SaveChanges();
				return prescription;
			}
			else
			{
				throw new Exception();
			}

		}
	}
}
