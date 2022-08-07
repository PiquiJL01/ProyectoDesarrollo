using RCVUcab.DataAccess.DAOs.Implementations;

namespace RCVUcab.DataAccess.DAOFactory;

public static class CotizacionDAOFactory
{
    public static CotizacionDAO CreateCotizacionDao()
    {
        return new CotizacionDAO();
    }
}