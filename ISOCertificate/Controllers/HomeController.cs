using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ISOCertificate.Models;
using ISOCertificate.DAL;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ISOCertificate.ViewModels.RequestOutputModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ISOCertificate.Controllers
{
    public class HomeController : Controller
    {
        private readonly CertificateDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(CertificateDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleMgr)
        {
            _userManager = userManager;
            _roleManager = roleMgr;
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var entity = await _context.Module.ToListAsync();

            var outputmodel = _mapper.Map<IEnumerable<GetModulesOutputModel>>(entity);
            return View(outputmodel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
