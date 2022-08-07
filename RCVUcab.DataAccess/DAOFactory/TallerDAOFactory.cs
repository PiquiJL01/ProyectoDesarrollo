using RCVUcab.DataAccess.DAOs.DB;
using RCVUcab.DataAccess.DAOs.Implementations;

namespace RCVUcab.DataAccess.DAOFactory
{
    public class TallerDAOFactory
    {
        public static TallerDAO CreateTallerDAO()
        {
            return new TallerDAO();
        }

        /*public static TallerMQ CreateTallerMQ()
        {
            return new TallerMQ();
        }*/
    }
}

