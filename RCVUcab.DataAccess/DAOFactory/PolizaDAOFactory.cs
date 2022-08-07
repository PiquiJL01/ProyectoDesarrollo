using System.Net.Http.Headers;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using RCVUcab.DataAccess.DAOs.Implementations;

namespace RCVUcab.DataAccess.DAOFactory;

public static class PolizaDAOFactory
{
    public static PolizaDAO CreatePolizaDao()
    {
        return new PolizaDAO();
    }
}