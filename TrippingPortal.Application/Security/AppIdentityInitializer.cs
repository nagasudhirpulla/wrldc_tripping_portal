using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using TrippingPortal.Core;
using TrippingPortal.Core.Entities;
using TrippingPortal.Core.Interfaces.Security;

namespace TrippingPortal.Application.Security
{
    public class AppIdentityInitializer : IAppIdentityInitializer
    {

        public UserManager<Utility> UserManager { get; set; }
        public RoleManager<IdentityRole> RoleManager { get; set; }
        public IConfiguration Configuration { get; set; }
        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; }
        public string AdminUserName { get; set; } = "admin";

        /**
         * This method seeds admin, guest role and admin user
         * **/
        public void SeedData()
        {
            // get admin params from configuration
            InitAdminCredentialsFromConfig();
            // seed roles
            SeedUserRoles();
            // seed admin user
            SeedAdminUser();
        }

        /**
         * This method seeds admin user
         * **/
        public void SeedAdminUser()
        {
            // check if admin user doesn't exist
            if (UserManager.FindByNameAsync(AdminUserName).Result == null)
            {
                // create desired admin user object
                Utility user = new Utility
                {
                    UserName = AdminUserName,
                    Email = AdminEmail
                };

                // push desired admin user object to DB
                IdentityResult result = UserManager.CreateAsync(user, AdminPassword).Result;

                if (result.Succeeded)
                {
                    UserManager.AddToRoleAsync(user, SecurityConstants.AdminRoleString).Wait();
                }
            }
        }

        /**
         * This method seeds roles
         * **/
        public void SeedUserRoles()
        {
            // check if role doesn't exist
            if (!RoleManager.RoleExistsAsync(SecurityConstants.GuestRoleString).Result)
            {
                // create desired role object
                IdentityRole role = new IdentityRole
                {
                    Name = SecurityConstants.GuestRoleString,
                };
                // push desired role object to DB
                IdentityResult roleResult = RoleManager.CreateAsync(role).Result;
            }


            if (!RoleManager.RoleExistsAsync(SecurityConstants.AdminRoleString).Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = SecurityConstants.AdminRoleString,
                };
                IdentityResult roleResult = RoleManager.CreateAsync(role).Result;
            }
        }

        /**
         * This method get secret admin credentials from IConfiguration
         * **/
        public void InitAdminCredentialsFromConfig()
        {
            AdminEmail = Configuration["IdentityInit:AdminEmail"];
            AdminPassword = Configuration["IdentityInit:AdminPassword"];
            AdminUserName = Configuration["IdentityInit:AdminUserName"];
        }
    }
}
