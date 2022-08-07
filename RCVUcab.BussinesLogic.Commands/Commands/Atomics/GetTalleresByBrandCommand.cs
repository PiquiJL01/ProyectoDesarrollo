using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.DAOFactory;
using RCVUcab.DataAccess.DAOs.Implementations;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics
{
    public class GetTalleresByBrandCommand : Command<List<ProveedorMarcaDTO>>
    {
        private readonly string _marca;

        public GetTalleresByBrandCommand(string marca)
        {
            _marca = marca;
        }

        public override void Execute()
        {
            TallerDAO dao = TallerDAOFactory.CreateTallerDAO(); 
            SetResult(dao.GetTalleresByBrand(_marca));
        }
    }
}

