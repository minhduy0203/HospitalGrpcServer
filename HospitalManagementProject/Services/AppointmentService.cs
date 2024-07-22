using AutoMapper;
using Grpc.Core;
using HospitalManagementProject.Models;
using HospitalManagementProject.Repository;
using HospitalManagementProject.Utils;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementProject.Services
{
	public class AppointmentService : Appointmenter.AppointmenterBase
	{
		private IAppointmentRepository appointmentRepository;
		private IMapper mapper;

		public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper)
		{
			this.appointmentRepository = appointmentRepository;
			this.mapper = mapper;
		}

		public override Task<AppointmentListResponse> GetList(AppointmentListRequest request, ServerCallContext context)
		{
			List<Appointment> appointments = appointmentRepository
				.GetAll()
				.Include(a => a.Shift)
				.Include(a => a.MedStaff)
				.ThenInclude(m => m.User)
				.Include(a => a.Patient)
				.ThenInclude(p => p.User)
				.Include(m => m.Prescription)
				.ToList();

			AppointmentListResponse response = new AppointmentListResponse()
			{
				IsSuccess = true,
				Message = Constants.SUCCESSFULLY_MESSAGE,
				
			};
			IEnumerable<AppointmentResponse> list = mapper.Map<List<Appointment>, List<AppointmentResponse>>(appointments).ToList();
			response.Result.AddRange(list);
			return Task.FromResult(response);
		}

		public override Task<AppointmentDetailResponse> Get(AppointmentRequest request, ServerCallContext context)
		{

			Appointment appointment = appointmentRepository.GetAppointment(request.Id)
				;
			AppointmentDetailResponse response = mapper.Map<Appointment, AppointmentDetailResponse>(appointment);
			response.IsSuccess = true;
			response.Message = Constants.SUCCESSFULLY_MESSAGE;
			return Task.FromResult(response);

		}

		public override Task<AppointmentDetailResponse> Delete(AppointmentRequest request, ServerCallContext context)
		{
			Appointment appointment = appointmentRepository.DeleteAppointment(request.Id);
			AppointmentDetailResponse response = mapper.Map<Appointment, AppointmentDetailResponse>(appointment);
			response.IsSuccess = true;
			response.Message = Constants.SUCCESSFULLY_MESSAGE;
			return Task.FromResult(response);

		}

		public override Task<AppointmentDetailResponse> Add(AppointmentAddRequest request, ServerCallContext context)
		{

			Appointment appointment = mapper.Map<AppointmentAddRequest, Appointment>(request);
			appointmentRepository.AddAppointment(appointment);
			AppointmentDetailResponse response = mapper.Map<Appointment, AppointmentDetailResponse>(appointment);
			response.IsSuccess = true;
			response.Message = Constants.SUCCESSFULLY_MESSAGE;
			return Task.FromResult(response);
		}

		public override Task<AppointmentListResponse> GetListOfMedstaff(AppointmentListScheduleRequest request, ServerCallContext context)
		{
			DateTime start = DateUtils.GetDateByWeek(request.Week, request.Year);
			DateTime end = start.AddDays(6);

			List<Appointment> appointments = appointmentRepository
				.GetAll()
				.Include(a => a.Shift)
				.Include(a => a.MedStaff)
				.ThenInclude(m => m.User)
				.Include(a => a.Patient)
				.ThenInclude(m => m.User)
				.Where(a => a.Date >= start && a.Date <= end)
				.Where(a => a.MedStaffId == request.MedstaffId)
				.ToList();

			AppointmentListResponse response = new AppointmentListResponse()
			{
				IsSuccess = true,
				Message = Constants.SUCCESSFULLY_MESSAGE,

			};
			IEnumerable<AppointmentResponse> list = mapper.Map<List<Appointment>, List<AppointmentResponse>>(appointments).ToList();
			response.Result.AddRange(list);
			return Task.FromResult(response);


		}

		public override Task<AppointmentListResponse> GetListOfPatient(AppointmentListSchedulePatientRequest request, ServerCallContext context)
		{
			DateTime start = DateUtils.GetDateByWeek(request.Week, request.Year);
			DateTime end = start.AddDays(6);

			List<Appointment> appointments = appointmentRepository
				.GetAll()
				.Include(a => a.Shift)
				.Include(a => a.MedStaff)
				.ThenInclude(m => m.User)
				.Include (a => a.Patient)
				.ThenInclude(m => m.User)
				.Where(a => a.Date >= start && a.Date <= end)
				.Where(a => a.PatientId == request.PatientId)
				.ToList();

			AppointmentListResponse response = new AppointmentListResponse()
			{
				IsSuccess = true,
				Message = Constants.SUCCESSFULLY_MESSAGE,

			};
			IEnumerable<AppointmentResponse> list = mapper.Map<List<Appointment>, List<AppointmentResponse>>(appointments).ToList();
			response.Result.AddRange(list);
			return Task.FromResult(response);

		}

		public override Task<AppointmentUpdateStatusResponse> UpdateAppointmentStatus(AppointmentUpdateStatusRequest request, ServerCallContext context)
		{
			Appointment appointment = appointmentRepository.UpdateAppointmentState(request.AppointmentId,(Models.Status) request.Status);
			AppointmentUpdateStatusResponse response = new AppointmentUpdateStatusResponse()
			{
				IsSuccess = true,
				Message = Constants.SUCCESSFULLY_MESSAGE,
				Status = request.Status,
				AppointmentId = request.AppointmentId,
			};

			return Task.FromResult(response);

		}

		public override Task<UpdateAppointmentResponse> UpdateAppointment(UpdateAppointmentRequest request, ServerCallContext context)
		{
			appointmentRepository.UpdateAppointment(request.AppointmentId, request.Conclusion, request.Prescription);
			return Task.FromResult(new UpdateAppointmentResponse
			{
				AppointmentId = request.AppointmentId,
				Conclusion = request.Conclusion,
				Prescription = request.Prescription,
				IsSuccess = true,
				Message = "Successfully"
			});
		}
	}
}
