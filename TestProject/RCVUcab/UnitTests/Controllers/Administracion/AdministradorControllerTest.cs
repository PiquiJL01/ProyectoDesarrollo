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
    public class AdministradorControllerTest
    {
        private readonly AdministradorController _controller;
        private readonly Mock<IAdministradorDAO> _serviceMock;
        private readonly Mock<ILogger<AdministradorController>> _loggerMock;

        public AdministradorControllerTest()
        {
            _loggerMock = new Mock<ILogger<AdministradorController>>();
            _serviceMock = new Mock<IAdministradorDAO>();
            _controller = new AdministradorController(_loggerMock.Object, _serviceMock.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }

        [Fact(DisplayName = "Get Administradores")]
        public Task GetAdministradores()
        {
            _serviceMock
                .Setup(x => x.GetAdministradores())
                .Returns(new List<UsuarioDTO>());

            var result = _controller.GetAdministradores();

            Assert.IsType<ApplicationResponse<List<UsuarioDTO>>>(result);
            return Task.CompletedTask;
        }

        [Fact(DisplayName = "Get Administradores with Exception")]
        public Task GetAdministradoresException()
        {
            _serviceMock
                .Setup(x => x.GetAdministradores())
                .Throws(new RCVException("", new Exception()));

            var ex = _controller.GetAdministradores();

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }
    }
}
