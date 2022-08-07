using RCVUcab.DataAccess.DAOs.Implementations;

namespace RCVUcab.DataAccess.DAOFactory;

public static class UsuarioDAOFactory
{
    public static UsuarioDAO CreateUsuarioDao()
    {
        return new UsuarioDAO();
    }
}