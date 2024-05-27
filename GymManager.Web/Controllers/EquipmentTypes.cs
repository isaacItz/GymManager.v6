using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using GymManager.Core.Entities;
using GymManager.ApplicationServices.EquipmentTypes;
using GymManager.Web.Models;

namespace GymManager.Web.Controllers
{
    [Authorize]
    public class EquipmentTypes : Controller
    {
        private readonly ILogger<EquipmentTypes> _logger;
        private readonly IEquipmentTypesAppService _equipmentAppService;

        public EquipmentTypes(ILogger<EquipmentTypes> logger, IEquipmentTypesAppService equipmentTypesAppService)
        {
            _logger = logger;
            _equipmentAppService = equipmentTypesAppService;
        }

        public async Task<IActionResult> Index()
        {
            List<EquipmentType> list = await _equipmentAppService.GetEquipmentTypesAsync();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EquipmentType model)
        {
            await _equipmentAppService.AddEquipmentTypeAsync(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int memberId)
        {
            await _equipmentAppService.DeleteEquipmentTypeAsync(memberId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int memberId)
        {
            EquipmentType model = await _equipmentAppService.GetEquipmentTypeAsync(memberId);
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EquipmentType model)
        {
            Console.WriteLine($"Ha llegado el modelo {model}");
            if(ModelState.IsValid) {
                await _equipmentAppService.EditEquipmentTypeAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

    }
}