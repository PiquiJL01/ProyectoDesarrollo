using RCVUcab.DataAccess.DAOs.Implementations;

namespace RCVUcab.DataAccess.DAOFactory;

public static class FacturaDAOFactory
{
    public static FacturaDAO CreateFacturaDao()
    {
        return new FacturaDAO();
    }
}