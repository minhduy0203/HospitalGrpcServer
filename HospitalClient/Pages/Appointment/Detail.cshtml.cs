using HospitalClient.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospitalClient.Pages.Appointment
{
	[Authorize]
	public class DetailModel : PageModel
	{

		public AppointmentDetailResponse response { get; set; }
		private AppointmentService appointmentService;

		public DetailModel(AppointmentService appointmentService)
		{
			this.appointmentService = appointmentService;
		}

		public async Task OnGet(int id)
		{
			await GetData(id);
		}

		private async Task GetData(int id)
		{
			response = await appointmentService.GetAppointment(new AppointmentRequest { Id = id });
		}
	}
}
