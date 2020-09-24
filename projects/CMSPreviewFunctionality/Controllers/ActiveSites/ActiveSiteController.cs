using Microsoft.AspNetCore.Mvc;

namespace CMSPreviewFunctionality.Controllers.ActiveSites
{
    public class ActiveSiteController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}