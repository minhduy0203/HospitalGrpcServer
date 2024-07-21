using AutoMapper;
using Grpc.Core;
using HospitalManagementProject.Models;
using HospitalManagementProject.Repository;
using HospitalManagementProject.Utils;

namespace HospitalManagementProject.Services
{
	public class PrescriptionService : Prescriptioner.PrescriptionerBase
	{

		IPrescriptionRepository prescriptionRepository;
		IMapper mapper;

		public PrescriptionService(IPrescriptionRepository prescriptionRepository, IMapper mapper)
		{
			this.prescriptionRepository = prescriptionRepository;
			this.mapper = mapper;
		}

		public override Task<PrescriptionAddResponse> AddPrescription(PrescriptionAddRequest request, ServerCallContext context)
		{
			Prescription prescription = mapper.Map<PrescriptionAddRequest, Prescription>(request);
			Prescription result = prescriptionRepository.Add(prescription , request.AppointmentId);
			PrescriptionAddResponse response = mapper.Map<Prescription, PrescriptionAddResponse>(result);
			response.Message = Constants.SUCCESSFULLY_MESSAGE;
			response.IsSuccess = true;
			return Task.FromResult(response);
		}
	}
}
