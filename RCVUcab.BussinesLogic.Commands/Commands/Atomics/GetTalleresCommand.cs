using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.DAOFactory;
using RCVUcab.DataAccess.DAOs.Implementations;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics
{
    public class GetTalleresCommand : Command<List<TallerDTO>>
    {
        public override void Execute()
        {
            TallerDAO dao = TallerDAOFactory.CreateTallerDAO();
            SetResult(dao.Select());
        }
    }
}

