using System;
using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.DAOFactory;
using RCVUcab.DataAccess.DAOs.DB;
using RCVUcab.DataAccess.DAOs.Implementations;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics
{
    public class InsertTallerCommand : Command<TallerDTO>
    {
        private readonly TallerDTO _taller;

        public InsertTallerCommand(TallerDTO taller)
        {
            _taller = taller;
        }


        public override void Execute()
        {
            TallerDAO dao = TallerDAOFactory.CreateTallerDAO();
            dao.Insert(_taller);
        }
    }
}

