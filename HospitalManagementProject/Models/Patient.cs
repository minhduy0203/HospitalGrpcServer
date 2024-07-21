namespace HospitalManagementProject.Models
{
	public class Patient
	{
        public int Id { get; set; }

        public string? UserId { get; set; }
        public User? User { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
