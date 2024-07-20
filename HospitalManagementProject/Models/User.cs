using Microsoft.AspNetCore.Identity;

namespace HospitalManagementProject.Models
{
	public class User : IdentityUser
	{
        public int? PatientId { get; set; }
        public Patient? Patient { get; set; }

        public MedStaff? MedStaff { get; set; }
        public int? MedStaffId { get; set; }


    }
}
