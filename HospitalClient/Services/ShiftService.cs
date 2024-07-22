namespace HospitalClient.Services
{
	public class ShiftService
	{
		private Shifter.ShifterClient shifterClient;

		public ShiftService(Shifter.ShifterClient shifterClient)
		{
			this.shifterClient = shifterClient;
		}

		public async Task<ShiftListResponse> GetAll()
		{
			return await shifterClient.GetListAsync(new Google.Protobuf.WellKnownTypes.Empty());
		}
	}
}
