using Grpc.Net.Client;
using HospitalClient.Intercreptor;
using HospitalClient.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace HospitalClient
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddHttpContextAccessor();
			builder.Services.AddRazorPages();
			builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
			{
				opt.AccessDeniedPath = "/User/Denied";
			});
			builder.Services.AddTransient<UserService>();
			builder.Services.AddTransient<AppointmentService>();
			builder.Services.AddTransient<MedstaffService>();
			builder.Services.AddTransient<ShiftService>();
			builder.Services.AddTransient<FeedbackService>();

			builder.Services.AddTransient<AuthorizationHeaderInterceptor>();
			string ServerAddress = builder.Configuration["ApiUrls:MyApi"];
			GrpcChannel grpcChannel = GrpcChannel.ForAddress(ServerAddress);
			builder.Services.AddSingleton<GrpcChannel>(grpcChannel);

			builder.Services.AddGrpcClient<Userer.UsererClient>(o =>
			{
				o.Address = new Uri(builder.Configuration["ApiUrls:MyApi"]);
			})
				.AddInterceptor(config =>

					config.GetRequiredService<AuthorizationHeaderInterceptor>()
				);

			builder.Services.AddGrpcClient<Appointmenter.AppointmenterClient>(o =>
			{
				o.Address = new Uri(builder.Configuration["ApiUrls:MyApi"]);
			})
			   .AddInterceptor(config =>

				   config.GetRequiredService<AuthorizationHeaderInterceptor>()
			   );

			builder.Services.AddGrpcClient<Shifter.ShifterClient>(o =>
			{
				o.Address = new Uri(builder.Configuration["ApiUrls:MyApi"]);
			})
			  .AddInterceptor(config =>

				  config.GetRequiredService<AuthorizationHeaderInterceptor>()
			  );

			builder.Services.AddGrpcClient<Meddstaffer.MeddstafferClient>(o =>
			{
				o.Address = new Uri(builder.Configuration["ApiUrls:MyApi"]);
			})
		  .AddInterceptor(config =>

			  config.GetRequiredService<AuthorizationHeaderInterceptor>()
		  );

			builder.Services.AddGrpcClient<Feedbacker.FeedbackerClient>(o =>
			{
				o.Address = new Uri(builder.Configuration["ApiUrls:MyApi"]);
			})
		  .AddInterceptor(config =>

			  config.GetRequiredService<AuthorizationHeaderInterceptor>()
		  );



			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();


			app.MapRazorPages();

			app.Run();
		}
	}
}