using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace WebDesicionTable.Models
{

    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Longitud máxima 20 caracteres")]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LogOnModel
    {
        [Display(Name = "Usuario"),Required(ErrorMessage="*")]
        [StringLength(20, ErrorMessage = "Longitud 20 caracteres")]
        public string UserName { get; set; }
                           
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña"),Required(ErrorMessage = "*")]
        [StringLength(20, ErrorMessage = "Longitud 20 caracteres")]
        public string Password { get; set; }

        public string IdUsuario { get; set; }
        public int grupo { get; set; }
        public int empresa { get; set; }
        public string agencia { get; set; }
        public string PasswordBd { get; set; }
        public string DB { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public LogOnModel InicioAplicacion(string pDatos)
        {
            string[] _cadena;
            _cadena = pDatos.Split(Convert.ToChar(","));
            
            LogOnModel lmlogin = new LogOnModel();

            lmlogin.UserName = _cadena[0];
            lmlogin.Password = _cadena[1];
            lmlogin.IdUsuario = _cadena[2];
            lmlogin.grupo = int.Parse(_cadena[3]);
            lmlogin.empresa = int.Parse(_cadena[4]);
            lmlogin.agencia = _cadena[5];
            lmlogin.PasswordBd = _cadena[6];
            return lmlogin;
        }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
     
}
