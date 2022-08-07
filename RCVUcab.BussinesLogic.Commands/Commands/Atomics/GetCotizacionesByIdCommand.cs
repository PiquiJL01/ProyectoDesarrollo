﻿using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class GetCotizacionesByIdCommand : Command<List<CotizacionDTO>>
{
    private string _id;

    public GetCotizacionesByIdCommand(string id)
    {
        _id = id;
    }

    public override void Execute()
    {
        var dao = CotizacionDAOFactory.CreateCotizacionDao();
        SetResult(CotizacionMapper.ListEntityToDtos(dao.GetCotizacionesByID(_id)));
    }
}