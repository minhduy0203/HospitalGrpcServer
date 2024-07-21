using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using HospitalManagementProject.Models;

namespace HospitalManagementProject.Mappers
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			//User
			CreateMap<User, UserResponse>();
			CreateMap<RegisterRequest, User>();
			CreateMap<RegisterRequest, RegisterResponse>();
			CreateMap<DoctorRegisterRequest, DoctorRegisterResponse>();
			CreateMap<DoctorRegisterRequest, User>()
				.ForMember(dest => dest.MedStaff , opt => opt.MapFrom(src => new MedStaff
				{
					Qualification = src.Qualification,
					Experience = src.Experience,
				}));

			//Appointment
			CreateMap<Appointment, AppointmentResponse>()
				.ForMember(dest => dest.Date , opt => opt.MapFrom(src => Timestamp.FromDateTime(src.Date.ToLocalTime().ToUniversalTime())))
				.ForMember(dest => dest.Shift, opt => opt.MapFrom(src => new ShiftResponse {Start = src.Shift.Start.ToString(),End = src.Shift.End.ToString() , Id = src.Shift.Id }))
				;
			CreateMap<Appointment, AppointmentDetailResponse>()
			.ForMember(dest => dest.Date, opt => opt.MapFrom(src => Timestamp.FromDateTime(src.Date.ToLocalTime().ToUniversalTime())))
			.ForMember(dest => dest.Shift, opt => opt.MapFrom(src => new ShiftResponse { Start = src.Shift.Start.ToString(), End = src.Shift.End.ToString(), Id = src.Shift.Id })); ;
			CreateMap<AppointmentAddRequest, Appointment>()
				.ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToDateTime().ToLocalTime()))
				;



			//Patient
			CreateMap<Patient, PatientResponse>();
		

			//Medstaff
			CreateMap<MedStaff, MedstaffResponse>();


		}
	}
}
