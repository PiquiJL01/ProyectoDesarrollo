using System;
using RCVUcab.DataAccess.DAOs.Implementations;

namespace RCVUcab.DataAccess.DAOFactory
{
    public static class ProveedorDAOFactory
    {
        public static ProveedorDAO CreateProveedorDao()
        {
            return new ProveedorDAO();
        }
    }
}

