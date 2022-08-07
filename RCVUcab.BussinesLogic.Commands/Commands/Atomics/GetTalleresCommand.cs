using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;
using RCVUcab.DataAccess.DAOs.Implementations;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics
{
    public class GetTalleresCommand : Command<List<TallerDTO>>
    {
        public override void Execute()
        {
            TallerDAO dao = TallerDAOFactory.CreateTallerDao();
            SetResult(TallerMapper.ListEntityToDtos(dao.Select()));
        }
    }
}

