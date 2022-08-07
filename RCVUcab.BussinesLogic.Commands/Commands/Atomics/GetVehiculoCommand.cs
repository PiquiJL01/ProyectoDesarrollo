﻿using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class GetVehiculoCommand : Command<VehiculoDTO>
{
    private string _id;

    public GetVehiculoCommand(string id)
    {
        _id = id;
    }

    public override void Execute()
    {
        var dao = VehiculoDAOFactory.CreateVehiculoDao();
        SetResult(VehiculoMapper.EntityToDto(dao.Select(_id)));
    }
}