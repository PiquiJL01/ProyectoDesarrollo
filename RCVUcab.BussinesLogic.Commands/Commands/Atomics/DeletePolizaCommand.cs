﻿using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class DeletePolizaCommand : Command<PolizaDTO>
{
    private PolizaDTO _poliza;

    public DeletePolizaCommand(PolizaDTO poliza)
    {
        _poliza = poliza;
    }

    public override void Execute()
    {
        var dao = PolizaDAOFactory.CreatePolizaDao();
        dao.Delete(PolizaMapper.DtoToEntity(_poliza));
        SetResult(_poliza);
    }
}