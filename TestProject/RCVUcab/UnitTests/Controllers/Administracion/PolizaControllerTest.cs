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
    public class PolizaControllerTest
    {
        private readonly PolizaController _controller;
        private readonly Mock<IPolizaDAO> _serviceMock;
        private readonly Mock<PolizaDTO> _sMock;
        private readonly Mock<ILogger<PolizaController>> _loggerMock;

        public PolizaControllerTest()
        {
            _loggerMock = new Mock<ILogger<PolizaController>>();
            _serviceMock = new Mock<IPolizaDAO>();
            _sMock = new Mock<PolizaDTO>();
            _sMock.Object.ID = "1";
            _controller = new PolizaController(new Mock<ILogger<PolizaController>>().Object, _serviceMock.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }

        //GET Poliza UNIT TEST
        [Fact(DisplayName = "GET Polizas")]
        public Task GetPolizas()
        {
            _serviceMock
                .Setup(x => x.Select())
                .Returns(new List<PolizaDTO>());

            var result = _controller.GetPolizas();

            Assert.IsType<ApplicationResponse<List<PolizaDTO>>>(result);
            return Task.CompletedTask;
        }


        //GET Poliza UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "GET Polizas with Exception")]
        public Task GetPolizasException()
        {
            _serviceMock
                .Setup(x => x.Select())
                .Throws(new RCVException("", new Exception()));

            var ex = _controller.GetPolizas();

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }


        //GET Poliza BY ID UNIT TEST
        [Fact(DisplayName = "GET Polizas By Id")]
        public Task GetPolizasById()
        {
            _serviceMock
                .Setup(x => x.GetPolizaByID(It.IsAny<string>()))
                .Returns(new List<PolizaDTO>());

            var result = _controller.GetPolizaById("");

            Assert.IsType<ApplicationResponse<List<PolizaDTO>>>(result);
            return Task.CompletedTask;
        }


        //GET Poliza BY ID UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "GET Polizas By Id with Exception")]
        public Task GetPolizasByIdException()
        {
            _serviceMock
                .Setup(x => x.GetPolizaByID(It.IsAny<string>()))
                .Throws(new RCVException("", new Exception()));

            var ex = _controller.GetPolizaById("");

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }


        //POST Poliza UNIT TEST
        [Fact(DisplayName = "POST Poliza")]
        public Task PostPoliza()
        {
            _serviceMock
                .Setup(x => x.Insert(_sMock.Object));

            var result = _controller.PostPoliza(_sMock.Object);

            Assert.IsType<ApplicationResponse<PolizaDTO>>(result);
            return Task.CompletedTask;
        }


        //POST Poliza UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "POST Poliza with Exception")]
        public Task PostPolizaException()
        {
            _serviceMock
                .Setup(x => x.Insert(_sMock.Object))
                .Throws(new RCVException("", new Exception()));

            var ex = _controller.PostPoliza(_sMock.Object);

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }


        //PUT Poliza UNIT TEST IF EXIST
        [Fact(DisplayName = "PUT Poliza if Id Exist")]
        public Task PutPoliza()
        {

            _serviceMock
                .Setup(x => x.Update(_sMock.Object));

            _serviceMock
                .Setup(i => i.GetPolizaByID(It.IsAny<string>()))
                .Returns(new List<PolizaDTO>());


            var exist = _controller.GetPolizaById("");
            var result = _controller.PutPoliza(_sMock.Object);

            Assert.True(exist.Success);
            Assert.NotNull(exist);

            Assert.IsType<ApplicationResponse<PolizaDTO>>(result);
            return Task.CompletedTask;
        }



        //PUT Poliza UNIT TEST IF NOT EXIST
        [Fact(DisplayName = "PUT Poliza if Id does not exist")]
        public Task PutPolizaIfIdDoesNotExist()
        {

            _serviceMock
                .Setup(x => x.Update(_sMock.Object));

            _serviceMock
                .Setup(i => i.GetPolizaByID(It.IsAny<string>()))
                .Returns(new List<PolizaDTO>());


            var exist = _controller.GetPolizaById("");
            var result = _controller.PutPoliza(_sMock.Object);

            Assert.False(exist.Data.Exists(x => x.ID.Contains(It.IsAny<string>())));
            Assert.Equal("No existe", result.Message);

            return Task.CompletedTask;
        }

        //PUT Poliza UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "PUT Poliza with Exception")]
        public Task PutPolizaException()
        {
            _serviceMock
                .Setup(p => p.Update(_sMock.Object))
                .Throws(new RCVException("", new Exception()));

            _serviceMock
                .Setup(p => p.GetPolizaByID(_sMock.Object.ID))
                .Returns(new List<PolizaDTO>() { _sMock.Object });

            var ex = _controller.PutPoliza(_sMock.Object);

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }


        //DELETE Poliza UNIT TEST
        [Fact(DisplayName = "DELETE Poliza")]
        public Task DeletePoliza_Test()
        {

            _serviceMock
                .Setup(x => x.Select(It.IsAny<string>()));

            _serviceMock
                .Setup(i => i.Delete(_sMock.Object));

            var result = _controller.DeletePoliza(It.IsAny<string>());

            //Assert.True(exist.Success);
            //Assert.NotNull(exist);

            Assert.IsType<ApplicationResponse<PolizaDTO>>(result);
            return Task.CompletedTask;
        }

        //PUT Poliza UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "DELETE Poliza with Exception")]
        public Task DeletePoliza_WithException()
        {
            _serviceMock
                .Setup(x => x.Select(It.IsAny<string>()))
                .Throws(new RCVException("", new Exception()));

            _serviceMock
                .Setup(i => i.Delete(_sMock.Object));

            var ex = _controller.DeletePoliza(It.IsAny<string>());

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }

    }
}

