using Microsoft.AspNetCore.Mvc;
using RCVUcab.BussinesLogic.Commands;
using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Exceptions;

namespace RCVUcab.Controllers.Taller
{

    [ApiController]
    [Route("Taller/[controller]")]
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
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de Ordenes de Compra: "
                    , ex.Message, ex);
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
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la Orden de Compra para el: "
                  + id, ex.Message, ex);
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
                throw new RCVException("Ha ocurrido un error al intentar modificar la Orden de Compra: "
                  , ex.Message, ex);
            }
        }
    }
}