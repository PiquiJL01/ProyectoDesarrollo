using System;
using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.DAOFactory;
using RCVUcab.DataAccess.DAOs.DB;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics
{
    public class InsertTallerCommand : Command<TallerDTO>
    {
        private readonly TallerEntity _taller;
        private TallerDTO _result;

        public InsertTallerCommand(TallerEntity taller)
        {
            _taller = taller;
        }


        public override void Execute()
        {
            TallerDB dao = TallerDAOFactory.CreateTallerDB();
            _result = dao.Insert(_taller);
        }

        public override TallerDTO GetResult()
        {
            return _result;
        }

        public override List<TallerDTO> GetResultList()
        {
            throw new NotImplementedException();
        }
    }
}

