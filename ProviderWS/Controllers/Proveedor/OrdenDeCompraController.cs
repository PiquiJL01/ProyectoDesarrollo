using Microsoft.AspNetCore.Mvc;
using RCVUcab.BussinesLogic.Commands;
using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Exceptions;


namespace ProviderWS.Controllers.Proveedor
{
    [ApiController]
    [Route("Proveedor/[controller]")]
    public class OrdenDeCompraController : Controller
    {
        private readonly ILogger<OrdenDeCompraController> _logger;

        public OrdenDeCompraController(ILogger<OrdenDeCompraController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<OrdenDeCompraDTO> GetOrdenesDeCompra()
        {
            try
            {
                var command = GetCommandFactory.CreateGetOrdenesDeCompraCommand();
                command.Execute();
                return command.GetResult();
            }
            catch (RCVException ex)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public List<OrdenDeCompraDTO> GetOrdenDeCompraById([FromRoute] string id)
        {
            try
            {
                var command = GetByCommandFactory.CreateGetOrdenDeCompraByIdCommand(id);
                command.Execute();
                return command.GetResult();
            }
            catch (RCVException ex)
            {
                throw;
            }
        }

        [HttpPut]
        public OrdenDeCompraDTO PutOrdenDeCompra([FromBody] OrdenDeCompraDTO OrdenDeCompraDto)
        {
            try
            {
                var command = PutCommandFactory.CreatePutOrdeDeCompraCommand(OrdenDeCompraDto);
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}