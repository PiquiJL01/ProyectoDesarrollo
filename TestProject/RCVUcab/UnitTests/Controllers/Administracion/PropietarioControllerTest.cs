using System;
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
    public class PropietarioControllerTest
    {
        private readonly PropietarioController _controller;
        private readonly Mock<IPropietarioDAO> _serviceMock;
        private readonly Mock<PropietarioDTO> _sMock;
        private readonly Mock<ILogger<PropietarioController>> _loggerMock;


        public PropietarioControllerTest()
        {
            _loggerMock = new Mock<ILogger<PropietarioController>>();
            _serviceMock = new Mock<IPropietarioDAO>();
            _sMock = new Mock<PropietarioDTO>();
            _controller = new PropietarioController(_loggerMock.Object, _serviceMock.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }

        [Fact(DisplayName = "POST Propietario")]
        public Task PostPropietario()
        {
            _serviceMock
                .Setup(x => x.Insert(_sMock.Object));

            var result = _controller.PostPropietario(_sMock.Object);

            Assert.IsType<ApplicationResponse<PropietarioDTO>>(result);
            return Task.CompletedTask;
        }

        [Fact(DisplayName = "POST Incidente with Exception")]
        public Task PostIncidenteException()
        {
            _serviceMock
                .Setup(x => x.Insert(_sMock.Object))
                .Throws(new RCVException("", new Exception()));

            var ex = _controller.PostPropietario(_sMock.Object);

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }
    }
}

