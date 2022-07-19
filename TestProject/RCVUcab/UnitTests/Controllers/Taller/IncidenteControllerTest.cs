using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Controllers.Taller;
using RCVUcab.Exceptions;
using RCVUcab.Persistence.DAOs.Interfaces;
using RCVUcab.Responses;
using Xunit;

namespace TestProject.RCVUcab.UnitTests.Controllers.Taller
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
            _sMock.Object.ID = "1";
            _controller = new IncidenteController(new Mock<ILogger<IncidenteController>>().Object, _serviceMock.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }

        //GET Incidente UNIT TEST
        [Fact(DisplayName = "GET Incidentes")]
        public Task GetIncidentes()
        {
            _serviceMock
                .Setup(x => x.Select())
                .Returns(new List<IncidenteDTO>());

            var result = _controller.GetIncidentes();

            Assert.IsType<ApplicationResponse<List<IncidenteDTO>>>(result);
            return Task.CompletedTask;
        }


        //GET Incidente UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "GET Incidentes with Exception")]
        public Task GetIncidentesException()
        {
            _serviceMock
                .Setup(x => x.Select())
                .Throws(new RCVException("", new Exception()));

            var ex = _controller.GetIncidentes();

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }

        //GET Incidente BY ID UNIT TEST
        [Fact(DisplayName = "GET Incidentes By Id")]
        public Task GetIncidentesById()
        {
            _serviceMock
                .Setup(x => x.GetIncidenteByID(It.IsAny<string>()))
                .Returns(new List<IncidenteDTO>());

            var result = _controller.GetIncidenteById("");

            Assert.IsType<ApplicationResponse<List<IncidenteDTO>>>(result);
            return Task.CompletedTask;
        }


        //GET Incidente BY ID UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "GET Incidentes By Id with Exception")]
        public Task GetIncidentesByIdException()
        {
            _serviceMock
                .Setup(x => x.GetIncidenteByID(It.IsAny<string>()))
                .Throws(new RCVException("", new Exception()));

            var ex = _controller.GetIncidenteById("");

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }

        //PUT Incidente UNIT TEST IF EXIST
        [Fact(DisplayName = "PUT Incidente if Id Exist")]
        public Task PutIncidente()
        {

            _serviceMock
                .Setup(x => x.Update(_sMock.Object));

            _serviceMock
                .Setup(i => i.GetIncidenteByID(It.IsAny<string>()))
                .Returns(new List<IncidenteDTO>());


            var exist = _controller.GetIncidenteById("");
            var result = _controller.PutIncidente(_sMock.Object);

            Assert.True(exist.Success);
            Assert.NotNull(exist);

            Assert.IsType<ApplicationResponse<IncidenteDTO>>(result);
            return Task.CompletedTask;
        }



        //PUT Incidente UNIT TEST IF NOT EXIST
        [Fact(DisplayName = "PUT Incidente if Id does not exist")]
        public Task PutIncidenteIfIdDoesNotExist()
        {

            _serviceMock
                .Setup(x => x.Update(_sMock.Object));

            _serviceMock
                .Setup(i => i.GetIncidenteByID(It.IsAny<string>()))
                .Returns(new List<IncidenteDTO>());


            var exist = _controller.GetIncidenteById("");
            var result = _controller.PutIncidente(_sMock.Object);

            Assert.False(exist.Data.Exists(x => x.ID.Contains(It.IsAny<string>())));
            Assert.Equal("No existe", result.Message);

            return Task.CompletedTask;
        }

        //PUT Incidente UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "PUT Incidente with Exception")]
        public Task PutIncidenteException()
        {
            _serviceMock
                .Setup(p => p.Update(_sMock.Object))
                .Throws(new RCVException("", new Exception()));

            _serviceMock
                .Setup(p => p.GetIncidenteByID(_sMock.Object.ID))
                .Returns(new List<IncidenteDTO>() { _sMock.Object });

            var ex = _controller.PutIncidente(_sMock.Object);

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }
    }
}

