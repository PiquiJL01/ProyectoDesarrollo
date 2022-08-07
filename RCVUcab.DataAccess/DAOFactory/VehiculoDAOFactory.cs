using RCVUcab.DataAccess.DAOs.Implementations;

namespace RCVUcab.DataAccess.DAOFactory;

public static class VehiculoDAOFactory
{
    public static VehiculoDAO CreateVehiculoDao()
    {
        return new VehiculoDAO();
    }
}