using RCVUcab.BussinesLogic.DTOs;

namespace RCVUcab.BussinesLogic.Commands.Atomics;

public class GetProvidersByBrandCommand : Command<BrandDTO>
{
    private readonly string _brand;
    private BrandDTO _result;

    public GetProvidersByBrandCommand(string brand)
    {
        _brand = brand;
    }


    public override void Execute()
    {
        ProviderDB dao = ProviderDAOFactory.CreateProviderDB();
        _result = dao.GetProvidersByBrand(_brand);
    }

    public override BrandDTO GetResult()
    {
        return _result;
    }
}