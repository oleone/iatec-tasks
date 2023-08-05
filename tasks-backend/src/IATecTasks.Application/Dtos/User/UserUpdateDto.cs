using System;
using System.Collections.Generic;
using System.Text;

namespace IATecTasks.Application.Dtos.User
{
    public class UserUpdateDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
    }
}
