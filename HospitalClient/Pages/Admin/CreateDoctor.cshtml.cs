using HospitalClient.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospitalClient.Pages.Admin
{
    [Authorize(Roles = "ADMIN")]
    public class CreateDoctorModel : PageModel
    {
        private UserService userService;
        private DoctorRegisterRequest request;

        public CreateDoctorModel(UserService userService)
        {
            this.userService = userService;
        }

        public string Message { get; set; }
        public async void OnGet()
        {
         
        }

        public async void OnPost()
        {
            try
            {
                DoctorRegisterResponse response = await userService.DoctorRegister(request);

                Message = response.Message;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
    }
}
