using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using db_cp.Models;

namespace db_cp.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Name not specified")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname not specified")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Middle name not specified")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Login not specified")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password not specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password entered incorrectly")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Login not specified")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password not specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
