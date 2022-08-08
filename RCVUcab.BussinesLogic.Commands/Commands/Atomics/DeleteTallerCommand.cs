using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics
{
    public class DeleteTallerCommand : Command<TallerDTO>
    {
        private TallerDTO _Taller;

        public DeleteTallerCommand(TallerDTO Taller)
        {
            _Taller = Taller;
        }

        public override void Execute()
        {
            var dao = TallerDAOFactory.CreateTallerDao();
            dao.Delete(TallerMapper.DtoToEntity(_Taller));
            SetResult(_Taller);
        }
    }
}

