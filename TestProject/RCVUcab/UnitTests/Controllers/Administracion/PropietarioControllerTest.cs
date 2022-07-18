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


        //GET Propietario UNIT TEST
        [Fact(DisplayName = "GET Propietarios")]
        public Task GetPropietarios()
        {
            _serviceMock
                .Setup(x => x.Select())
                .Returns(new List<PropietarioDTO>());

            var result = _controller.GetPropietarios();

            Assert.IsType<ApplicationResponse<List<PropietarioDTO>>>(result);
            return Task.CompletedTask;
        }


        //GET Propietario UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "GET Propietarios with Exception")]
        public Task GetPropietariosException()
        {
            _serviceMock
                .Setup(x => x.Select())
                .Throws(new RCVException("", new Exception()));

            var ex = _controller.GetPropietarios();

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }


        //GET Propietario BY ID UNIT TEST
        [Fact(DisplayName = "GET Propietarios By Id")]
        public Task GetPropietariosById()
        {
            _serviceMock
                .Setup(x => x.GetPropietarioByID(It.IsAny<string>()))
                .Returns(new List<PropietarioDTO>());

            var result = _controller.GetPropietarioById("");

            Assert.IsType<ApplicationResponse<List<PropietarioDTO>>>(result);
            return Task.CompletedTask;
        }


        //GET Propietario BY ID UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "GET Propietarios By Id with Exception")]
        public Task GetPropietariosByIdException()
        {
            _serviceMock
                .Setup(x => x.GetPropietarioByID(It.IsAny<string>()))
                .Throws(new RCVException("", new Exception()));

            var ex = _controller.GetPropietarioById("");

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }

        //POST PROPIETARIO UNIT TEST
        [Fact(DisplayName = "POST Propietario")]
        public Task PostPropietario()
        {
            _serviceMock
                .Setup(x => x.Insert(_sMock.Object));

            var result = _controller.PostPropietario(_sMock.Object);

            Assert.IsType<ApplicationResponse<PropietarioDTO>>(result);
            return Task.CompletedTask;
        }


        //POST PROPIETARIO UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "POST Propietario with Exception")]
        public Task PostPropietarioException()
        {
            _serviceMock
                .Setup(x => x.Insert(_sMock.Object))
                .Throws(new RCVException("", new Exception()));

            var ex = _controller.PostPropietario(_sMock.Object);

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }


        //PUT Propietario UNIT TEST IF EXIST
        [Fact(DisplayName = "PUT Propietario if Id Exist")]
        public Task PutPropietario()
        {

            _serviceMock
                .Setup(x => x.Update(_sMock.Object));

            _serviceMock
                .Setup(i => i.GetPropietarioByID(It.IsAny<string>()))
                .Returns(new List<PropietarioDTO>());


            var exist = _controller.GetPropietarioById("");
            var result = _controller.PutPropietario(_sMock.Object);

            Assert.True(exist.Success);
            Assert.NotNull(exist);

            Assert.IsType<ApplicationResponse<PropietarioDTO>>(result);
            return Task.CompletedTask;
        }



        //PUT Propietario UNIT TEST IF NOT EXIST
        [Fact(DisplayName = "PUT Propietario if Id does not exist")]
        public Task PutPropietarioIfIdDoesNotExist()
        {

            _serviceMock
                .Setup(x => x.Update(_sMock.Object));

            _serviceMock
                .Setup(i => i.GetPropietarioByID(It.IsAny<string>()))
                .Returns(new List<PropietarioDTO>());


            var exist = _controller.GetPropietarioById("");
            var result = _controller.PutPropietario(_sMock.Object);

            Assert.False(exist.Data.Exists(x => x.CedulaRif.Contains(It.IsAny<string>())));
            Assert.Equal("No existe", result.Message);

            return Task.CompletedTask;
        }

        //PUT Propietario UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "PUT Propietario with Exception")]
        public Task PutPropietarioException()
        {
            _serviceMock
                .Setup(p => p.Update(_sMock.Object))
                .Throws(new RCVException("", new Exception()));

            _serviceMock
                .Setup(p => p.GetPropietarioByID(_sMock.Object.CedulaRif))
                .Returns(new List<PropietarioDTO>() { _sMock.Object });

            var ex = _controller.PutPropietario(_sMock.Object);

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }


        //DELETE Propietario UNIT TEST
        [Fact(DisplayName = "DELETE Propietario")]
        public Task DeletePropietario_Test()
        {

            _serviceMock
                .Setup(x => x.Select(It.IsAny<string>()));

            _serviceMock
                .Setup(i => i.Delete(_sMock.Object));

            var result = _controller.DeletePropietario(It.IsAny<string>());

            //Assert.True(exist.Success);
            //Assert.NotNull(exist);

            Assert.IsType<ApplicationResponse<PropietarioDTO>>(result);
            return Task.CompletedTask;
        }

        //PUT Propietario UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "DELETE Propietario with Exception")]
        public Task DeletePropietario_WithException()
        {
            _serviceMock
                .Setup(x => x.Select(It.IsAny<string>()))
                .Throws(new RCVException("", new Exception()));

            _serviceMock
                .Setup(i => i.Delete(_sMock.Object));

            var ex = _controller.DeletePropietario(It.IsAny<string>());

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }

    }
}

