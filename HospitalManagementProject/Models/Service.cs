namespace HospitalManagementProject.Models
{
	public class Service
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public ICollection<Examination>? Examinations { get; set; }

    }
}
