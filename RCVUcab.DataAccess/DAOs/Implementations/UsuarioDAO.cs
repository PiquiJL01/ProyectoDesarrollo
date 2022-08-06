using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.DAOs.Interfaces;
using RCVUcab.DataAccess.Database;
using RCVUcab.DataAccess.Entities;
using RCVUcab.DataAccess.Exceptions;

namespace RCVUcab.DataAccess.DAOs.Implementations
{

    public class UsuarioDAO : DAO<UsuarioDTO>, IUsuarioDAO
    {
        public UsuarioDAO(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {

        }

        public override List<UsuarioDTO> Select()
        {
            try
            {
                var data = Context().Usuarios
                    .Select(u => new UsuarioDTO
                    {
                        Id = u.Id,
                        Nombre = u.Nombre,
                        Apellido = u.Apellido,
                        Telefono = u.Telefono,
                        Email = u.Email,
                        Direccion = u.Direccion,
                        BirthDate = u.BirthDate,
                        Rol = u.Rol

                    }).ToList();

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de Usuarios: "
                    , ex.Message, ex);
            }
        }

        public List<UsuarioDTO> GetUsuariosByID(string id)
        {
            try
            {
                var data = Context().Usuarios
                 .Where(u => u.Id == id)
                 .Select(u => new UsuarioDTO
                 {
                     Id = u.Id,
                     Nombre = u.Nombre,
                     Apellido = u.Apellido,
                     Telefono = u.Telefono,
                     Email = u.Email,
                     Direccion = u.Direccion,
                     BirthDate = u.BirthDate,
                     Rol = u.Rol

                 }).ToList();

                return data.ToList();

            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar el Usuario para el: "
                  + id, ex.Message, ex);
            }

        }

        public override UsuarioDTO Select(string Id)
        {
            var query = Context().Usuarios
                .Where(u => u.Id == Id)
                .Select(u => new UsuarioDTO
                {
                    Id = u.Id,
                    Nombre = u.Nombre,
                    Apellido = u.Apellido,
                    Telefono = u.Telefono,
                    Email = u.Email,
                    Direccion = u.Direccion,
                    BirthDate = u.BirthDate,
                    Rol = u.Rol
                });
            return query.First();
        }

        public override void Insert(UsuarioDTO usuarioDto)

        {
            UsuarioEntity usuario = new UsuarioEntity()
            {
                Id = usuarioDto.Id,
                Nombre = usuarioDto.Nombre,
                Apellido = usuarioDto.Apellido,
                Telefono = usuarioDto.Telefono,
                Email = usuarioDto.Email,
                Direccion = usuarioDto.Direccion,
                BirthDate = usuarioDto.BirthDate,
                Rol = usuarioDto.Rol
            };

            Context().Usuarios.Add(usuario);
            Context().SaveChanges();
        }

        public override void Update(UsuarioDTO usuarioDTO)
        {
            var itemToUpdate = new UsuarioEntity()
            {
                Id = usuarioDTO.Id,
                Nombre = usuarioDTO.Nombre,
                Apellido = usuarioDTO.Apellido,
                Telefono = usuarioDTO.Telefono,
                Email = usuarioDTO.Email,
                Direccion = usuarioDTO.Direccion,
                BirthDate = usuarioDTO.BirthDate,
                Rol = usuarioDTO.Rol
            };

            Context().Usuarios.Update(itemToUpdate);
            Context().SaveChanges();
        }

        public override void Delete(UsuarioDTO usuario)
        {
            var itemToRemove = Context().Usuarios.Find(usuario.Id);
            Context().Usuarios.Remove(itemToRemove);
            Context().SaveChanges();
        }

        //Get Administradores
        public List<UsuarioDTO> GetAdministradores()
        {
            try
            {
                var data = _dataBaseContext.Usuarios
                    //********** REVISAR ROL **************
                    .Where(b => b.Rol == b.Rol)
                    .Select(b => new UsuarioDTO
                    {
                        Id = b.Id,
                        Nombre = b.Nombre,
                        Apellido = b.Apellido,
                    });

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de administradores: "
                    , ex.Message, ex);
            }
        }


        //Get Peritoes
        public List<UsuarioDTO> GetPeritos()
        {
            try
            {
                var data = _dataBaseContext.Usuarios
                    //********** REVISAR ROL **************
                    .Where(b => b.Rol == b.Rol)
                    .Select(b => new UsuarioDTO
                    {
                        Id = b.Id,
                        Nombre = b.Nombre,
                        Apellido = b.Apellido,
                    });

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de Peritos: "
                    , ex.Message, ex);
            }
        }
    }
}