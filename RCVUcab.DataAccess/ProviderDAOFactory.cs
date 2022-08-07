using RCVUcab.DataAccess.DAOs.Implementations;
using RCVUCAB.DataAccess.Provider.DAOs.MQ;

namespace RCVUcab.DataAccess;

public static class ProviderDAOFactory
{
    public static CotizacionDAO CreateCotizacionDao()
    {
        return new CotizacionDAO();
    }

    public static ProviderMQ CreateProviderMQ()
    {
        return new ProviderMQ();
    }
}