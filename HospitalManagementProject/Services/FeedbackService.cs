using AutoMapper;
using Grpc.Core;
using HospitalManagementProject.Models;
using HospitalManagementProject.Repository;
using HospitalManagementProject.Utils;

namespace HospitalManagementProject.Services
{
	public class FeedbackService : Feedbacker.FeedbackerBase
	{

		private IFeedbackRepository feedbackRepository;
		private IMapper mapper;
		public FeedbackService(IFeedbackRepository feedbackRepository, IMapper mapper)
		{
			this.feedbackRepository = feedbackRepository;
			this.mapper = mapper;
		}

		public override Task<FeedbackResponse> AddFeedback(FeedbackAddRequest request, ServerCallContext context)
		{

			Feedback feedback = mapper.Map<FeedbackAddRequest, Feedback>(request);
			Feedback result = feedbackRepository.AddFeedback(feedback, request.AppointmentId);
			FeedbackResponse response = mapper.Map<Feedback, FeedbackResponse>(result);
			response.Message = Constants.SUCCESSFULLY_MESSAGE;
			response.IsSuccess = true;
			return Task.FromResult(response);
		}
	}
}
