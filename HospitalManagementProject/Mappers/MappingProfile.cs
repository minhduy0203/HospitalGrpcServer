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
		}
	}
}
