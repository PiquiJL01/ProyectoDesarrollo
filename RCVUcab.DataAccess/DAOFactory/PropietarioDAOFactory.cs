using RCVUcab.DataAccess.DAOs.Implementations;

namespace RCVUcab.DataAccess.DAOFactory;

public static class PropietarioDAOFactory
{
    public static PropietarioDAO CreatePropietarioDao()
    {
        return new PropietarioDAO();
    }
}