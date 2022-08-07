using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.DAOs.Interfaces;
using RCVUcab.DataAccess.Database;
using RCVUcab.DataAccess.Entities;
using RCVUcab.DataAccess.Exceptions;

namespace RCVUcab.DataAccess.DAOs.Implementations
{

    public class UsuarioDAO : DAO<UsuarioEntity>, IUsuarioDAO
    {
        public override List<UsuarioEntity> Select()
        {
            try
            {
                var data = Context().Usuarios
                    .Select(u => new UsuarioEntity
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

        public List<UsuarioEntity> GetUsuariosByID(string id)
        {
            try
            {
                var data = Context().Usuarios
                 .Where(u => u.Id == id)
                 .Select(u => new UsuarioEntity
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

        public override UsuarioEntity Select(string Id)
        {
            var query = Context().Usuarios
                .Where(u => u.Id == Id)
                .Select(u => new UsuarioEntity
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

        public override void Insert(UsuarioEntity usuario)
        {
            Context().Usuarios.Add(usuario);
            Context().SaveChanges();
        }

        public override void Update(UsuarioEntity usuario)
        {
            Context().Usuarios.Update(usuario);
            Context().SaveChanges();
        }

        public override void Delete(UsuarioEntity usuario)
        {
            Context().Usuarios.Remove(usuario);
            Context().SaveChanges();
        }

        //Get Administradores
        public List<UsuarioEntity> GetAdministradores()
        {
            try
            {
                var data = _dataBaseContext.Usuarios
                    //********** REVISAR ROL **************
                    .Where(b => b.Rol == b.Rol)
                    .Select(b => new UsuarioEntity
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
        public List<UsuarioEntity> GetPeritos()
        {
            try
            {
                var data = _dataBaseContext.Usuarios
                    //********** REVISAR ROL **************
                    .Where(b => b.Rol == b.Rol)
                    .Select(b => new UsuarioEntity
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