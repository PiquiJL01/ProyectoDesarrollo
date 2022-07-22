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
    public class UsuarioControllerTest
    {
        private readonly UsuarioController _controller;
        private readonly Mock<IUsuarioDAO> _serviceMock;
        private readonly Mock<UsuarioDTO> _sMock;
        private readonly Mock<ILogger<UsuarioController>> _loggerMock;

        public UsuarioControllerTest()
        {
            _loggerMock = new Mock<ILogger<UsuarioController>>();
            _serviceMock = new Mock<IUsuarioDAO>();
            _sMock = new Mock<UsuarioDTO>();
            _sMock.Object.Id = "1";
            _controller = new UsuarioController(new Mock<ILogger<UsuarioController>>().Object, _serviceMock.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }

        //GET Usuario UNIT TEST
        [Fact(DisplayName = "GET Usuarios")]
        public Task GetUsuarios()
        {
            _serviceMock
                .Setup(x => x.Select())
                .Returns(new List<UsuarioDTO>());

            var result = _controller.GetUsuarios();

            Assert.IsType<ApplicationResponse<List<UsuarioDTO>>>(result);
            return Task.CompletedTask;
        }


        //GET Usuario UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "GET Usuarios with Exception")]
        public Task GetUsuariosException()
        {
            _serviceMock
                .Setup(x => x.Select())
                .Throws(new RCVException("", new Exception()));

            var ex = _controller.GetUsuarios();

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }


        //GET Usuario BY ID UNIT TEST
        [Fact(DisplayName = "GET Usuarios By Id")]
        public Task GetUsuariosById()
        {
            _serviceMock
                .Setup(x => x.GetUsuariosByID(It.IsAny<string>()))
                .Returns(new List<UsuarioDTO>());

            var result = _controller.GetUsuarioById("");

            Assert.IsType<ApplicationResponse<List<UsuarioDTO>>>(result);
            return Task.CompletedTask;
        }


        //GET Usuario BY ID UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "GET Usuarios By Id with Exception")]
        public Task GetUsuariosByIdException()
        {
            _serviceMock
                .Setup(x => x.GetUsuariosByID(It.IsAny<string>()))
                .Throws(new RCVException("", new Exception()));

            var ex = _controller.GetUsuarioById("");

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }


        //POST Usuario UNIT TEST
        [Fact(DisplayName = "POST Usuario")]
        public Task PostUsuario()
        {
            _serviceMock
                .Setup(x => x.Insert(_sMock.Object));

            var result = _controller.PostUsuario(_sMock.Object);

            Assert.IsType<ApplicationResponse<UsuarioDTO>>(result);
            return Task.CompletedTask;
        }


        //POST Usuario UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "POST Usuario with Exception")]
        public Task PostUsuarioException()
        {
            _serviceMock
                .Setup(x => x.Insert(_sMock.Object))
                .Throws(new RCVException("", new Exception()));

            var ex = _controller.PostUsuario(_sMock.Object);

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }


        //PUT Usuario UNIT TEST IF EXIST
        [Fact(DisplayName = "PUT Usuario if Id Exist")]
        public Task PutUsuario()
        {

            _serviceMock
                .Setup(x => x.Update(_sMock.Object));

            _serviceMock
                .Setup(i => i.GetUsuariosByID(It.IsAny<string>()))
                .Returns(new List<UsuarioDTO>());


            var exist = _controller.GetUsuarioById("");
            var result = _controller.PutUsuario(_sMock.Object);

            Assert.True(exist.Success);
            Assert.NotNull(exist);

            Assert.IsType<ApplicationResponse<UsuarioDTO>>(result);
            return Task.CompletedTask;
        }



        //PUT Usuario UNIT TEST IF NOT EXIST
        [Fact(DisplayName = "PUT Usuario if Id does not exist")]
        public Task PutUsuarioIfIdDoesNotExist()
        {

            _serviceMock
                .Setup(x => x.Update(_sMock.Object));

            _serviceMock
                .Setup(i => i.GetUsuariosByID(It.IsAny<string>()))
                .Returns(new List<UsuarioDTO>());


            var exist = _controller.GetUsuarioById("");
            var result = _controller.PutUsuario(_sMock.Object);

            Assert.False(exist.Data.Exists(x => x.Id.Contains(It.IsAny<string>())));
            Assert.Equal("No existe", result.Message);

            return Task.CompletedTask;
        }

        //PUT Usuario UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "PUT Usuario with Exception")]
        public Task PutUsuarioException()
        {
            _serviceMock
                .Setup(p => p.Update(_sMock.Object))
                .Throws(new RCVException("", new Exception()));

            _serviceMock
                .Setup(p => p.GetUsuariosByID(_sMock.Object.Id))
                .Returns(new List<UsuarioDTO>() { _sMock.Object });

            var ex = _controller.PutUsuario(_sMock.Object);

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }


        //DELETE Usuario UNIT TEST
        [Fact(DisplayName = "DELETE Usuario")]
        public Task DeleteUsuario_Test()
        {

            _serviceMock
                .Setup(x => x.Select(It.IsAny<string>()));

            _serviceMock
                .Setup(i => i.Delete(_sMock.Object));

            var result = _controller.DeleteUsuario(It.IsAny<string>());

            //Assert.True(exist.Success);
            //Assert.NotNull(exist);

            Assert.IsType<ApplicationResponse<UsuarioDTO>>(result);
            return Task.CompletedTask;
        }

        //DELETE Usuario UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "DELETE Usuario with Exception")]
        public Task DeleteUsuario_WithException()
        {
            _serviceMock
                .Setup(x => x.Select(It.IsAny<string>()))
                .Throws(new RCVException("", new Exception()));

            _serviceMock
                .Setup(i => i.Delete(_sMock.Object));

            var ex = _controller.DeleteUsuario(It.IsAny<string>());

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }

    }
}

