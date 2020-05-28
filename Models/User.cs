﻿using System;

namespace FluentValidationExample.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ConfirmPassword { get; set; }
    }
}