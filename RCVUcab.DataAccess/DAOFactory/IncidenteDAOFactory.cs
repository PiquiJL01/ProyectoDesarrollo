using RCVUcab.DataAccess.DAOs.Implementations;

namespace RCVUcab.DataAccess.DAOFactory;

public static class IncidenteDAOFactory
{
    public static IncidenteDAO CreateIncidenteDao()
    {
        return new IncidenteDAO();
    }
}