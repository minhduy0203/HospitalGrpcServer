using AutoMapper;
using HospitalManagementProject.Models;

namespace HospitalManagementProject.Mappers
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<RegisterRequest, User>();
			CreateMap<RegisterRequest, RegisterResponse>();
			CreateMap<DoctorRegisterRequest, DoctorRegisterResponse>();
			CreateMap<DoctorRegisterRequest, User>()
				.ForMember(dest => dest.MedStaff , opt => opt.MapFrom(src => new MedStaff
				{
					Qualification = src.Qualification,
					Experience = src.Experience,
				}));
		}
	}
}
