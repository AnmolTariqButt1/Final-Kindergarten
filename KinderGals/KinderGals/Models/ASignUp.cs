//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KinderGals.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class ASignUp
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Enter your ID")]
        [Display(Name = "ID")]
        public string UserID { get; set; }


        [Required(ErrorMessage = "Enter your Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "6 characters are Required")]
        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Confirm your Password")]
        [Display(Name = "ConfirmPassword")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "6 characters are Required")]
        [Compare("Password", ErrorMessage = "Password do not match")]
        public string ConfirmPassword { get; set; }

    }
}
