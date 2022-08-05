using System;
using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.DAOFactory;
using RCVUcab.DataAccess.DAOs.DB;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics
{
    public class GetTalleresCommand : Command<TallerDTO>
    {
        private List<TallerDTO> _result;


        public override void Execute()
        {
            TallerDB dao = TallerDAOFactory.CreateTallerDB();
            _result = dao.Select();
        }

        public override List<TallerDTO> GetResultList()
        {
            return _result;
        }

        public override TallerDTO GetResult()
        {
            throw new NotImplementedException();
        }
    }
}

