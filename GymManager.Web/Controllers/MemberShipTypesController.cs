using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using GymManager.Core.Entities;
using GymManager.ApplicationServices.MemberShips;
using GymManager.Web.Models;

namespace GymManager.Web.Controllers
{
    [Authorize]
    //[Route("[controller]")]
    public class MemberShipTypesController : Controller
    {
        private readonly ILogger<MemberShipTypesController> _logger;
        private readonly IMemberShipsAppService _memberShipsAppService;

        public MemberShipTypesController(IMemberShipsAppService memberShipsAppService, ILogger<MemberShipTypesController> logger)
        {
            _logger = logger;
            _memberShipsAppService = memberShipsAppService;
            
        }

        public async Task<IActionResult> Index()
        {
            List<Membership> list = await _memberShipsAppService.GetMemberShipsAsync();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MembershipViewModel viewModel)
        {
            var member = ToMembership(viewModel, false);
            await _memberShipsAppService.AddMemberShipAsync(member);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int memberId)
        {
            await _memberShipsAppService.DeleteMemberShipAsync(memberId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int memberID)
        {
            Membership member = await _memberShipsAppService.GetMemberShipAsync(memberID);
            MembershipViewModel viewModel = ToViewModel(member);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MembershipViewModel viewModel)
        {
            if(ModelState.IsValid) {
                Membership membership = ToMembership(viewModel, true);
                await _memberShipsAppService.EditMemberShipsAsync(membership);
                return RedirectToAction("Index");
            }
            return View(viewModel);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        private MembershipViewModel ToViewModel(Membership m) {
            MembershipViewModel viewModel = new MembershipViewModel{
                Id = m.Id,
                Name = m.Name,
                Cost = m.Cost,
                Duration = m.Duration,
            };
            
            return viewModel;
        }

        private Membership ToMembership(MembershipViewModel viewModel, bool update) {
            Membership membership = new Membership{
                Id = viewModel.Id,
                Name = viewModel.Name,
                Cost = viewModel.Cost,
                Duration = viewModel.Duration,
            };

            if(!update) {
                membership.CreatedOn = DateTime.Now;
                membership.DurationMeasure = "Month";
                Console.WriteLine("Hola");
            } 
                Console.WriteLine("Hola");
            return membership;
        }
    }
}