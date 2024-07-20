namespace HospitalManagementProject.Models
{
	public class Appointment
	{
        public int Id { get; set; }

        public string? Room { get; set; }
        public int? MedStaffId { get; set; }
        public MedStaff? MedStaff { get; set; }
        public DateTime Date { get; set; }
        public Status Status { get; set; }
        public string Conclusion { get; set; }
        public int? PatientId { get; set; }
        public Patient? Patient { get; set; }

        public int? FeedbackId { get; set; }
        public Feedback? Feedback { get; set; }

        public int? PrescriptionId { get; set; }
        public Prescription? Prescription { get; set; }

        public int? ShiftId { get; set; }
        public Shift? Shift { get; set; }


    }

    public enum Status
    {
        PENDING,
        APPROVE,
        DECLINE
    }
}
