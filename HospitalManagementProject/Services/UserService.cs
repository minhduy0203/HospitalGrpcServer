using AutoMapper;
using Grpc.Core;
using HospitalManagementProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HospitalManagementProject.GrpcServices
{
	public class UserService : Userer.UsererBase
	{

		private SignInManager<User> signInManager;
		private UserManager<User> userManager;
		private RoleManager<IdentityRole> roleManager;
		private IConfiguration configuration;
		private IMapper mapper;

		public UserService(SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IMapper mapper)
		{
			this.signInManager = signInManager;
			this.userManager = userManager;
			this.roleManager = roleManager;
			this.configuration = configuration;
			this.mapper = mapper;
		}

		public override async Task<RegisterResponse> AdminRegister(RegisterRequest request, ServerCallContext context)
		{
			User u = mapper.Map<RegisterRequest, User>(request);
			var result = await userManager.CreateAsync(u, request.Password);
			RegisterResponse response = mapper.Map<RegisterRequest, RegisterResponse>(request);

			if (result.Succeeded)
			{
				await userManager.AddToRoleAsync(u, "ADMIN");
				response.IsSuccess = true;
				response.Message = "Create account succecssfully";
			}
			else
			{
				response.IsSuccess = false;
				response.Message = "Create account failed";
			}
			return response;
		}

		public override async Task<DoctorRegisterResponse> DoctorRegister(DoctorRegisterRequest request, ServerCallContext context)
		{
			User u = mapper.Map<DoctorRegisterRequest, User>(request);
			var result = await userManager.CreateAsync(u, request.Password);
			DoctorRegisterResponse response = mapper.Map<DoctorRegisterRequest, DoctorRegisterResponse>(request);

			if (result.Succeeded)
			{
				await userManager.AddToRoleAsync(u, "DOCTOR");
				response.IsSuccess = true;
				response.Message = "Create account succecssfully";
			}
			else
			{
				response.IsSuccess = false;
				response.Message = "Create account failed";
			}
			return response;
		}

		public override async Task<LoginResponse> Login(LoginRequest request, ServerCallContext context)
		{
			LoginResponse response;
			var user = await userManager.FindByEmailAsync(request.Email);
			if (user == null)
			{
				response = new LoginResponse
				{
					Message = "Login failed",
					Token = "",
					IsSuccess = false,
				};
			}
			else
			{
				var result = await signInManager.PasswordSignInAsync(user.UserName, request.Password, false, false);
				if (!result.Succeeded)
				{
					response = new LoginResponse
					{
						Message = "Login failed",
						Token = "",
						IsSuccess = false
					};
				}
				else
				{
					string role = userManager.GetRolesAsync(user).Result.FirstOrDefault();

					List<Claim> claims = new List<Claim>()
				{
					new Claim(ClaimTypes.Name , user.UserName),
					new Claim(ClaimTypes.Role, role),
				};
					Claim idClaim;
					if (role.Equals("PATIENT"))
					{
						idClaim = new Claim("Id", user.PatientId.ToString());
					} else
					{
						idClaim = new Claim("Id", user.MedStaffId.ToString());
					}
					claims.Add(idClaim);

					var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
					var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
					var expiry = DateTime.Now.AddDays(Convert.ToInt32(configuration["Jwt:ExpiryInDays"]));
					var token = new JwtSecurityToken(
						configuration["Jwt:Issuer"],
						configuration["Jwt:Audience"],
						claims,
						expires: expiry,
						signingCredentials: creds
						);

					response = new LoginResponse
					{
						Message = "Login successfully",
						Token = new JwtSecurityTokenHandler().WriteToken(token),
						IsSuccess = true
					};
				}

			}

			return response;
		}

		public async override Task<RegisterResponse> Register(RegisterRequest request, ServerCallContext context)
		{
			User u = mapper.Map<RegisterRequest, User>(request);
			u.Patient = new Patient();
			var result = await userManager.CreateAsync(u, request.Password);
			RegisterResponse response = mapper.Map<RegisterRequest, RegisterResponse>(request);

			if (result.Succeeded)
			{
				await userManager.AddToRoleAsync(u, "PATIENT");
				response.IsSuccess = true;
				response.Message = "Create account succecssfully";
			}
			else
			{
				response.IsSuccess = false;
				response.Message = "Create account failed";
			}
			return response;
		}

		public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
		{
			return Task.FromResult(new HelloReply
			{
				Message = "Hello " + request.Name
			});
		}


	}
}
