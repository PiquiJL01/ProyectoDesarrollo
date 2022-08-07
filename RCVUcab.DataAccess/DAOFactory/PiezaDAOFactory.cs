using RCVUcab.DataAccess.DAOs.Implementations;

namespace RCVUcab.DataAccess.DAOFactory;

public static class PiezaDAOFactory
{
    public static PiezaDAO CreatePiezaDao()
    {
        return new PiezaDAO();
    }
}