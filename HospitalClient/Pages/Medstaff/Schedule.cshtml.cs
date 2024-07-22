using HospitalClient.Services;
using HospitalClient.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using System.Security.Claims;

namespace HospitalClient.Pages.Medstaff
{
	[Authorize(Roles ="DOCTOR")]
	public class ScheduleModel : PageModel
	{

		[BindProperty]
		public int week { get; set; }
		[BindProperty]
		public int year { get; set; } = DateTime.Now.Year;
		public List<string> schedulesWeek { get; set; }
		public List<int> scheduleYear { get; set; }
		public List<AppointmentResponse> Appointments { get; set; }

		private AppointmentService appointmentService;
		private IHttpContextAccessor httpContextAccessor;

		public ScheduleModel(AppointmentService appointmentService, IHttpContextAccessor httpContextAccessor)
		{
			this.appointmentService = appointmentService;
			this.httpContextAccessor = httpContextAccessor;
		}

		public async Task OnGet()
		{
			DateTime dt = DateTime.Now;
			Calendar cal = new CultureInfo("en-US").Calendar;
			week = cal.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
			await GetData();
		}

		public async Task OnPostSchedule()
		{
			await GetData();
		}

		public async Task GetData()
		{
			Claim c = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("Id"));
			int medstaffId = Int32.Parse(c.Value);
			AppointmentListResponse response = await appointmentService.GetListOfMedstaff(new AppointmentListScheduleRequest
			{

				MedstaffId = medstaffId,
				Week = week,
				Year = year
			});
			Appointments = response.Result.ToList();
			schedulesWeek = DateLogic.GetAllWeeksInYear(year);
			scheduleYear = new List<int>();
			for (int i = DateTime.Now.Year - 2; i <= DateTime.Now.Year + 1; i++)
			{
				scheduleYear.Add(i);
			}

		}
	}
}
