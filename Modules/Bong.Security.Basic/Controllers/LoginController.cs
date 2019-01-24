using Bong.Security.Basic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Bong.Security.Basic.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfigurationRoot _configuration;
        private readonly IAuthenticationLogic _authenticationLogic;

        public LoginController(IConfigurationRoot configuration, IAuthenticationLogic authenticationLogic)
        {
            _configuration = configuration;
            _authenticationLogic = authenticationLogic;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            var login = _configuration.GetValue(typeof(string), "Security:Bong.Security.Basic:Login").ToString();
            var password = _configuration.GetValue(typeof(string), "Security:Bong.Security.Basic:Password").ToString();

            if (login != model.Login || password != model.Password)
            {
                return View();
            }

            var token = _authenticationLogic.GetToken();
            HttpContext.Response.Cookies.Append("Bong.Security.Basic.Token", token);

            return Redirect("~/admin");
        } 
    }
}