using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using GymManager.Core.Entities;
using GymManager.ApplicationServices.MemberMemberships;
using GymManager.Web.Models;

namespace GymManager.Web.Controllers
{
    //[Route("[controller]")]
    [Authorize]
    public class MembershipMembers : Controller
    {
        private readonly ILogger<MembershipMembers> _logger;
        private readonly IMemberMembershipsAppService _membershipsAppService;

        public MembershipMembers(ILogger<MembershipMembers> logger, IMemberMembershipsAppService memberShipsAppService)
        {
            _logger = logger;
            _membershipsAppService = memberShipsAppService;
        }

        public async Task<IActionResult> Index()
        {
            return View(null);
        }

        //public IActionResult Index(MembershipRenewal membership) {
        //    Console.WriteLine(membership);
        //    return View(membership);
        //}

        [HttpPost]
        public async Task<IActionResult> Search(MembershipRenewal membership) {
            List<MemberMembership> list = await _membershipsAppService.GetMatches(membership.SearchValue);
            //foreach (var i in list) {
                //Console.WriteLine(i);
            //}
            membership.Members = list;
            return View("Index", membership);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}