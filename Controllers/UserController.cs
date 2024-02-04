using Microsoft.AspNetCore.Mvc;
using YUJCSR.Web.CSO.BusinessManager;
using YUJCSR.Web.CSO.Models;

namespace YUJCSR.Web.CSO.Controllers
{
    public class UserController : Controller
    {
        IConfiguration _config;
        public UserController(IConfiguration iConfig)
        {
            _config = iConfig;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            CSOManager manager = new CSOManager(_config);
            var data = manager.LoginCheck(model);
            if (data != null && data.result != null)
            {
                HttpContext.Session.SetString("_UserName", model.UserName);
                HttpContext.Session.SetString("_CcoId", data.result.csoid);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.message = "Invalid Credential";
            }
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CSOProfileModel cso)
        {

            CSOManager manager = new CSOManager(_config);
            var status = manager.OnBoardCSO(cso);
            if (status)
            {
                ViewBag.message = "Success";
               
            }
            else
            {
                ViewBag.message = "Failure";
            }
            return View();
        }
        public IActionResult Onboarding()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Profile(CSOProfileModel model)
        {
            CSOManager manager = new CSOManager(_config);
            var profileData = manager.SaveProfileDetails(model);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Profile()
        {
            CSOProfileModel objCSO = new CSOProfileModel();

            string ccoId = HttpContext.Session.GetString("_CcoId");

            CSOManager manager = new CSOManager(_config);
            var profileData = manager.GetProfileDetails(ccoId);
            return View(profileData);
        }
    }
}
