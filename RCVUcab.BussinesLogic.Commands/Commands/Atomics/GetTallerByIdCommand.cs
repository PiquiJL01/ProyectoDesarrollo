using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.DAOFactory;
using RCVUcab.DataAccess.DAOs.Implementations;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics
{
    public class GetTallerByIdCommand : Command<TallerDTO>
    {
        private readonly string _taller;

        public GetTallerByIdCommand(string idTaller)
        {
            _taller = idTaller;
        }


        public override void Execute()
        {
            TallerDAO dao = TallerDAOFactory.CreateTallerDAO();
            SetResult(dao.Select(_taller));
        }
    }
}

