/*using Microsoft.AspNetCore.Mvc;
namespace RCVUcab.Controllers.Incidente
{
    [ApiController]
    [Route("Incidente")]
    public class IncidenteController : Controller
    {
        private readonly IIncidenteDAO _IncidenteDAO;
        private readonly ILogger<IncidenteController> _logger;

        public IncidenteController(ILogger<IncidenteController> logger, IIncidenteDAO IncidenteDAO)
        {
            _IncidenteDAO = IncidenteDAO;
            _logger = logger;
        }


        [HttpGet]
        public ApplicationResponse<List<IncidenteDTO>> GetIncidentesByAdministrador(string administrador)
        {
            var response = new ApplicationResponse<List<IncidenteDTO>>();
            try
            {
                response.Data = _IncidenteDAO.GetIncidentesByAdministrador(administrador);
            }
            catch (RCVException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }


    }
}*/