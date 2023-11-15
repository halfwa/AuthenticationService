using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace AuthenticationService.Models.Db
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public bool FromRussia { get; set; }

        public UserViewModel(User user)
        {
            Id = user.Id;
            FullName = GetFullName(user.FirstName, user.LastName);
            FromRussia = GetFromRussiaValue(user.Email);
        }

        private string GetFullName(string firstName, string lastName)
        {
            return string.Concat(firstName, " ", lastName);
        }

        private bool GetFromRussiaValue(string email)
        {
            var emailAddress = new MailAddress(email);

            if (emailAddress.Host.Contains(".ru"))
            {
                return true;
            }
            return false;
        }
    }
}
