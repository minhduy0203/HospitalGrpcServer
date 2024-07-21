using HospitalManagementProject.GrpcServices;
using HospitalManagementProject.Mappers;
using HospitalManagementProject.Models;
using HospitalManagementProject.Repository;
using HospitalManagementProject.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HospitalManagementProject
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

		
			builder.Services.AddGrpc();
			builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
			builder.Services.AddDbContext<HospitalDBContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("Mystr")));

			builder.Services.AddIdentity<User, IdentityRole>(opt =>
			{
				opt.Password.RequiredLength = 6;
				opt.Password.RequireLowercase = false;
				opt.Password.RequireUppercase = false;
				opt.Password.RequireNonAlphanumeric = false;
			})
				.AddEntityFrameworkStores<HospitalDBContext>();

			builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateIssuerSigningKey = true,
						ValidIssuer = builder.Configuration["Jwt:Issuer"],
						ValidAudience = builder.Configuration["Jwt:Audience"],
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Key"]))
					};
				})
				;
			builder.Services.AddAuthorization();
			builder.Services.AddTransient<IAppointmentRepository, AppointmentRepository>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			app.UseAuthentication();
			app.UseAuthorization();

			app.MapGrpcService<GreeterService>();
			app.MapGrpcService<UserService>();
			app.MapGrpcService<AppointmentService>();

			app.Run();
		}
	}
}