using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace ProviderWS.Controllers.Administracion
{
    [ApiController]
    [Route("Administracion/[controller]")]
    public class AdministradorController : Controller
    {
        /*private readonly IUsuarioDAO _administradorDAO;
        private readonly ILogger<AdministradorController> _logger;

        public AdministradorController(ILogger<AdministradorController> logger, IUsuarioDAO administradorDao)
        {
            _administradorDAO = administradorDao;
            _logger = logger;
        }

        [HttpGet]
        public ApplicationResponse<List<UsuarioDTO>> GetAdministradores()
        {
            var response = new ApplicationResponse<List<UsuarioDTO>>();
            try
            {
                response.Data = _administradorDAO.GetAdministradores();
            }
            catch (RCVException ex)
            {
                response.Error(ex);
            }
            return response;
        }*/

    }
}

