using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using ISOCertificate.DAL;
using ISOCertificate.Models;
using ISOCertificate.ViewModels.RequestOutputModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ISOCertificate.Controllers
{
    public class AJAXController : Controller
    {
        private readonly CertificateDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> _roleManager;

        public AJAXController(CertificateDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleMgr)
        {
            _userManager = userManager;
            _roleManager = roleMgr;
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetMenuOutputModel>> GetMenu(int moduleId)
        {

            var model = await _context.MenuModule.Where(p => p.ModuleId == moduleId).ToListAsync();

            //from menuModule in _context.MenuModule
            //                     join module in _context.Module on menuModule.ModuleId equals module.Id
            //                     join menus in _context.Menu on menuModule.MenuId equals menus.Id
            //                     join roleMenu in _context.MenuRole on menus.Id equals roleMenu.MenuId
            //                     join roles in _context.Roles on roleMenu.RoleId equals roles.Id
            //                     join usersrole in _context.UserRoles on roles.Id equals usersrole.RoleId
            //                     join users in _context.Users on usersrole.UserId equals users.Id
            //                     where menuModule.ModuleId == moduleId
            //                     select menus;


            var menu = new List<Menu>();

            foreach (var m in model)
            {
                menu.Add(await _context.Menu.FirstOrDefaultAsync(p => p.Id == m.Id));
            }

            return _mapper.Map<IEnumerable<GetMenuOutputModel>>(menu);
        }

    }
}