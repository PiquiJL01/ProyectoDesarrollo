using RCVUcab.DataAccess.DAOs.Implementations;

namespace RCVUcab.DataAccess.DAOFactory
{
    public class TallerDAOFactory
    {
        public static TallerDAO CreateTallerDao()
        {
            return new TallerDAO();
        }

        /*public static TallerMQ CreateTallerMQ()
        {
            return new TallerMQ();
        }*/
    }
}

