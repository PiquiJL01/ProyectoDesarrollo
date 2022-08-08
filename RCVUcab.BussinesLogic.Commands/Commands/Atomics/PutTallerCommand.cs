using System;
using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics
{
    public class PutTallerCommand : Command<TallerDTO>
    {
        private TallerDTO _Taller;

        public PutTallerCommand(TallerDTO Taller)
        {
            _Taller = Taller;
        }

        public override void Execute()
        {
            var dao = TallerDAOFactory.CreateTallerDao();
            dao.Update(TallerMapper.DtoToEntity(_Taller));
            SetResult(_Taller);
        }
    }
}

