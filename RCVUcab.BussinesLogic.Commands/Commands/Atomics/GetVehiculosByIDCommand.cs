using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class GetVehiculosByIDCommand :Command<List<VehiculoDTO>>
{
    private string _id;

    public GetVehiculosByIDCommand(string id)
    {
        _id = id;
    }

    public override void Execute()
    {
        var dao = VehiculoDAOFactory.CreateVehiculoDao();
        SetResult(VehiculoMapper.ListEntityToDtos(dao.GetVehiculosByID(_id)));
    }
}