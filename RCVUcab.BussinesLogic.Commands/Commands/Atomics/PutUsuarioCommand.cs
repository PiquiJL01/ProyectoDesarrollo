using RCVUcab.BussinesLogic.DTO.DTOs;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class PutUsuarioCommand : Command<UsuarioDTO>
{
    private UsuarioDTO _usuario;

    public PutUsuarioCommand(UsuarioDTO usuario)
    {
        _usuario = usuario;
    }

    public override void Execute()
    {
        throw new NotImplementedException();
    }
}