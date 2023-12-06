using Core.Flash;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SampleApp.Models;

namespace SampleApp.Pages
{
    public class AuthModel : PageModel
    {

        private readonly SampleAppContext _db;
        private readonly ILogger<SampleAppContext> _logger;
        private readonly IFlasher _f;

        public AuthModel(SampleAppContext db, ILogger<SampleAppContext> logger, IFlasher f)
        {
            _db = db;
            _logger = logger;
            _f = f;
        }

        public void OnGet()
        {
        }

        [BindProperty]
        public User Input { get; set; }

        public IActionResult OnPost()
        {
            User current_user = _db.Users.Where(u => u.Email == Input.Email && u.Password == Input.Password).FirstOrDefault<User>();
            if (current_user != null)
            {

                _f.Flash(Types.Success, $"Добро пожаловать, {current_user.Name}!", dismissable: true);
                return RedirectToPage("Index");
            }
            else
            {
                _f.Flash(Types.Danger, $"Неверный логин или пароль!", dismissable: true);
                return Page();
            }
        }
    }
}
