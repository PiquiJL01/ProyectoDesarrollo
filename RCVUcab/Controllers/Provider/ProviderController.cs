using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Exceptions;
using RCVUcab.Persistence.DAOs.Interfaces;
using RCVUcab.Responses;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RCVUcab.BussinesLogic.Commands;
using RCVUcab.BussinesLogic.Commands.Atomics;
using RCVUcab.BussinesLogic.Commands.Composes;
using RCVUcab.Persistence.Mappers;

namespace RCVUcab.Controllers.Provider
{
    [ApiController]
    [Route("provider")]
    public class ProviderController : Controller
    {
        private readonly ILogger<ProviderController> _logger;

        public ProviderController(ILogger<ProviderController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{brand}")]
        public BrandDTO GetProvidersByBrand([Required][FromRoute] string brand)
        {
            try
            {
                GetProvidersByBrandCommand command =
                    CommandFactory.createGetProvidersByBrandCommand(brand);
                command.Execute();
                return command.GetResult();
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPost("quotation")]
        public QuotationDTO CreateClaimAuctionQuotation([FromBody] QuotationDTO request)
        {
            try
            {
                CreateProviderQuotationCommand command =
                    CommandFactory.createCreateProviderQuotationCommand(QuotationMapper.MapDtoToEntity(request));
                command.Execute();
                return command.GetResult();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
