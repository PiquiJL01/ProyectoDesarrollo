using RCVUcab.Persistence.DAOs.DB;
using RCVUcab.Persistence.DAOs.MQ;

namespace RCVUcab.Persistence;

public static class ProviderDAOFactory
{
    public static ProviderDB CreateProviderDB()
    {
        return new ProviderDB();
    }

    public static ProviderMQ CreateProviderMQ()
    {
        return new ProviderMQ();
    }
}
}