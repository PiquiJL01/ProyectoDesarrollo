using System;
using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.DAOFactory;
using RCVUcab.DataAccess.DAOs.DB;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics
{
    public class GetTalleresByBrandCommand : Command<ProveedorMarcaDTO>
    {
        private List<ProveedorMarcaDTO> _result;
        private readonly string _marca;

        public GetTalleresByBrandCommand(string marca)
        {
            _marca = marca;
        }

        public override void Execute()
        {
            TallerDB dao = TallerDAOFactory.CreateTallerDB();
            _result = dao.GetTalleresByBrand(_marca);
        }

        public override List<ProveedorMarcaDTO> GetResultList()
        {
            return _result;
        }

        public override ProveedorMarcaDTO GetResult()
        {
            throw new NotImplementedException();
        }
    }
}

