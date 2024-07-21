using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using HospitalManagementProject.Models;
using HospitalManagementProject.Repository;
using HospitalManagementProject.Utils;

namespace HospitalManagementProject.Services
{
	public class ShiftService : Shifter.ShifterBase
	{
		private IShiftRespository shiftRespository;
		private IMapper mapper;

		public ShiftService(IShiftRespository shiftRespository, IMapper mapper)
		{
			this.shiftRespository = shiftRespository;
			this.mapper = mapper;
		}

		public override Task<ShiftListResponse> GetList(Empty request, ServerCallContext context)
		{
			List<Shift> result = shiftRespository
				.GetAll()
				.ToList();
			List<ShiftResponse> list = mapper.Map<List<Shift>, List<ShiftResponse>>(result);
			ShiftListResponse response = new ShiftListResponse()
			{
				Message = Constants.SUCCESSFULLY_MESSAGE,
				IsSuccess = true,
			};

			response.Result.AddRange(list);
			return Task.FromResult(response);
		}
	}
}
