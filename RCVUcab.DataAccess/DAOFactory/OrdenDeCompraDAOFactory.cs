using RCVUcab.DataAccess.DAOs.Implementations;

namespace RCVUcab.DataAccess.DAOFactory;

public static class OrdenDeCompraDAOFactory
{
    public static OrdenDeCompraDAO CreateOrdenDeCompraDao()
    {
        return new OrdenDeCompraDAO();
    }
}