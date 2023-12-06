using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SampleApp.Models;

namespace SampleApp.Pages
{
    public class UsersModel : PageModel
    {

        private readonly SampleAppContext _db;
        public UsersModel(SampleAppContext db)
        {
            _db = db;
        }

        public IList<User> Users { get; set; }
        public new User User { get; set; }
        public string sessionId { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {

            Users = await _db.Users.ToListAsync();
            return Page();
        }

    }
}
