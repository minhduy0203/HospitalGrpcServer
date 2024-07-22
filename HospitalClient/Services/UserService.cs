using Grpc.Net.Client;

namespace HospitalClient.Services
{
    public class UserService
    {
        private GrpcChannel channel;
        private Userer.UsererClient userClient;

        public UserService(GrpcChannel channel, Userer.UsererClient userClient)
        {
            this.channel = channel;
            this.userClient = userClient;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var client = new Userer.UsererClient(channel);
            var result = await client.LoginAsync(new LoginRequest { Email = request.Email, Password = request.Password });
            return result;
        }

        public async Task<RegisterResponse> Register(RegisterRequest request)
        {
            var result = await userClient.RegisterAsync(request);
            return result;
        }

        public async Task<DoctorRegisterResponse> DoctorRegister(DoctorRegisterRequest request)
        {
            var result = await userClient.DoctorRegisterAsync(request);
            return result;
        }
    }
}
