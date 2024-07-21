using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using HospitalManagementProject.Models;
using HospitalManagementProject.Repository;
using HospitalManagementProject.Utils;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementProject.Services
{
	public class MedstaffService : Meddstaffer.MeddstafferBase
	{

		private IMedstaffRepository medstaffRepository;
		private IMapper mapper;

		public MedstaffService(IMedstaffRepository medstaffRepository, IMapper mapper)
		{
			this.medstaffRepository = medstaffRepository;
			this.mapper = mapper;
		}

		public override Task<MedstaffListResponse> GetList(Empty request, ServerCallContext context)
		{
			List<MedStaff> result = medstaffRepository
				.GetAll()
				.Include(m => m.User)
				.ToList();
			List<MedstaffResponse> list = mapper.Map<List<MedStaff>, List<MedstaffResponse>>(result);
			MedstaffListResponse response =  new MedstaffListResponse()
			{
				Message = Constants.SUCCESSFULLY_MESSAGE,
				IsSuccess = true,
			};

			response.Result.AddRange(list);
			return Task.FromResult(response);

		}

		
	}
}
