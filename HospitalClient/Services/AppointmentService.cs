namespace HospitalClient.Services
{
	public class AppointmentService
	{
		Appointmenter.AppointmenterClient appointmenterClient;

		public AppointmentService(Appointmenter.AppointmenterClient appointmenterClient)
		{
			this.appointmenterClient = appointmenterClient;
		}

		public async Task<AppointmentListResponse> GetListAppointment(AppointmentListRequest request)
		{
			return await appointmenterClient.GetListAsync(request);
		}

		public async Task<AppointmentDetailResponse> GetAppointment(AppointmentRequest request)
		{
			return await appointmenterClient.GetAsync(request);
		}

		public async Task<AppointmentUpdateStatusResponse> UpdateAppointmentStatus(AppointmentUpdateStatusRequest request)
		{
			return await appointmenterClient.UpdateAppointmentStatusAsync(request);
		}

		public async Task<UpdateAppointmentResponse> UpdateAppointment(UpdateAppointmentRequest request)
		{
			return await appointmenterClient.UpdateAppointmentAsync(request);
		}

		public async Task<AppointmentDetailResponse> AddAppointment(AppointmentAddRequest request)
		{
			return await appointmenterClient.AddAsync(request);
		}

		public async Task<AppointmentListResponse> GetListOfMedstaff(AppointmentListScheduleRequest request)
		{
			return await appointmenterClient.GetListOfMedstaffAsync(request);
		}

		public async Task<AppointmentListResponse> GetListOfPatient(AppointmentListSchedulePatientRequest request)
		{
			return await appointmenterClient.GetListOfPatientAsync(request);
		}

	}
}
