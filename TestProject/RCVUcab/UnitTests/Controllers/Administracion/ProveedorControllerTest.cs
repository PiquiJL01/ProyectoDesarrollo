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
    public class ProveedorControllerTest
    {

        private readonly ProveedorController _controller;
        private readonly Mock<IProveedorDAO> _serviceMock;
        private readonly Mock<ProveedorDTO> _sMock;
        private readonly Mock<ILogger<ProveedorController>> _loggerMock;

        public ProveedorControllerTest()
        {
            _loggerMock = new Mock<ILogger<ProveedorController>>();
            _serviceMock = new Mock<IProveedorDAO>();
            _sMock = new Mock<ProveedorDTO>();
            _sMock.Object.Id_Proveedor = "1";
            _controller = new ProveedorController(new Mock<ILogger<ProveedorController>>().Object, _serviceMock.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }

        //GET Proveedor UNIT TEST
        [Fact(DisplayName = "GET Proveedores")]
        public Task GetProveedores()
        {
            _serviceMock
                .Setup(x => x.Select())
                .Returns(new List<ProveedorDTO>());

            var result = _controller.GetProveedores();

            Assert.IsType<ApplicationResponse<List<ProveedorDTO>>>(result);
            return Task.CompletedTask;
        }


        //GET Proveedor UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "GET Proveedores with Exception")]
        public Task GetProveedoresException()
        {
            _serviceMock
                .Setup(x => x.Select())
                .Throws(new RCVException("", new Exception()));

            var ex = _controller.GetProveedores();

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }


        //GET Proveedor BY ID UNIT TEST
        [Fact(DisplayName = "GET Proveedores By Id")]
        public Task GetProveedoresById()
        {
            _serviceMock
                .Setup(x => x.GetProveedoresByID(It.IsAny<string>()))
                .Returns(new List<ProveedorDTO>());

            var result = _controller.GetProveedorById("");

            Assert.IsType<ApplicationResponse<List<ProveedorDTO>>>(result);
            return Task.CompletedTask;
        }


        //GET Proveedor BY ID UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "GET Proveedores By Id with Exception")]
        public Task GetProveedoresByIdException()
        {
            _serviceMock
                .Setup(x => x.GetProveedoresByID(It.IsAny<string>()))
                .Throws(new RCVException("", new Exception()));

            var ex = _controller.GetProveedorById("");

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }


        //POST Proveedor UNIT TEST
        [Fact(DisplayName = "POST Proveedor")]
        public Task PostProveedor()
        {
            _serviceMock
                .Setup(x => x.Insert(_sMock.Object));

            var result = _controller.PostProveedor(_sMock.Object);

            Assert.IsType<ApplicationResponse<ProveedorDTO>>(result);
            return Task.CompletedTask;
        }


        //POST Proveedor UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "POST Proveedor with Exception")]
        public Task PostProveedorException()
        {
            _serviceMock
                .Setup(x => x.Insert(_sMock.Object))
                .Throws(new RCVException("", new Exception()));

            var ex = _controller.PostProveedor(_sMock.Object);

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }


        //PUT Proveedor UNIT TEST IF EXIST
        [Fact(DisplayName = "PUT Proveedor if Id Exist")]
        public Task PutProveedor()
        {

            _serviceMock
                .Setup(x => x.Update(_sMock.Object));

            _serviceMock
                .Setup(i => i.GetProveedoresByID(It.IsAny<string>()))
                .Returns(new List<ProveedorDTO>());


            var exist = _controller.GetProveedorById("");
            var result = _controller.PutProveedor(_sMock.Object);

            Assert.True(exist.Success);
            Assert.NotNull(exist);

            Assert.IsType<ApplicationResponse<ProveedorDTO>>(result);
            return Task.CompletedTask;
        }



        //PUT Proveedor UNIT TEST IF NOT EXIST
        [Fact(DisplayName = "PUT Proveedor if Id does not exist")]
        public Task PutProveedorIfIdDoesNotExist()
        {

            _serviceMock
                .Setup(x => x.Update(_sMock.Object));

            _serviceMock
                .Setup(i => i.GetProveedoresByID(It.IsAny<string>()))
                .Returns(new List<ProveedorDTO>());


            var exist = _controller.GetProveedorById("");
            var result = _controller.PutProveedor(_sMock.Object);

            Assert.False(exist.Data.Exists(x => x.Id_Proveedor.Contains(It.IsAny<string>())));
            Assert.Equal("No existe", result.Message);

            return Task.CompletedTask;
        }

        //PUT Proveedor UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "PUT Proveedor with Exception")]
        public Task PutProveedorException()
        {
            _serviceMock
                .Setup(p => p.Update(_sMock.Object))
                .Throws(new RCVException("", new Exception()));

            _serviceMock
                .Setup(p => p.GetProveedoresByID(_sMock.Object.Id_Proveedor))
                .Returns(new List<ProveedorDTO>() { _sMock.Object });

            var ex = _controller.PutProveedor(_sMock.Object);

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }


        //DELETE Proveedor UNIT TEST
        [Fact(DisplayName = "DELETE Proveedor")]
        public Task DeleteProveedor_Test()
        {

            _serviceMock
                .Setup(x => x.Select(It.IsAny<string>()));

            _serviceMock
                .Setup(i => i.Delete(_sMock.Object));

            var result = _controller.DeleteProveedor(It.IsAny<string>());

            //Assert.True(exist.Success);
            //Assert.NotNull(exist);

            Assert.IsType<ApplicationResponse<ProveedorDTO>>(result);
            return Task.CompletedTask;
        }

        //PUT Proveedor UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "DELETE Proveedor with Exception")]
        public Task DeleteProveedor_WithException()
        {
            _serviceMock
                .Setup(x => x.Select(It.IsAny<string>()))
                .Throws(new RCVException("", new Exception()));

            _serviceMock
                .Setup(i => i.Delete(_sMock.Object));

            var ex = _controller.DeleteProveedor(It.IsAny<string>());

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }

    }
}

