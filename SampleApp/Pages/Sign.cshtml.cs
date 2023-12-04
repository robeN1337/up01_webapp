using Core.Flash;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SampleApp.Models;

namespace SampleApp.Pages
{
    public class SignModel : PageModel
    {
        public void OnGet()
        {
        }

        private readonly SampleAppContext _db;
        private readonly ILogger<SampleAppContext> _logger;
        private readonly IFlasher _f;
        public SignModel(SampleAppContext db, ILogger<SampleAppContext> logger, IFlasher f)
        {
            _db = db;
            _logger = logger;
            _f = f;
        }


        public IActionResult OnPost(User user)
        {

            try
            {

                _db.Users.Add(user);
                _db.SaveChanges();
                _logger.LogInformation($"Пользователь {user.Name} успешно сохранен!");
                _f.Flash(Types.Success, $"Пользователь  {user.Name} зарегистрирован!", dismissable: true);
                return RedirectToPage("./Index");

            }
            catch (Exception ex)
            {
                //return RedirectToPage("./Sign");
                _logger.LogError(ex.Message);
            }

            

            return Page();

        }

        public IActionResult RegistrationResult()
        {
            _f.Flash(Types.Success, "Flash message system for ASP.NET MVC Core", dismissable: true);
            _f.Flash(Types.Danger, "Flash message system for ASP.NET MVC Core", dismissable: false);
            return RedirectToAction("AnotherAction");
        }
    }
}
