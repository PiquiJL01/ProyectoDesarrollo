using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Controllers.Perito;
using RCVUcab.Exceptions;
using RCVUcab.Persistence.DAOs.Interfaces;
using RCVUcab.Responses;
using Xunit;

namespace TestProject.RCVUcab.UnitTests.Controllers
{
    public class PeritoControllerTest
    {

        private readonly PeritoController _controller;
        private readonly Mock<IPeritoDAO> _serviceMock;
        private readonly Mock<ILogger<PeritoController>> _loggerMock;

        public PeritoControllerTest()
        {
            _loggerMock = new Mock<ILogger<PeritoController>>();
            _serviceMock = new Mock<IPeritoDAO>();
            _controller = new PeritoController(_loggerMock.Object, _serviceMock.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }

        [Fact(DisplayName = "Get Peritos")]
        public Task GetPeritos()
        {
            _serviceMock
                .Setup(x => x.GetPeritos())
                .Returns(new List<UsuarioDTO>());

            var result = _controller.GetPeritos();

            Assert.IsType<ApplicationResponse<List<UsuarioDTO>>>(result);
            return Task.CompletedTask;
        }

        [Fact(DisplayName = "Get Peritos with Exception")]
        public Task GetPeritosException()
        {
            _serviceMock
                .Setup(x => x.GetPeritos())
                .Throws(new RCVException("", new Exception()));

            var ex = _controller.GetPeritos();

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }
    }
}

