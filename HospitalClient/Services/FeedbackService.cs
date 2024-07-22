namespace HospitalClient.Services
{
	public class FeedbackService
	{

		private Feedbacker.FeedbackerClient feedbackerClient;

		public FeedbackService(Feedbacker.FeedbackerClient feedbackerClient)
		{
			this.feedbackerClient = feedbackerClient;
		}

		public async Task<FeedbackResponse> AddFeedback(FeedbackAddRequest request)
		{
			return await feedbackerClient.AddFeedbackAsync(request);
		}
	}
}
