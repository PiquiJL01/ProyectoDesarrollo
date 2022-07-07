using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using ProyectoDesarrollo.Controllers.APIs;
using ProyectoDesarrollo.Exceptions;
using ProyectoDesarrollo.Persistence.DAO.Interfaces;
using ProyectoDesarrollo.Response;
using Xunit;

namespace TestProject.ProyectoDesarrollo.APIs
{
    public class IncidenteControllerTest
    {
        private readonly IncidentesController _controller;
        private readonly Mock<IIncidenteDAO> _serviceMock;
        private readonly Mock<ILogger<IncidentesController>> _loggerMock;

        public IncidenteControllerTest()
        {
            _loggerMock = new Mock<ILogger<IncidentesController>>();
            _serviceMock = new Mock<IIncidenteDAO>();
            _controller = new IncidentesController(_loggerMock.Object, _serviceMock.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }

        [Fact]
        public Task DeleteIncidente()
        {
            _serviceMock
                .Setup(x => x.DeleteIncidente(It.IsAny<string>()))
                .Returns(new List<IncidenteDTO>());
            var result = _controller.DeleteIncidente("");

            Assert.IsType<ApplicationResponse<List<IncidenteDTO>>>(result);

            return Task.CompletedTask;
        }

        [Fact(DisplayName = "Delete Incidente By Id with Exception")]
        public Task DeleteIncidenteException()
        {
            _serviceMock
                .Setup(x => x.DeleteIncidente(It.IsAny<string>()))
                .Throws(new ProyectoException("", new Exception()));

            var ex = _controller.DeleteIncidente("");

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }
    }
}

