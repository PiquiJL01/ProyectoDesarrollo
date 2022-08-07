using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class PutProveedorCommand : Command<ProveedorDTO>
{
    private ProveedorDTO _proveedor;

    public PutProveedorCommand(ProveedorDTO proveedor)
    {
        _proveedor = proveedor;
    }

    public override void Execute()
    {
        var dao = ProveedorDAOFactory.CreateProveedorDao();
        dao.Update(ProveedorMapper.DtoToEntity(_proveedor));
        SetResult(_proveedor);
    }
}