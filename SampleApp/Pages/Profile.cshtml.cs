using Core.Flash;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SampleApp.Models;

namespace SampleApp.Pages
{
    public class ProfileModel : PageModel
    {

        private readonly SampleAppContext _context;
        private readonly IFlasher _f;
        private readonly ILogger<EditModel> _log;

        public User CurrentUser { get; set; }
        public User ProfileUser { get; set; }

        public ProfileModel(SampleAppContext context, IFlasher f, ILogger<EditModel> log)
        {
            _context = context;
            _f = f;
            _log = log;
        }

        public async Task<IActionResult> OnGetAsync([FromRoute] int? id)

         {

           ProfileUser = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
           var sessionId = HttpContext.Session.GetString("SampleSession");
           CurrentUser = await _context.Users.FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(sessionId));
           return Page();
         }
    }
}
