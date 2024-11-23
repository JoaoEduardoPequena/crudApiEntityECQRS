using Domain.Entities;
using Domain.Models.DTOS.Usuario;

namespace Domain.Interfaces
{
    public interface IUsuarios
    {
        /*public Task<ApplicationUser> FindByNameAsync(string parametro);
        public Task<ApplicationUser> FindByIdAsync(string Id_User);
        public Task<IList<string>> GetRolesAsync(ApplicationUser user);
        public Task<bool> UpdateAsync(ApplicationUser user);
        public Task<ApplicationUser> FindByEmailAsync(string email);*/
        public Task<bool> CriarUsuario(ApplicationUser user, string password);
    }
}
