﻿using System;
using System.Collections.Generic;
using Administracion.Controllers.APIs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Moq;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using ProyectoDesarrollo.Persistence.DAO.Implementations;
using ProyectoDesarrollo.Responses;
using Xunit;

namespace TestProject.Administracion.APIs;

public class PropietarioControllerTest
{
    private readonly PropietarioController _controller;
    private readonly Mock<PropietarioDAO> _serviceMock;
    private readonly PropietarioDTO _objeto;
    private readonly string _objectId;
    private readonly string _objectIdWrong;
    private readonly IEnumerable<PropietarioDTO> _lista;

    public PropietarioControllerTest()
    {
        _serviceMock = new Mock<PropietarioDAO>();
        _controller = new PropietarioController(_serviceMock.Object);
        _controller.ControllerContext.HttpContext = new DefaultHttpContext();
        _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        _objectId = "1";
        _objeto = new PropietarioDTO() { CedulaRif = _objectId };
        _objectIdWrong = "2";
        _lista = new List<PropietarioDTO>();
    }

    [Fact]
    public void GetAll()
    {
        IEnumerable<PropietarioDTO> lista = new List<PropietarioDTO>();
        ApplicationResponse<IEnumerable<PropietarioDTO>> response =
            new ApplicationResponse<IEnumerable<PropietarioDTO>>(){Data = lista};
        
        _serviceMock.Setup(e => e.Select()).Returns(lista);

        Assert.Equal(response, _controller.Get());
    }

    [Fact]
    public void GetAllException()
    {
        Exception exception = new Exception();;
        ApplicationResponse<IEnumerable<PropietarioDTO>> response =
            new ApplicationResponse<IEnumerable<PropietarioDTO>>();
        response.Error(exception);

        _serviceMock.Setup(e => e.Select()).Throws(exception);

        Assert.Equal(response, _controller.Get());
    }

    [Fact]
    public void GetById()
    {
        ApplicationResponse<PropietarioDTO> response =
            new ApplicationResponse<PropietarioDTO>() { Data = _objeto };

        _serviceMock.Setup(e => e.Select("1")).Returns(_objeto);

        Assert.Equal(response, _controller.Get("1"));
    }

    [Fact]
    public void GetByIdException()
    {
        Exception e = new Exception();
        ApplicationResponse<PropietarioDTO> response =
            new ApplicationResponse<PropietarioDTO>();
        response.Error(e);

        _serviceMock.Setup(e => e.Select(_objectId)).Throws(e);

        Assert.Equal(response, _controller.Get(_objectId));
    }

    [Fact]
    public void Post()
    {
        ApplicationResponse<string> response =
            new ApplicationResponse<string>();

        _serviceMock.Setup(e => e.Insert(_objeto)).Callback(null);

        Assert.Equal(response, _controller.Post(_objeto));
    }

    [Fact]
    public void PostException()
    {
        Exception exception = new Exception();
        ApplicationResponse<string> response =
            new ApplicationResponse<string>();
        response.Error(exception);

        _serviceMock.Setup(e => e.Insert(_objeto)).Throws(new Exception());

        Assert.Equal(response, _controller.Post(_objeto));
    }

    [Fact]
    public void Put()
    {
        ApplicationResponse<string> response =
            new ApplicationResponse<string>();

        _serviceMock.Setup(e => e.Update(_objeto)).Callback(null);

        Assert.Equal(response, _controller.Put(1, _objeto));
    }

    [Fact]
    public void PutException()
    {
        Exception exception = new Exception();
        ApplicationResponse<string> response =
            new ApplicationResponse<string>();
        response.Error(exception);

        _serviceMock.Setup(e => e.Update(_objeto)).Throws(new Exception());

        Assert.Equal(response, _controller.Put(1, _objeto));
    }

    [Fact]
    public void Delete()
    {
        ApplicationResponse<string> response =
            new ApplicationResponse<string>();

        _serviceMock.Setup(e => e.Delete(_objeto)).Callback(null);

        Assert.Equal(response, _controller.Delete(_objeto));
    }

    [Fact]
    public void DeleteException()
    {
        Exception exception = new Exception();
        ApplicationResponse<string> response =
            new ApplicationResponse<string>();
        response.Error(exception);

        _serviceMock.Setup(e => e.Delete(_objeto)).Throws(new Exception());

        Assert.Equal(response, _controller.Delete(_objeto));
    }
}