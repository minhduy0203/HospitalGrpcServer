using HospitalClient.Services;
using HospitalClient.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace HospitalClient.Pages.Admin
{
	[Authorize(Roles = "ADMIN")]
	public class AppointmentListModel : PageModel
    {
        public AppointmentListResponse Response { get; set; }
        public AppointmentListRequest Request { get; set; } = new AppointmentListRequest();
        public List<AppointmentResponse> List { get; set; }


        private AppointmentService appointmentService;

        public AppointmentListModel(AppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

        public async Task OnGet()
        {
            await GetData();
        }

        public async Task OnPostApprove(int id)
        {
            await appointmentService.UpdateAppointmentStatus(new AppointmentUpdateStatusRequest
            {
                AppointmentId = id,
                Status = (int)Status.APPROVE
            });
			await GetData();
		}

		public async Task OnPostReject(int id)
		{
			await appointmentService.UpdateAppointmentStatus(new AppointmentUpdateStatusRequest
			{
				AppointmentId = id,
				Status = (int)Status.DECLINE
			});
			await GetData();

		}


		public async Task GetData()
        {
            Response = await appointmentService.GetListAppointment(Request);
            List = Response.Result.ToList();
        }
    }
}
