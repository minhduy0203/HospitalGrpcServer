using Google.Protobuf.WellKnownTypes;

namespace HospitalClient.Services
{
	public class MedstaffService
	{
		private Meddstaffer.MeddstafferClient meddstafferClient;

		public MedstaffService(Meddstaffer.MeddstafferClient meddstafferClient)
		{
			this.meddstafferClient = meddstafferClient;
		}

		public async Task<MedstaffListResponse> GetAll()
		{
			Empty empty = new Empty();
			return await meddstafferClient.GetListAsync(empty);
		}
	}
}
