using RCVUcab.BussinesLogic.DTO.DTOs;

namespace RCVUcab.DataAccess.DAOs.Interfaces
{
    public interface IUsuarioDAO : IDAO<UsuarioDTO>
    {
        public List<UsuarioDTO> GetAdministradores();
        public List<UsuarioDTO> GetPeritos();
        public List<UsuarioDTO> GetUsuariosByID(string id);
    }
}