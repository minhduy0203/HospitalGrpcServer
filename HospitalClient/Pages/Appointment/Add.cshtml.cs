using Google.Protobuf.WellKnownTypes;
using HospitalClient.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace HospitalClient.Pages.Appointment
{

	[Authorize]
	public class AddModel : PageModel
	{
		private MedstaffService medstaffService;
		private ShiftService shiftService;
		private AppointmentService appointmentService;
		private IHttpContextAccessor httpContextAccessor;

		public string Message { get; set; }
		public List<ShiftResponse> Shifts { get; set; }
		public List<MedstaffResponse> Medstaffs { get; set; }

		[BindProperty]
		public AppointmentAddRequest request { get; set; }

		[BindProperty]
		public DateTime Date { get; set; }


		public AddModel(MedstaffService medstaffService, ShiftService shiftService, AppointmentService appointmentService, IHttpContextAccessor httpContextAccessor)
		{
			this.medstaffService = medstaffService;
			this.shiftService = shiftService;
			this.appointmentService = appointmentService;
			this.httpContextAccessor = httpContextAccessor;
		}

		public async Task OnGet()
		{
			await GetData();
		}

		public async Task OnPost()
		{
			if (ModelState.IsValid)
			{
				try
				{
					Claim c = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("Id"));
					int patientId = Int32.Parse(c.Value);
					request.PatientId = patientId;
					request.Date = Timestamp.FromDateTime(Date.ToLocalTime().ToUniversalTime());
					AppointmentDetailResponse response = await appointmentService.AddAppointment(request);
					if (response.IsSuccess)
					{
						Message = "Add successfully";
					}
				}
				catch (Exception ex)
				{

					Message = "Add failed";
				}

			}
			await GetData();
		}



		public async Task GetData()
		{
			ShiftListResponse response = await shiftService.GetAll();
			Shifts = response.Result.ToList();
			MedstaffListResponse responseMed = await medstaffService.GetAll();
			Medstaffs = responseMed.Result.ToList();

		}

	}
}
