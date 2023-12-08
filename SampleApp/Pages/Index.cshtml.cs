using Core.Flash;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SampleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace SampleApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly SampleAppContext _context;
        private readonly IFlasher _f;
        private readonly ILogger<EditModel> _log;

        public User CurrentUser { get; set; }
        public User ProfileUser { get; set; }
        public bool IsFollow { get; set; }

        public IndexModel(SampleAppContext context, IFlasher f, ILogger<EditModel> log)
        {
            _context = context;
            _f = f;
            _log = log;
        }

        public async Task<IActionResult> OnGetAsync([FromRoute] int? id)
        {
            var sessionId = HttpContext.Session.GetString("SampleSession");
            ProfileUser = await _context.Users.Include(u => u.Microposts).FirstOrDefaultAsync(m => m.Id == id) as User;
            CurrentUser = await _context.Users.Include(u => u.Microposts).FirstOrDefaultAsync(m => m.Id.ToString() == sessionId) as User;

            // если текущий пользователь подписан на профиль пользователя
            var result = _context.Relations.Where(r => r.Follower == CurrentUser && r.Followed == ProfileUser).FirstOrDefault();

            if (result != null)
            {
                IsFollow = true;
            }
            else
            {
                IsFollow = false;
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(string message)
        {
            var sessionId = HttpContext.Session.GetString("SampleSession");
            CurrentUser = await _context.Users.Include(u => u.Microposts).FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(sessionId));

            if (!string.IsNullOrWhiteSpace(message))
            {
                var m = new Micropost()
                {
                    Content = message,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    UserId = CurrentUser.Id,
                    //User = this.User
                };

                try
                {
                    _context.Microposts.Add(m);
                    _context.SaveChanges();
                    _f.Flash(Types.Success, $"Tweet!", dismissable: true);
                    return RedirectToPage();
                }
                catch (Exception ex)
                {
                    _log.Log(LogLevel.Error, $"Ошибка создания сообщения: {ex.InnerException.Message}");
                }


                return Page();
            }
            else
            {
                return Page();
            }

        }
    }
}