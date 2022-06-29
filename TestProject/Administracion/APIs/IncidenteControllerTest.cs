using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Administracion.Controllers.APIs;
using Xunit;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using ProyectoDesarrollo.Persistence.DAO.Implementations;
using ProyectoDesarrollo.Persistence.DAO.Interfaces;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;

namespace TestProject.Administracion.APIs
{
    public class IncidenteControllerTest
    {

        private readonly IncidenteController _controller;
        private readonly Mock<IncidenteDAO> _serviceMock;

        public IncidenteControllerTest()
        {
            _serviceMock = new Mock<IncidenteDAO>();
            var lista = new List<IncidenteDTO>() { new IncidenteDTO(), new IncidenteDTO() };
            _serviceMock.Setup(e => e.Select()).Returns(lista);
            _controller = new IncidenteController(_serviceMock.Object);
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }

        [Fact]
        public Task Get()
        {
            var lista = new List<IncidenteDTO>() { new IncidenteDTO(), new IncidenteDTO() };
            _serviceMock.Setup(e => e.Select()).Returns(lista);

            Assert.Equal(_controller.Get(), lista);

            return  Task.CompletedTask;
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
