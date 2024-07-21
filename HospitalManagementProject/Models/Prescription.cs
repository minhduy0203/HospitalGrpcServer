namespace HospitalManagementProject.Models
{
	public class Prescription
	{
        public int Id { get; set; }
        public string Detail { get; set; }

        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

    }
}
