using GymManager.ApplicationServices.Members;
using GymManager.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GymManager.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMembersAppService _membersAppService;
        public HomeController(IMembersAppService membersAppService)
        {
            _membersAppService = membersAppService;
        }
        public async Task<IActionResult> Index()
        {
            List<Member> members = await _membersAppService.GetMembersAsync();
            return View(members);
        }
    }
}
