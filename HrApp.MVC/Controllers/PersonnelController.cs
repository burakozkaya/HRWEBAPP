﻿using System.Security.Claims;
using AspNetCoreHero.ToastNotification.Abstractions;
using HrApp.MVC.Areas.Admin.Models.Personnel;
using HrApp.MVC.Helpers;
using HrApp.MVC.Models.Personnel;
using HrApp.MVC.Validator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HrApp.MVC.Controllers
{
    [Authorize]
    public class PersonnelController : Controller
    {
        private readonly PersonelClientService personelClientService;
        private readonly ResponseHandler responseHandler;

        public INotyfService _notifyService { get; }
        public PersonnelController(INotyfService notifyService, AppUserUpdateViewModelValidator updateValidator, PersonelClientService personelClientService, ResponseHandler responseHandler)
        {
            _notifyService = notifyService;
            this.personelClientService = personelClientService;
            this.responseHandler = responseHandler;
        }
        [HttpGet]
        public async Task<IActionResult> Details(string id) =>
            responseHandler.HandleResponse(await personelClientService.GetAppUserDetailViewModelAsync(User.FindFirstValue("nameid")), "Details", "Details", this);

        [HttpGet]
        public async Task<IActionResult> UpdateAsync() =>
            responseHandler.HandleResponse(await personelClientService.GetAppUserUpdateAsync(User.FindFirstValue("nameid")), "Update", "Details", this);


        [HttpPost]
        public async Task<IActionResult> Update(AppUserUpdateViewModel userViewModel) =>
             responseHandler.HandleResponse(await personelClientService.UpdateAppUserUpdateViewModelAsync(userViewModel, ModelState), "Details", "Details", this);


        [AllowAnonymous]
        [HttpGet]
        public IActionResult PasswordChange(string token, string userId)
        {
            if (token == null || userId == null)
                return RedirectToAction("Index", "Home");
            return View(new AppUserPasswordChangeApiViewModel { Token = token, Id = userId });
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> PasswordChangeAsync(AppUserPasswordChangeApiViewModel model)
        {
            return responseHandler.HandleResponse(await personelClientService.ChangePasswordAppUserViewModelAsync(model, ModelState), "Details", "Details", this);
        }

        

    }
}
