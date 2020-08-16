using System;
namespace SchoolBook.ViewModels
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public  bool LoginError { get; set; }

        public bool SessionEnded { get; set; }
    }
}
