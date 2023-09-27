using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;

namespace TodoList.Areas.Identity.Pages.Account
{

    public class RegisterConfirmationModel : PageModel
    {


        public RegisterConfirmationModel()
        {

        }
        public string UserName { get; set; }
        public string Email { get; set; }



        public IActionResult OnGet(string userName, string email)
        {
            UserName = userName;
            Email = email;

            return Page();
        }
    }
}
