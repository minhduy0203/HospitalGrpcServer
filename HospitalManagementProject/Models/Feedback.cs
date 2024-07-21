namespace HospitalManagementProject.Models
{
	public class Feedback
	{
        public int Id { get; set; }
        public string Comment { get; set; }
        public int DocterPoint { get; set; }
        public int AppointmentPoint { get; set; }
        public Appointment Appointment { get; set; }


    }
}
