﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TrippingPortal.Core;
using TrippingPortal.Core.Entities;
using TrippingPortal.WebApp.Models;

namespace TrippingPortal.WebApp.Controllers
{
    public class UserManageController : Controller
    {
        private readonly UserManager<Utility> _userManager;
        private readonly ILogger _logger;

        public UserManageController(UserManager<Utility> userManager, ILogger<UserManageController> logger)
        {
            // acquire user manager via dependency injection
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            UserListVM vm = new UserListVM();
            vm.Users = new List<UserListItemVM>();
            // get the list of users
            List<Utility> users = await _userManager.Users.ToListAsync();
            foreach (Utility user in users)
            {
                // get user is of admin role
                bool isAdmin = (await _userManager.GetRolesAsync(user)).Any(r => r == SecurityConstants.AdminRoleString);
                if (!isAdmin)
                {
                    // add user to vm only if not admin
                    vm.Users.Add(new UserListItemVM
                    {
                        UserId = user.Id,
                        Username = user.UserName,
                        Email = user.Email
                    });
                }

            }
            return View(vm);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreateVM vm)
        {
            if (ModelState.IsValid)
            {
                Utility user = new Utility { UserName = vm.Username, Email = vm.Email };
                IdentityResult result = await _userManager.CreateAsync(user, vm.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    return RedirectToAction(nameof(Index));
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(vm);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Utility user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            UserEditVM vm = new UserEditVM()
            {
                Email = user.Email,
                Username = user.UserName
            };
            return View(vm);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, UserEditVM vm)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return NotFound();
                }

                Utility user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                List<IdentityError> identityErrors = new List<IdentityError>();
                // change password if not null
                string newPassword = vm.Password;
                if (newPassword != null)
                {
                    string passResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                    IdentityResult passResetResult = await _userManager.ResetPasswordAsync(user, passResetToken, newPassword);
                    if (passResetResult.Succeeded)
                    {
                        _logger.LogInformation("User password changed");
                    }
                    else
                    {
                        identityErrors.AddRange(passResetResult.Errors);
                    }
                }

                // change username if changed
                if (user.UserName != vm.Username)
                {
                    IdentityResult usernameChangeResult = await _userManager.SetUserNameAsync(user, vm.Username);
                    if (usernameChangeResult.Succeeded)
                    {
                        _logger.LogInformation("Username changed");

                    }
                    else
                    {
                        identityErrors.AddRange(usernameChangeResult.Errors);
                    }
                }

                // change email if changed
                if (user.Email != vm.Email)
                {
                    string emailResetToken = await _userManager.GenerateChangeEmailTokenAsync(user, vm.Email);
                    IdentityResult emailChangeResult = await _userManager.ChangeEmailAsync(user, vm.Email, emailResetToken);
                    if (emailChangeResult.Succeeded)
                    {
                        _logger.LogInformation("email changed");
                    }
                    else
                    {
                        identityErrors.AddRange(emailChangeResult.Errors);
                    }
                }

                // check if we have any errors and redirect if successful
                if (identityErrors.Count == 0)
                {
                    _logger.LogInformation("User edit operation successful");

                    return RedirectToAction(nameof(Index));
                }

                AddErrors(identityErrors);
            }

            // If we got this far, something failed, redisplay form
            return View(vm);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Utility user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            UserDeleteVM vm = new UserDeleteVM()
            {
                Email = user.Email,
                Username = user.UserName,
                UserId = user.Id
            };
            return View(vm);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(UserDeleteVM vm)
        {
            if (ModelState.IsValid)
            {
                Utility user = await _userManager.FindByIdAsync(vm.UserId);
                if (user == null)
                {
                    return NotFound();
                }

                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User deleted successfully");

                    return RedirectToAction(nameof(Index));
                }

                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(vm);
        }

        // helper function
        private void AddErrors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        // helper function
        private void AddErrors(IEnumerable<IdentityError> errs)
        {
            foreach (IdentityError error in errs)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}