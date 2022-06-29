using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Administracion.Controllers.APIs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Moq;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using ProyectoDesarrollo.Exceptions;
using ProyectoDesarrollo.Persistence.DAO.Implementations;
using ProyectoDesarrollo.Persistence.DAO.Interfaces;
using ProyectoDesarrollo.Response;
using Xunit;

namespace TestProject.Administracion.APIs
{
    public class IncidenteControllerTest
    {

        private readonly IncidenteController _controller;
        private readonly Mock<IncidenteDAO> _serviceMock;

        public IncidenteControllerTest()
        {
            _serviceMock = new Mock<IncidenteDAO>();
            _controller = new IncidenteController(_serviceMock.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }


        [Fact]
        public Task GetIncidentesByID()
        {
            _serviceMock
                .Setup(x => x.GetIncidentesByID(It.IsAny<string>()))
                .Returns(new List<IncidenteDTO>());
            var result = _controller.GetIncidentesByID("");

            Assert.IsType<ApplicationResponse<List<IncidenteDTO>>>(result); ;

            return Task.CompletedTask;
        }


        [Fact]
        public Task GetIncidentesByIDException()
        {
            _serviceMock
                .Setup(x => x.GetIncidentesByID(It.IsAny<string>()))
                .Throws(new ProyectoException("", new Exception()));

            var ex = _controller.GetIncidentesByID("");

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }

        [Fact]
        public void GetAllException()
        {

        }

        [Fact]
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

        }
    }
}
