using RCVUcab.DataAccess.DAOs.Implementations;

namespace RCVUcab.DataAccess.DAOFactory;

public static class MarcaDAOFactory
{
    public static MarcaDAO CreateMarcaDao()
    {
        return new MarcaDAO();
    }
}