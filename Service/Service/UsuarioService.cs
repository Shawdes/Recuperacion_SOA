using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repository.DBContext;
using Service;

namespace SOA_MVC.Servicios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ApplicationDBContext _dbContext;
        public UsuarioService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario> GetUsuario(string correo, string clave)
        {
            Usuario usuario_encontrado = await _dbContext.Usuarios.Where(u => u.Email == correo && u.Password == clave)
                 .FirstOrDefaultAsync();

            return usuario_encontrado;
        }

        public async Task<Usuario> SaveUsuario(Usuario modelo)
        {
            _dbContext.Usuarios.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }
    }
}
