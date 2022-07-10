using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Administracion.Controllers.APIs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using ProyectoDesarrollo.Exceptions;
using ProyectoDesarrollo.Persistence.DAO.Implementations;
using ProyectoDesarrollo.Persistence.DAO.Interfaces;
using ProyectoDesarrollo.Responses;
using Xunit;

namespace TestProject.Administracion.APIs
{
    public class IncidenteControllerTest
    {

        private readonly IncidenteController _controller;
        private readonly Mock<IIncidenteDAO> _serviceMock;
        private readonly Mock<ILogger<IncidenteController>> _loggerMock;

        public IncidenteControllerTest()
        {
            _loggerMock = new Mock<ILogger<IncidenteController>>();
            _serviceMock = new Mock<IIncidenteDAO>();
            _controller = new IncidenteController(_loggerMock.Object, _serviceMock.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }

        [Fact]
        public Task Get()
        {

            /*_serviceMock
                .Setup(x => x.Select())
                .Returns(new List<IncidenteDTO>());*/
            var result = _controller.Get();

            Assert.IsType<ApplicationResponse<List<IncidenteDTO>>>(result);

            return Task.CompletedTask;

        }

        [Fact]
        public Task GetException()
        {
            /*_serviceMock
                .Setup(x => x.Select(null))
                .Throws(new ProyectoException("", new Exception()));*/

            var ex = _controller.Get();

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }


        [Fact]
        public Task GetIncidenteByID()
        {
            /*_serviceMock
                .Setup(x => x.GetIncidenteByID(It.IsAny<string>()))
                .Returns(new List<IncidenteDTO>());*/
            var result = _controller.GetIncidenteByID("");

            Assert.IsType<ApplicationResponse<List<IncidenteDTO>>>(result);

            return Task.CompletedTask;
        }

        [Fact(DisplayName = "Get Incidentes By Id with Exception")]
        public Task GetIncidenteByIDException()
        {
            /*_serviceMock
                .Setup(x => x.GetIncidenteByID(It.IsAny<string>()))
                .Throws(new ProyectoException("", new Exception()));*/

            var ex = _controller.GetIncidenteByID("");

            Assert.NotNull(ex);
            //Assert.False(ex.Success);
            return Task.CompletedTask;
        }


        [Fact]
        public void GetAllException()
        {

        }

        /*[Fact]
        public void GetById()
        {

        }

        [Fact]
        public void Post()
        {

        }

        [Fact]
        public void PostException()
        {

        }

        [Fact]
        public void Put()
        {

        }

        [Fact]
        public void PutException()
        {

        }

        [Fact]
        public void Delete()
        {

        }

        [Fact]
        public void DeleteException()
        {

        }*/
    }
}
