using HospitalClient.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospitalClient.Pages.User
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public RegisterRequest request { get; set; }

        public string Message { get; set; }
        private UserService userService;

        public RegisterModel(UserService userService)
        {
            this.userService = userService;
        }

        public async void OnGet()
        {
        }

        public async void OnPost()
        {
            try
            {
                RegisterResponse response = await userService.Register(request);
                if (response.IsSuccess)
                {
                    Message = "Register successfully";
                }
                else
                {
                    Message = response.Message;
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;

            }
        }
    }
}
