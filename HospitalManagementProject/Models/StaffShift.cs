namespace HospitalManagementProject.Models
{
	public class StaffShift
	{
        public int ShiftId { get; set; }
        public Shift Shift { get; set; }
        public int MedStaffId { get; set; }
        public MedStaff MedStaff { get; set; }
    }
}
