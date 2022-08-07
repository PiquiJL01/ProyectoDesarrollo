using RCVUcab.BussinesLogic.Commands.Commands.Atomics;
using RCVUcab.BussinesLogic.Commands.Commands.Composes;
using RCVUcab.BussinesLogic.DTO.DTOs;

namespace RCVUcab.BussinesLogic.Commands
{
    public static class CommandFactory
    {
        public static GetTallerByIdCommand CreateGetTallerByIdCommand(string taller)
        {
            return new GetTallerByIdCommand(taller);
        }

        public static GetTalleresCommand CreateGetTalleresCommand()
        {
            return new GetTalleresCommand();
        }

        public static GetTalleresByBrandCommand CreateGetTalleresByBrandCommand(string marca)
        {
            return new GetTalleresByBrandCommand(marca);
        }

        public static PostTallerCommand CreatePostTallerCommand(TallerDTO taller)
        {
            return new PostTallerCommand(taller);
        }

        public static GetAdministradoresCommand CreateGetAdministradoresCommand()
        {
            return new GetAdministradoresCommand();
        }

        public static GetCotizacionesCommand CreateGetCotizacionesCommand()
        {
            return new GetCotizacionesCommand();
        }

        public static GetCotizacionesByIdCommand CreateGetCotizacionesByIdCommand(string id)
        {
            return new GetCotizacionesByIdCommand(id);
        }

        public static PutCotizacionCommand CreatePutCotizacionCommand(CotizacionDTO cotizacion)
        {
            return new PutCotizacionCommand(cotizacion);
        }

        public static DeleteCotizacionCommand CreateDeleteCotizacionCommand(CotizacionDTO cotizacion)
        {
            return new DeleteCotizacionCommand(cotizacion);
        }

        public static GetCotizacionCommand CreateGetCotizacionCommand(string id)
        {
            return new GetCotizacionCommand(id);
        }

        public static DeleteCotizacionByIdCommand CreateDeleteCotizacionByIdCommand(string id)
        {
            return new DeleteCotizacionByIdCommand(id);
        }

        public static PostIncidenteCommand CreatePostIncidenteCommand(IncidenteDTO incidente)
        {
            return new PostIncidenteCommand(incidente);
        }

        public static GetPolizasCommand CreateGetPolizasCommand()
        {
            return new GetPolizasCommand();
        }

        public static GetPolizasByIdCommand CreateGetPolizaByIdCommand(string id)
        {
            return new GetPolizasByIdCommand(id);
        }

        public static PostPolizaCommand CreatePostPolizaCommand(PolizaDTO poliza)
        {
            return new PostPolizaCommand(poliza);
        }

        public static PutPolizaCommand CreatePutPolizaCommand(PolizaDTO poliza)
        {
            return new PutPolizaCommand(poliza);
        }

        public static GetPolizaCommand CreateGetPolizaCommand(string id)
        {
            return new GetPolizaCommand(id);
        }

        public static DeletePolizaCommand CreatedDeletePolizaCommand(PolizaDTO poliza)
        {
            return new DeletePolizaCommand(poliza);
        }

        public static DeletePolizaByIdCommand CreateDeletePolizaByIdCommand(string id)
        {
            return new DeletePolizaByIdCommand(id);
        }

        public static GetPropietarosCommand CreateGetPropietarosCommand()
        {
            return new GetPropietarosCommand();
        }

        public static GetPropietariosByIdCommand CreateGetPropietariosByIdCommand(string id)
        {
            return new GetPropietariosByIdCommand(id);
        }

        public static PostPropietarioCommand CreatePostPropietarioCommand(PropietarioDTO propietario)
        {
            return new PostPropietarioCommand(propietario);
        }

        public static PutPropietarioCommand CreatePutPropietarioCommand(PropietarioDTO propietario)
        {
            return new PutPropietarioCommand(propietario);
        }

        public static GetPropietarioCommand CreateGetPropietarioCommand(string id)
        {
            return new GetPropietarioCommand(id);
        }

        public static DeletePropietarioCommand CreateDeletePropietarioCommand(PropietarioDTO propietario)
        {
            return new DeletePropietarioCommand(propietario);
        }

        public static DeletePropietarioByIdCommand CreateDeletePropietarioByIdCommand(string id)
        {
            return new DeletePropietarioByIdCommand(id);
        }

        public static GetProveedoresCommand CreateGetProveedoresCommand()
        {
            return new GetProveedoresCommand();
        }

        public static GetProveedoresById CreateGetProveedoresById(string id)
        {
            return new GetProveedoresById(id);
        }

        public static PostProveedorCommand CreatePostProveedorCommand(ProveedorDTO proveedor)
        {
            return new PostProveedorCommand(proveedor);
        }

        public static PutProveedorCommand CreatePutProveedorCommand(ProveedorDTO proveedor)
        {
            return new PutProveedorCommand(proveedor);
        }

        public static GetProveedorCommand CreateGetProveedorCommand(string id)
        {
            return new GetProveedorCommand(id);
        }

        public static DeleteProveedorCommand CreateDeleteProveedorCommand(ProveedorDTO proveedor)
        {
            return new DeleteProveedorCommand(proveedor);
        }

        public static DeleteProveedorByIdCommand CreateDeleteProveedorByIdCommand(string id)
        {
            return new DeleteProveedorByIdCommand(id);
        }

        public static GetUsuariosCommand CreateGetUsuariosCommand()
        {
            return new GetUsuariosCommand();
        }

        public static GetUsuariosByIdCommand CreateGetUsuariosByIdCommand(string id)
        {
            return new GetUsuariosByIdCommand(id);
        }

        public static PostUsuarioCommand CretaePostUsuarioCommand(UsuarioDTO usuario)
        {
            return new PostUsuarioCommand(usuario);
        }

        public static PutUsuarioCommand CreatePutUsuarioCommand(UsuarioDTO usuario)
        {
            return new PutUsuarioCommand(usuario);
        }

        public static GetUsuarioCommand CreateGetUsuarioCommand(string id)
        {
            return new GetUsuarioCommand(id);
        }

        public static DeleteUsuarioCommand CreateDeleteUsuarioCommand(UsuarioDTO usuario)
        {
            return new DeleteUsuarioCommand(usuario);
        }

        public static DeleteUsuarioByIdCommand CreateDeleteUsuarioByIdCommand(string id)
        {
            return new DeleteUsuarioByIdCommand(id);
        }

        public static GetVehiculosCommand CreateGetVehiculosCommand()
        {
            return new GetVehiculosCommand();
        }

        public static GetVehiculosByIDCommand CreateGetVehiculosByIdCommand(string id)
        {
            return new GetVehiculosByIDCommand(id);
        }

        public static PostVehiculoCommand CreatePostVehiculoCommand(VehiculoDTO vehiculo)
        {
            return new PostVehiculoCommand(vehiculo);
        }

        public static PutVehiculoCommand CreatePutVehiculoCommand(VehiculoDTO vehiculo)
        {
            return new PutVehiculoCommand(vehiculo);
        }

        public static GetVehiculoCommand CreateGetVehiculoCommand(string id)
        {
            return new GetVehiculoCommand(id);
        }

        public static DeleteVehiculoCommand CreateDeleteVehiculoCommand(VehiculoDTO vehiculo)
        {
            return new DeleteVehiculoCommand(vehiculo);
        }

        public static DeleteVehiculoByIdCommand CreateDeleteVehiculoByIdCommand(string id)
        {
            return new DeleteVehiculoByIdCommand(id);
        }
    }
}

