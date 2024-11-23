using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Persistence.Repositories
{
    public class RepoUsuarios : IUsuarios
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public RepoUsuarios(UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager, 
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public async Task<bool> CriarUsuario(ApplicationUser user, string password)
        {
            var result = await _userManager.CreateAsync(user);
            return result.Succeeded;
        }
    }
}
