using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.DataAccess.DAOs.Interfaces
{
    public interface IUsuarioDAO : IDAO<UsuarioEntity>
    {
        public List<UsuarioEntity> GetAdministradores();
        public List<UsuarioEntity> GetPeritos();
        public List<UsuarioEntity> GetUsuariosByID(string id);
    }
}