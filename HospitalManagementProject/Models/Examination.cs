namespace HospitalManagementProject.Models
{
	public class Examination
	{
        public int Id { get; set; }
        public string Result { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}
