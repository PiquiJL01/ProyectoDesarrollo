using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;
using RCVUcab.DataAccess.DAOs.Implementations;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics
{
    public class PostTallerCommand : Command<TallerDTO>
    {
        private readonly TallerDTO _taller;

        public PostTallerCommand(TallerDTO taller)
        {
            _taller = taller;
        }

        public override void Execute()
        {
            TallerDAO dao = TallerDAOFactory.CreateTallerDao();
            dao.Insert(TallerMapper.DtoToEntity(_taller));
        }
    }
}

