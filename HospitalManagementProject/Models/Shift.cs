namespace HospitalManagementProject.Models
{
	public class Shift
	{
        public int Id { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }

        public ICollection<StaffShift>? StaffShift { get; set; }


    }  
}
