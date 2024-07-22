using HospitalClient.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospitalClient.Pages.Appointment
{

	[Authorize(Roles = "ADMIN,DOCTOR")]
	public class UpdateModel : PageModel
	{
		public AppointmentDetailResponse response { get; set; }
        public string Message { get; set; }

        [BindProperty]
		public UpdateAppointmentRequest request { get; set; }
		private AppointmentService appointmentService;

		public UpdateModel(AppointmentService appointmentService)
		{
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
				await appointmentService.UpdateAppointment(request);
				await GetData(id);
				Message = "Update successfully";
			}
			catch (Exception)
			{

				Message = "Update failed";
			}
		
		}

		private async Task GetData(int id)
		{
			response = await appointmentService.GetAppointment(new AppointmentRequest { Id = id });
		}
	}
}
