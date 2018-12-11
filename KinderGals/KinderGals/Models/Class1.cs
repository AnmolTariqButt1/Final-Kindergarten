
    namespace KinderGals.Models
    {
        using System;
        using System.Collections.Generic;
        using System.ComponentModel.DataAnnotations;

        public partial class a
        {
            public int ID { get; set; }
            [Required(ErrorMessage = "Enter your User ID")]
            [Display(Name = "User ID")]
            public string UserID { get; set; }

            [Required(ErrorMessage = "Enter your Name")]
            [Display(Name = "Name")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Enter your Email")]
            [DataType(DataType.EmailAddress)]
            [RegularExpression(".+\\@.+\\..+",
            ErrorMessage = "Enter a valid Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Enter your Password")]
            [Display(Name = "Password")]
            [DataType(DataType.Password)]
            [MinLength(6, ErrorMessage = "6 characters are Required")]
            public string Password { get; set; }

            [Required(ErrorMessage = "Confirm your Password")]
            [Display(Name = "Confirm Password")]
            [DataType(DataType.Password)]
            [MinLength(6, ErrorMessage = "6 characters are Required")]
            [Compare("Password", ErrorMessage = "Password do not match")]
            public string ConfirmPassword { get; set; }

            public string Section { get; set; }
            public string Type { get; set; }
        }

    }
