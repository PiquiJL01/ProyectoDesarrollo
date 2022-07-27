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
    public class VehiculoControllerTest
    {
        private readonly VehiculoController _controller;
        private readonly Mock<IVehiculoDAO> _serviceMock;
        private readonly Mock<VehiculoDTO> _sMock;
        private readonly Mock<ILogger<VehiculoController>> _loggerMock;

        public VehiculoControllerTest()
        {
            _loggerMock = new Mock<ILogger<VehiculoController>>();
            _serviceMock = new Mock<IVehiculoDAO>();
            _sMock = new Mock<VehiculoDTO>();
            _sMock.Object.Placa = "1";
            _controller = new VehiculoController(new Mock<ILogger<VehiculoController>>().Object, _serviceMock.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();

        }


        //GET Vehiculo UNIT TEST
        [Fact(DisplayName = "GET Vehiculos")]
        public Task GetVehiculos()
        {
            _serviceMock
                .Setup(x => x.Select())
                .Returns(new List<VehiculoDTO>());

            var result = _controller.GetVehiculos();

            Assert.IsType<ApplicationResponse<List<VehiculoDTO>>>(result);
            return Task.CompletedTask;
        }


        //GET Vehiculo UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "GET Vehiculos with Exception")]
        public Task GetVehiculosException()
        {
            _serviceMock
                .Setup(x => x.Select())
                .Throws(new RCVException("", new Exception()));

            var ex = _controller.GetVehiculos();

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }


        //GET Vehiculo BY ID UNIT TEST
        [Fact(DisplayName = "GET Vehiculos By Id")]
        public Task GetVehiculosById()
        {
            _serviceMock
                .Setup(x => x.GetVehiculosByID(It.IsAny<string>()))
                .Returns(new List<VehiculoDTO>());

            var result = _controller.GetVehiculoById("");

            Assert.IsType<ApplicationResponse<List<VehiculoDTO>>>(result);
            return Task.CompletedTask;
        }


        //GET Vehiculo BY ID UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "GET Vehiculos By Id with Exception")]
        public Task GetVehiculosByIdException()
        {
            _serviceMock
                .Setup(x => x.GetVehiculosByID(It.IsAny<string>()))
                .Throws(new RCVException("", new Exception()));

            var ex = _controller.GetVehiculoById("");

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }


        //POST Vehiculo UNIT TEST
        [Fact(DisplayName = "POST Vehiculo")]
        public Task PostVehiculo()
        {
            _serviceMock
                .Setup(x => x.Insert(_sMock.Object));

            var result = _controller.PostVehiculo(_sMock.Object);

            Assert.IsType<ApplicationResponse<VehiculoDTO>>(result);
            return Task.CompletedTask;
        }


        //POST Vehiculo UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "POST Vehiculo with Exception")]
        public Task PostVehiculoException()
        {
            _serviceMock
                .Setup(x => x.Insert(_sMock.Object))
                .Throws(new RCVException("", new Exception()));

            var ex = _controller.PostVehiculo(_sMock.Object);

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }


        //PUT Vehiculo UNIT TEST IF EXIST
        [Fact(DisplayName = "PUT Vehiculo if Id Exist")]
        public Task PutVehiculo()
        {

            _serviceMock
                .Setup(x => x.Update(_sMock.Object));

            _serviceMock
                .Setup(i => i.GetVehiculosByID(It.IsAny<string>()))
                .Returns(new List<VehiculoDTO>());


            var exist = _controller.GetVehiculoById("");
            var result = _controller.PutVehiculo(_sMock.Object);

            Assert.True(exist.Success);
            Assert.NotNull(exist);

            Assert.IsType<ApplicationResponse<VehiculoDTO>>(result);
            return Task.CompletedTask;
        }



        //PUT Vehiculo UNIT TEST IF NOT EXIST
        [Fact(DisplayName = "PUT Vehiculo if Id does not exist")]
        public Task PutVehiculoIfIdDoesNotExist()
        {

            _serviceMock
                .Setup(x => x.Update(_sMock.Object));

            _serviceMock
                .Setup(i => i.GetVehiculosByID(It.IsAny<string>()))
                .Returns(new List<VehiculoDTO>());


            var exist = _controller.GetVehiculoById("");
            var result = _controller.PutVehiculo(_sMock.Object);

            Assert.False(exist.Data.Exists(x => x.Placa.Contains(It.IsAny<string>())));
            Assert.Equal("No existe", result.Message);

            return Task.CompletedTask;
        }

        //PUT Vehiculo UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "PUT Vehiculo with Exception")]
        public Task PutVehiculoException()
        {
            _serviceMock
                .Setup(p => p.Update(_sMock.Object))
                .Throws(new RCVException("", new Exception()));

            _serviceMock
                .Setup(p => p.GetVehiculosByID(_sMock.Object.Placa))
                .Returns(new List<VehiculoDTO>() { _sMock.Object });

            var ex = _controller.PutVehiculo(_sMock.Object);

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }


        //DELETE Vehiculo UNIT TEST
        [Fact(DisplayName = "DELETE Vehiculo")]
        public Task DeleteVehiculo_Test()
        {

            _serviceMock
                .Setup(x => x.Select(It.IsAny<string>()));

            _serviceMock
                .Setup(i => i.Delete(_sMock.Object));

            var result = _controller.DeleteVehiculo(It.IsAny<string>());

            //Assert.True(exist.Success);
            //Assert.NotNull(exist);

            Assert.IsType<ApplicationResponse<VehiculoDTO>>(result);
            return Task.CompletedTask;
        }

        //DELETE Vehiculo UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "DELETE Vehiculo with Exception")]
        public Task DeleteVehiculo_WithException()
        {
            _serviceMock
                .Setup(x => x.Select(It.IsAny<string>()))
                .Throws(new RCVException("", new Exception()));

            _serviceMock
                .Setup(i => i.Delete(_sMock.Object));

            var ex = _controller.DeleteVehiculo(It.IsAny<string>());

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }
    }
}

