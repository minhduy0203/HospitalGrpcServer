using HospitalClient.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospitalClient.Pages.Appointment
{
	[Authorize(Roles = "PATIENT")]
	public class AddFeedbackModel : PageModel
	{
		public AppointmentDetailResponse response { get; set; }

		[BindProperty]
		public FeedbackAddRequest request { get; set; }
		public string Message { get; set; }

		private AppointmentService appointmentService;
		private FeedbackService feedbackService;

		public AddFeedbackModel(FeedbackService feedbackService, AppointmentService appointmentService)
		{
			this.feedbackService = feedbackService;
			this.appointmentService = appointmentService;
		}

		public async Task OnGet(int id)
		{
			await GetData(id);
		}

		public async Task OnPost(int id)
		{
			try
			{
				request.AppointmentId = id;
				await feedbackService.AddFeedback(request);
				await GetData(id);
				Message = "Successfully";
			}
			catch (Exception ex)
			{

				Message = ex.Message;
			}


		}

		private async Task GetData(int id)
		{
			response = await appointmentService.GetAppointment(new AppointmentRequest { Id = id });
		}


	}
}
