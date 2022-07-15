using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Controllers.Administracion;
using RCVUcab.Exceptions;
using RCVUcab.Persistence.DAOs.Interfaces;
using RCVUcab.Responses;
using Xunit;

namespace TestProject.RCVUcab.UnitTests.Controllers.Administracion
{
    public class IncidenteControllerTest
    {
        private readonly IncidenteController _controller;
        private readonly Mock<IIncidenteDAO> _serviceMock;
        private readonly Mock<IncidenteDTO> _sMock;
        private readonly Mock<ILogger<IncidenteController>> _loggerMock;


        public IncidenteControllerTest()
        {
            _loggerMock = new Mock<ILogger<IncidenteController>>();
            _serviceMock = new Mock<IIncidenteDAO>();
            _sMock = new Mock<IncidenteDTO>();
            _controller = new IncidenteController(_loggerMock.Object, _serviceMock.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }

        [Fact(DisplayName = "POST Incidente")]
        public Task PostIncidente()
        {
            _serviceMock
                .Setup(x => x.Insert(_sMock.Object));

            var result = _controller.PostIncidente(_sMock.Object);

            Assert.IsType<ApplicationResponse<IncidenteDTO>>(result);
            return Task.CompletedTask;
        }

        [Fact(DisplayName = "POST Incidente with Exception")]
        public Task PostIncidenteException()
        {
            _serviceMock
                .Setup(x => x.Insert(_sMock.Object))
                .Throws(new RCVException("", new Exception()));

            var ex = _controller.PostIncidente(_sMock.Object);

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }
    }
}

