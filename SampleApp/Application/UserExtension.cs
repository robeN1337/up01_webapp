using SampleApp.Models;

namespace SampleApp.Application
{
    public static class UserExtension
    {
        public static bool IsPasswordConfirmation(this User user)
        {
            return (user.Password == user.PasswordConfirmation) ? true : false;
        }

    }
}
