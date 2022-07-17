﻿using System;
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
    public class TallerControllerTest
    {
        private readonly TallerController _controller;
        private readonly Mock<ITallerDAO> _serviceMock;
        private readonly Mock<ITallerDAO> _serviceMock2;
        private readonly Mock<TallerDTO> _sMock;
        private readonly Mock<ILogger<TallerController>> _loggerMock;

        public TallerControllerTest()
        {
            _loggerMock = new Mock<ILogger<TallerController>>();
            _serviceMock = new Mock<ITallerDAO>();
            _serviceMock2 = new Mock<ITallerDAO>();
            _sMock = new Mock<TallerDTO>();
            _controller = new TallerController(new Mock<ILogger<TallerController>>().Object, _serviceMock.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }


        //GET TALLER UNIT TEST
        [Fact(DisplayName = "Get Talleres")]
        public Task GetTalleres()
        {
            _serviceMock
                .Setup(x => x.Select())
                .Returns(new List<TallerDTO>());

            var result = _controller.GetTalleres();

            Assert.IsType<ApplicationResponse<List<TallerDTO>>>(result);
            return Task.CompletedTask;
        }


        //GET TALLER UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "Get Talleres with Exception")]
        public Task GetTalleresException()
        {
            _serviceMock
                .Setup(x => x.Select())
                .Throws(new RCVException("", new Exception()));

            var ex = _controller.GetTalleres();

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }


        //GET TALLER BY ID UNIT TEST
        [Fact(DisplayName = "Get Talleres By Id")]
        public Task GetTalleresById()
        {
            _serviceMock
                .Setup(x => x.GetTalleresByID(It.IsAny<string>()))
                .Returns(new List<TallerDTO>());

            var result = _controller.GetTallerById("");

            Assert.IsType<ApplicationResponse<List<TallerDTO>>>(result);
            return Task.CompletedTask;
        }


        //GET TALLER BY ID UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "Get Talleres By Id with Exception")]
        public Task GetTalleresByIdException()
        {
            _serviceMock
                .Setup(x => x.GetTalleresByID(It.IsAny<string>()))
                .Throws(new RCVException("", new Exception()));

            var ex = _controller.GetTallerById("");

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }


        //POST TALLER UNIT TEST
        [Fact(DisplayName = "POST Taller")]
        public Task PostTaller()
        {
            _serviceMock
                .Setup(x => x.Insert(_sMock.Object));

            var result = _controller.PostTaller(_sMock.Object);

            Assert.IsType<ApplicationResponse<TallerDTO>>(result);
            return Task.CompletedTask;
        }


        //POST TALLER UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "POST Taller with Exception")]
        public Task PostTallerException()
        {
            _serviceMock
                .Setup(x => x.Insert(_sMock.Object))
                .Throws(new RCVException("", new Exception()));

            var ex = _controller.PostTaller(_sMock.Object);

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }

        /*var response = new ApplicationResponse<TallerDTO>()
            {
                Data = TallerDto
            };

            try
            {
                if (_TallerDao.Select(TallerDto.ID) != null)
                {
                    _TallerDao.Update(TallerDto);

                    response.Message = "El taller ha sido modificado exitosamente";
                }
                else
                {
                    response.Error(new Exception("No existe"));
                }
            }
        */

        //PUT TALLER UNIT TEST IF EXIST
        [Fact(DisplayName = "PUT Taller if Id Exist")]
        public Task PutTaller()
        {

            _serviceMock
                .Setup(x => x.Update(_sMock.Object));

            _serviceMock
                .Setup(i => i.GetTalleresByID(It.IsAny<string>()))
                .Returns(new List<TallerDTO>());

            
            var exist = _controller.GetTallerById("");
            var result = _controller.PutTaller(_sMock.Object);

            Assert.True(exist.Success);
            Assert.NotNull(exist);

            Assert.IsType<ApplicationResponse<TallerDTO>>(result);
            return Task.CompletedTask;
        }



        //PUT TALLER UNIT TEST IF NOT EXIST
        [Fact(DisplayName = "PUT Taller if Id does not exist")]
        public Task PutTallerIfIdDoesNotExist()
        {

            _serviceMock
                .Setup(x => x.Update(_sMock.Object));

            _serviceMock
                .Setup(i => i.GetTalleresByID(It.IsAny<string>()))
                .Returns(new List<TallerDTO>());


            var exist = _controller.GetTallerById("");
            var result = _controller.PutTaller(_sMock.Object);

            //Assert.True(exist.Data.Equals(null));
            Assert.Equal("No existe", result.Message);
            
            return Task.CompletedTask;
        }

        //PUT TALLER UNIT TEST WITH EXCEPTION
        [Fact(DisplayName = "PUT Taller with Exception")]
        public Task PutTallerException()
        {
            _serviceMock
                .Setup(x => x.Insert(_sMock.Object))
                .Throws(new RCVException("", new Exception()));

            var ex = _controller.PostTaller(_sMock.Object);

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }

    }
}
