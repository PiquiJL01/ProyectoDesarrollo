using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;

namespace ProyectoDesarrollo.Persistence.DAO
{
    public class UsuariosDAO
    {
        public readonly DataBaseContext DbContext;

        public UsuariosDAO(DataBaseContext dbContext)
        {
            DbContext = dbContext;
        }

        public void GetUsuario(int id)
        {
            var usuario = DbContext.Usuarios.Add(new Usuario());
        }
    }
}
