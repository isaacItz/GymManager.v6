using GymManager.ApplicationServices.Members;
using GymManager.Core.Entities;
using GymManager.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;


namespace GymManager.Web.Controllers
{
    [Authorize]
    public class MembersController : Controller
    {
        private readonly IMembersAppService _membersAppService;
        private readonly ILogger<MembersController> _logger;

        public MembersController(IMembersAppService membersAppService, ILogger<MembersController> logger)
        {
            _logger = logger;
            _membersAppService = membersAppService;
            
        }
        public async Task<IActionResult> Index()
        {
            List<Member> members = await _membersAppService.GetMembersAsync();
            //Debug.WriteLine("MEMBERS: " + members);
            MemberListViewModel viewModel = new MemberListViewModel();
            viewModel.Members = members;
            viewModel.NewMembersCount = members.Count;
            _logger.LogWarning("Se ha entrado al index");
            return View(viewModel);
        }

        public IActionResult MemberIn()
        {
            return View("MemberIn");
        }
        public IActionResult MemberOut()
        {
            return View(MemberOut);
        }
        public IActionResult Test()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MemberViewModel viewModel)
        {
            var member = ToMember(viewModel, false);
            await _membersAppService.AddMemberAsync(member);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int memberId)
        {
            await _membersAppService.DeleteMemberAsync(memberId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int memberID)
        {
            Member member = await _membersAppService.GetMemberAsync(memberID);
            MemberViewModel viewModel = ToViewModel(member);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MemberViewModel memberViewModel)
        {

            Console.WriteLine(memberViewModel);
            var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y=>y.Count>0)
                           .ToList();
            foreach(var i in errors) {
                Console.WriteLine(i);
            }

            var message = string.Join(" | ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
            Console.WriteLine(message);
            //return new HttpStatusCodeResult(HttpStatusCode.BadRequest, message);
            if(ModelState.IsValid) {
                Member member = ToMember(memberViewModel, true);
                await _membersAppService.EditMemberAsync(member);
                return RedirectToAction("Index");
            }
            return View(memberViewModel);

        }

        private MemberViewModel ToViewModel(Member m) {
            MemberViewModel viewModel = new MemberViewModel{
                Id = m.Id,
                Name = m.Name,
                LastName = m.LastName,
                BirthDay = m.BirthDay.ToDateTime(TimeOnly.Parse("12:00 AM")),
                CityId = m.City.Id,
                Email = m.Email,
                AllowNewsLetter = m.AllowNewsLetter,
            };
            
            return viewModel;
        }

        private Member ToMember(MemberViewModel viewModel, bool update) {
            Member member = new Member{
                Id = viewModel.Id,
                Name = viewModel.Name,
                LastName = viewModel.LastName,
                BirthDay = DateOnly.FromDateTime(viewModel.BirthDay),
                City = new City{
                    Id = viewModel.CityId,
                },
                Email = viewModel.Email,
                AllowNewsLetter = viewModel.AllowNewsLetter,
            };

            if(!update) member.RegisteredDate = DateOnly.FromDateTime(DateTime.Now);
            return member;
        }
    }
}
