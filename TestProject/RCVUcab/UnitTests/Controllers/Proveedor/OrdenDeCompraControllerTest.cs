using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Controllers.Proveedor;
using RCVUcab.Exceptions;
using RCVUcab.Persistence.DAOs.Interfaces;
using RCVUcab.Responses;
using Xunit;


namespace TestProject.RCVUcab.UnitTests.Controllers.Proveedor
{
    public class OrdenDeCompraControllerTest
    {
        private readonly OrdenDeCompraController _controller;
        private readonly Mock<IOrdenDeCompraDAO> _serviceMock;
        private readonly Mock<OrdenDeCompraDTO> _sMock;
        private readonly Mock<ILogger<OrdenDeCompraController>> _loggerMock;

        public OrdenDeCompraControllerTest()
        {
            _loggerMock = new Mock<ILogger<OrdenDeCompraController>>();
            _serviceMock = new Mock<IOrdenDeCompraDAO>();
            _sMock = new Mock<OrdenDeCompraDTO>();
            _sMock.Object.ID = "1";
            _controller = new OrdenDeCompraController(new Mock<ILogger<OrdenDeCompraController>>().Object, _serviceMock.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }

        //GET OrdenDeCompra UNIT TEST
        [Fact(DisplayName = "GET OrdenesDeCompra")]
        public Task GetOrdenesDeCompra()
        {
            _serviceMock
                .Setup(x => x.Select())
                .Returns(new List<OrdenDeCompraDTO>());

            var result = _controller.GetOrdenesDeCompra();

            Assert.IsType<ApplicationResponse<List<OrdenDeCompraDTO>>>(result);
            return Task.CompletedTask;
        }


        //GET OrdenDeCompra UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "GET OrdenesDeCompra with Exception")]
        public Task GetOrdenesDeCompraException()
        {
            _serviceMock
                .Setup(x => x.Select())
                .Throws(new RCVException("", new Exception()));

            var ex = _controller.GetOrdenesDeCompra();

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }


        //GET OrdenDeCompra BY ID UNIT TEST
        [Fact(DisplayName = "GET OrdenesDeCompra By Id")]
        public Task GetOrdenesDeCompraById()
        {
            _serviceMock
                .Setup(x => x.GetOrdenesDeCompraByID(It.IsAny<string>()))
                .Returns(new List<OrdenDeCompraDTO>());

            var result = _controller.GetOrdenDeCompraById("");

            Assert.IsType<ApplicationResponse<List<OrdenDeCompraDTO>>>(result);
            return Task.CompletedTask;
        }


        //GET OrdenDeCompra BY ID UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "GET OrdenesDeCompra By Id with Exception")]
        public Task GetOrdenesDeCompraByIdException()
        {
            _serviceMock
                .Setup(x => x.GetOrdenesDeCompraByID(It.IsAny<string>()))
                .Throws(new RCVException("", new Exception()));

            var ex = _controller.GetOrdenDeCompraById("");

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }


        //PUT OrdenDeCompra UNIT TEST IF EXIST
        [Fact(DisplayName = "PUT OrdenDeCompra if Id Exist")]
        public Task PutOrdenDeCompra()
        {

            _serviceMock
                .Setup(x => x.Update(_sMock.Object));

            _serviceMock
                .Setup(i => i.GetOrdenesDeCompraByID(It.IsAny<string>()))
                .Returns(new List<OrdenDeCompraDTO>());


            var exist = _controller.GetOrdenDeCompraById("");
            var result = _controller.PutOrdenDeCompra(_sMock.Object);

            Assert.True(exist.Success);
            Assert.NotNull(exist);

            Assert.IsType<ApplicationResponse<OrdenDeCompraDTO>>(result);
            return Task.CompletedTask;
        }



        //PUT OrdenDeCompra UNIT TEST IF NOT EXIST
        [Fact(DisplayName = "PUT OrdenDeCompra if Id does not exist")]
        public Task PutOrdenDeCompraIfIdDoesNotExist()
        {

            _serviceMock
                .Setup(x => x.Update(_sMock.Object));

            _serviceMock
                .Setup(i => i.GetOrdenesDeCompraByID(It.IsAny<string>()))
                .Returns(new List<OrdenDeCompraDTO>());


            var exist = _controller.GetOrdenDeCompraById("");
            var result = _controller.PutOrdenDeCompra(_sMock.Object);

            Assert.False(exist.Data.Exists(x => x.ID.Contains(It.IsAny<string>())));
            Assert.Equal("No existe", result.Message);

            return Task.CompletedTask;
        }

        //PUT OrdenDeCompra UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "PUT OrdenDeCompra with Exception")]
        public Task PutOrdenDeCompraException()
        {
            _serviceMock
                .Setup(p => p.Update(_sMock.Object))
                .Throws(new RCVException("", new Exception()));

            _serviceMock
                .Setup(p => p.GetOrdenesDeCompraByID(_sMock.Object.ID))
                .Returns(new List<OrdenDeCompraDTO>() { _sMock.Object });

            var ex = _controller.PutOrdenDeCompra(_sMock.Object);

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }
    }
}

