using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class DeleteVehiculoCommand : Command<VehiculoDTO>
{
    private VehiculoDTO _vehiculo;

    public DeleteVehiculoCommand(VehiculoDTO vehiculo)
    {
        _vehiculo = vehiculo;
    }

    public override void Execute()
    {
        var dao = VehiculoDAOFactory.CreateVehiculoDao();
        dao.Delete(VehiculoMapper.DtoToEntity(_vehiculo));
        SetResult(_vehiculo);
    }
}