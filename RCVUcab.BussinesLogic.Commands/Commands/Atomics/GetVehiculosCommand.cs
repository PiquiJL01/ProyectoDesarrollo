using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class GetVehiculosCommand : Command<List<VehiculoDTO>>
{
    public override void Execute()
    {
        var dao = VehiculoDAOFactory.CreateVehiculoDao();
        SetResult(VehiculoMapper.ListEntityToDtos(dao.Select()));
    }
}