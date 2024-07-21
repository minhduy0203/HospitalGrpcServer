using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementProject.Models
{
	public class MedStaff
	{
        public int Id { get; set; }
		public User? User { get; set; }
		public string Qualification { get; set; }
        public string Experience { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<StaffShift> StaffShifts { get; set; }

    }
}
