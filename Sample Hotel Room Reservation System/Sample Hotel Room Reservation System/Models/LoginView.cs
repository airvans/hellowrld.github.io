﻿using System.ComponentModel.DataAnnotations;

namespace Sample_Hotel_Room_Reservation_System.Models
{
    public class LoginView
    {

        [Required(ErrorMessage = "Username is required.")]
        [Display(Name = "Username")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }

        public LoginView()
        {

        }

        public LoginView(string username, string passWord, bool rememberMe)
        {
            Username = username;
            Password = passWord;
            RememberMe = rememberMe;
        }
    }
}
