﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymTool.Library
{
    public class LUsersRoles
    {
        public List<SelectListItem> getRoles(RoleManager<IdentityRole> roleManager)
        {
            List<SelectListItem> _selectLists = new List<SelectListItem>();
            var roles = roleManager.Roles.ToList();
            roles.ForEach(item =>
            {
                _selectLists.Add(new SelectListItem
                {
                    Value = item.Id,
                    Text = item.Name
                });
            });
            return _selectLists;
        }

        public async Task<List<SelectListItem>> getRole(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            string ID)
        {
            List<SelectListItem> _selectList = new List<SelectListItem>();
            var users = await userManager.FindByIdAsync(ID);
            var roles = await userManager.GetRolesAsync(users);
            if (roles.Count.Equals(0))
            {
                _selectList.Add(new SelectListItem
                {
                    Value = "0",
                    Text = "No hay tipo"
                });
            }
            else
            {
                var roleUser = roleManager.Roles.Where(m => m.Name.Equals(roles[0]));
                foreach (var Data in roleUser)
                {
                    _selectList.Add(new SelectListItem
                    {
                        Value = Data.Id,
                        Text = Data.Name
                    });
                }
            }
            return _selectList;
        }


    }
}
