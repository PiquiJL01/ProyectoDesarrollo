using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Controllers.Cotizacion;
using RCVUcab.Exceptions;
using RCVUcab.Persistence.DAOs.Interfaces;
using RCVUcab.Responses;
using Xunit;

namespace TestProject.RCVUcab.UnitTests.Controllers.Proveedor
{
    public class CotizacionControllerTest
    {
        private readonly CotizacionController _controller;
        private readonly Mock<ICotizacionDAO> _serviceMock;
        private readonly Mock<CotizacionDTO> _sMock;
        private readonly Mock<ILogger<CotizacionController>> _loggerMock;

        public CotizacionControllerTest()
        {
            _loggerMock = new Mock<ILogger<CotizacionController>>();
            _serviceMock = new Mock<ICotizacionDAO>();
            _sMock = new Mock<CotizacionDTO>();
            _sMock.Object.Id = "1";
            _controller = new CotizacionController(new Mock<ILogger<CotizacionController>>().Object, _serviceMock.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }

        //GET Cotizacion UNIT TEST
        [Fact(DisplayName = "GET Cotizaciones")]
        public Task GetCotizaciones()
        {
            _serviceMock
                .Setup(x => x.Select())
                .Returns(new List<CotizacionDTO>());

            var result = _controller.GetCotizaciones();

            Assert.IsType<ApplicationResponse<List<CotizacionDTO>>>(result);
            return Task.CompletedTask;
        }


        //GET Cotizacion UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "GET Cotizaciones with Exception")]
        public Task GetCotizacionesException()
        {
            _serviceMock
                .Setup(x => x.Select())
                .Throws(new RCVException("", new Exception()));

            var ex = _controller.GetCotizaciones();

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }


        //GET Cotizacion BY ID UNIT TEST
        [Fact(DisplayName = "GET Cotizaciones By Id")]
        public Task GetCotizacionesById()
        {
            _serviceMock
                .Setup(x => x.GetCotizacionesByID(It.IsAny<string>()))
                .Returns(new List<CotizacionDTO>());

            var result = _controller.GetCotizacionById("");

            Assert.IsType<ApplicationResponse<List<CotizacionDTO>>>(result);
            return Task.CompletedTask;
        }


        //GET Cotizacion BY ID UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "GET Cotizaciones By Id with Exception")]
        public Task GetCotizacionesByIdException()
        {
            _serviceMock
                .Setup(x => x.GetCotizacionesByID(It.IsAny<string>()))
                .Throws(new RCVException("", new Exception()));

            var ex = _controller.GetCotizacionById("");

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }

        //PUT Cotizacion UNIT TEST IF EXIST
        [Fact(DisplayName = "PUT Cotizacion if Id Exist")]
        public Task PutCotizacion()
        {

            _serviceMock
                .Setup(x => x.Update(_sMock.Object));

            _serviceMock
                .Setup(i => i.GetCotizacionesByID(It.IsAny<string>()))
                .Returns(new List<CotizacionDTO>());


            var exist = _controller.GetCotizacionById("");
            var result = _controller.PutCotizacion(_sMock.Object);

            Assert.True(exist.Success);
            Assert.NotNull(exist);

            Assert.IsType<ApplicationResponse<CotizacionDTO>>(result);
            return Task.CompletedTask;
        }



        //PUT Cotizacion UNIT TEST IF NOT EXIST
        [Fact(DisplayName = "PUT Cotizacion if Id does not exist")]
        public Task PutCotizacionIfIdDoesNotExist()
        {

            _serviceMock
                .Setup(x => x.Update(_sMock.Object));

            _serviceMock
                .Setup(i => i.GetCotizacionesByID(It.IsAny<string>()))
                .Returns(new List<CotizacionDTO>());


            var exist = _controller.GetCotizacionById("");
            var result = _controller.PutCotizacion(_sMock.Object);

            Assert.False(exist.Data.Exists(x => x.Id.Contains(It.IsAny<string>())));
            Assert.Equal("No existe", result.Message);

            return Task.CompletedTask;
        }

        //PUT Cotizacion UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "PUT Cotizacion with Exception")]
        public Task PutCotizacionException()
        {
            _serviceMock
                .Setup(p => p.Update(_sMock.Object))
                .Throws(new RCVException("", new Exception()));

            _serviceMock
                .Setup(p => p.GetCotizacionesByID(_sMock.Object.Id))
                .Returns(new List<CotizacionDTO>() { _sMock.Object });

            var ex = _controller.PutCotizacion(_sMock.Object);

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }
    }
}

