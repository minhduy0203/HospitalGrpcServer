using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HospitalClient.Services;

namespace HospitalClient.Pages.User
{
	public class LoginModel : PageModel
	{
		[BindProperty]
		public LoginRequest UserLogin { get; set; }

		public string Message { get; set; }

		public UserService userService { get; set; }

		public LoginModel(UserService userService)
		{
			this.userService = userService;
		}

		public void OnGet()
		{

		}

		public async Task<IActionResult> OnPost()
		{
			try
			{
				LoginResponse response = await userService.Login(UserLogin);
				string result = response.Token;
				if (result != null && response.IsSuccess)
				{
					var handler = new JwtSecurityTokenHandler();
					var jsonToken = handler.ReadToken(result);
					var tokenS = jsonToken as JwtSecurityToken;
					string name = tokenS.Claims.FirstOrDefault(claim => claim.Type.Equals(ClaimTypes.Name))?.Value;
					string role = tokenS.Claims.FirstOrDefault(claim => claim.Type.Equals(ClaimTypes.Role))?.Value;
					string Id = tokenS.Claims.FirstOrDefault(claim => claim.Type.Equals("Id"))?.Value;



					List<Claim> claims = new List<Claim>()
			  {
				  new Claim(ClaimTypes.Name, name),
				  new Claim(ClaimTypes.Role,role),
				  new Claim("Id" , Id)
			  };
					var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
					var principal = new ClaimsPrincipal(identity);
					await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
					{
						IsPersistent = true
					});
					Message = "Login successfully";
					return Redirect("/");
				}
				else
				{
					Message = "Email or password is incorrect";
				}
				
			}
			catch (Exception ex)
			{
				Message = "Login failed";

			}

			return Page();
		}

		public async Task<IActionResult> OnPostLogout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			//Redirect to login page    
			return Redirect("/User/Login");
		}
	}
}
