using HospitalManagementProject.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementProject.Repository
{
	public class FeedbackRepository : IFeedbackRepository
	{
		private HospitalDBContext context;

		public FeedbackRepository(HospitalDBContext context)
		{
			this.context = context;
		}

		public Feedback AddFeedback(Feedback feedback, int appointmentId)
		{
			Appointment a = context.Appointments
				.Include(a => a.Feedback)
				.FirstOrDefault(a => a.Id == appointmentId);
			if (a != null)
			{

				if (a.Feedback != null)
				{
					a.Feedback.AppointmentPoint = feedback.AppointmentPoint;
					a.Feedback.Comment = feedback.Comment;
					a.Feedback.DocterPoint = feedback.DocterPoint;
					context.SaveChanges();
				}
				else
				{
					context.Feedbacks.Add(feedback);
					context.SaveChanges();
					a.FeedbackId = feedback.Id;
					context.SaveChanges();
				}




			}

			return feedback;
		}
	}
}
