using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using WebDesicionTable.Models;
using System.Configuration;

namespace WebDesicionTable.Controllers
{
    public class AccountController : Controller
    {

        //
        // POST: /Account/LogOn
        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST: /Account/LogOn
        [HttpGet]
        [HandleError]
        public ActionResult LogOn(string id)
        {
            LogOnModel model = new LogOnModel();
            string respuesta = string.Empty;

            if (ModelState.IsValid)
            {
                using (ServicioAutenticacion.Service swAutenticacion = new ServicioAutenticacion.Service())
                {
                    if (id == null)
                    {
                        
                        if (ConfigurationManager.AppSettings["Ingreso"] != null)
                        {
                            model = model.InicioAplicacion(swAutenticacion.DesEncriptar(ConfigurationManager.AppSettings["Ingreso"].ToString(), 2));
                            model.DB = swAutenticacion.BaseEmpresa(model.grupo, model.empresa);
                            respuesta = model.UserName;

                            FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                            return RedirectToAction("Create", "Admin", model);
                        }
                        else
                        {
                            throw new System.ArgumentException("Acceso Denegado");
                        }
                    }
                    else
                    {
                        //Si no genera excepción, entonces realizó bien la validación.
                        model = model.InicioAplicacion(swAutenticacion.DesEncriptar(id, 2));
                        model.DB = swAutenticacion.BaseEmpresa(model.grupo, model.empresa);
                        respuesta = swAutenticacion.usuarioValido(model.UserName, model.Password);

                        FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                        return RedirectToAction("Create", "Admin", model);
                    }
                }
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                using (ServicioAutenticacion.Service swAutenticacion = new ServicioAutenticacion.Service())
                {
                    string respuesta = string.Empty;

                    try
                    {
                        //Si no genera excepción, entonces realizó bien la validación.
                        respuesta = swAutenticacion.usuarioValido(model.UserName, model.Password);
                    }

                    catch (Exception)
                    {
                        //Si genera excepción, entonces no realizó bien la validación.
                        respuesta = string.Empty;
                    }

                    if (respuesta != "")
                    {
                        FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                        if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Create", "Admin");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Usuario o Password incorrectos.");
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogOn", "Account");
        }

        //
        // GET: /Account/Register

        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus;
                Membership.CreateUser(model.UserName, model.Password, model.Email, null, null, true, null, out createStatus);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false /* createPersistentCookie */);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePassword

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {

                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);

                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}
