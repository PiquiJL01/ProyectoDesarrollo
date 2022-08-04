using System;
using RCVUcab.DataAccess.DAOs.DB;

namespace RCVUcab.DataAccess.DAOFactory
{
    public class TallerDAOFactory
    {
        public static TallerDB CreateTallerDB()
        {
            return new TallerDB();
        }

        /*public static TallerMQ CreateTallerMQ()
        {
            return new TallerMQ();
        }*/
    }
}

