using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;
using RCVUcab.DataAccess.DAOs.Implementations;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics
{
    public class PostTallerCommand : Command<TallerDTO>
    {
        private TallerDTO _taller;
        private TallerDTO _result;

        public PostTallerCommand(TallerDTO taller)
        {
            _taller = taller;
        }

        public override void Execute()
        {
            TallerDAO dao = TallerDAOFactory.CreateTallerDao();
            SetResult(TallerMapper.EntityToDto(dao.InsertR(TallerMapper.DtoToEntity(_taller))));
        }
    }
}

