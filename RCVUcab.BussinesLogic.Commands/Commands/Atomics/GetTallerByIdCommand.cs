using System;
using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.DAOFactory;
using RCVUcab.DataAccess.DAOs.DB;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics
{
    public class GetTallerByIdCommand : Command<TallerDTO>
    {
        private readonly string _taller;
        private List<TallerDTO> _result;

        public GetTallerByIdCommand(string taller)
        {
            _taller = taller;
        }


        public override void Execute()
        {
            TallerDB dao = TallerDAOFactory.CreateTallerDB();
            _result = dao.GetTalleresByID(_taller);
        }

        public override List<TallerDTO> GetResult()
        {
            return _result;
        }
    }
}

