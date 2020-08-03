using AsyncInn.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class UserRepository
    {
        private AsyncInnDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public UserRepository(AsyncInnDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // https://github.com/codefellows/seattle-dotnet-401d11/blob/master/Class12/demo/StudentEnrollmentAPI/StudentEnrollmentAPI/Models/Services/UserService.cs
        public bool ValidateDistrictManager(List<Claim> claims)
        {
            return true;
        }
    }
}
