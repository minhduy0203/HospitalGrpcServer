using HospitalManagementProject.Models;

namespace HospitalManagementProject.Repository
{
	public class FeedbackRepository : IFeedbackRepository
	{
		private HospitalDBContext context;

		public FeedbackRepository(HospitalDBContext context)
		{
			this.context = context;
		}

		public Feedback AddFeedback(Feedback feedback)
		{
			context.Feedbacks.Add(feedback);
			context.SaveChanges();
			return feedback;
		}
	}
}
