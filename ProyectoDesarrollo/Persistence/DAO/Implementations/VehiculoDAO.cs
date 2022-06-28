using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;
using System;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using System.Threading.Tasks;
using System.Linq;

namespace ProyectoDesarrollo.Persistence.DAO.Implementations;

public class VehiculoDAO: DAO<Vehiculo>
{
    public readonly DataBaseContext _dataBaseContext;

    public VehiculoDAO(DataBaseContext dataBaseContext)
    {
        _dataBaseContext = dataBaseContext;
    }

    public override IEnumerable<Vehiculo> Get()
    {
        throw new NotImplementedException();
    }

    public VehiculoDTO GetVehiculo(string Placa)
    {
        var query = _dataBaseContext.Vehiculos
            .Where(x => x.Placa == Placa)
            .Select(x => new VehiculoDTO
            {
                Placa = x.Placa,
                Modelo = x.Modelo,
                Estado = x.Estado,
                Tipo = x.Tipo,
                SerialCarroceria = x.SerialCarroceria,
                Año = x.Año,
                Peso = x.Peso,
                NumeroDeEjes = x.NumeroDeEjes,
                Color = x.Color,
                NumeroDePuestos = x.NumeroDePuestos,
                Id_Propietario = x.Id_Propietario,
                Id_Marca = x.Id_Marca
            });
        return query.First();
    }

    public Task Add(VehiculoDTO  vehiculoDTO)
    {
        Vehiculo vehiculo = new Vehiculo();
        vehiculo.Placa = vehiculoDTO.Placa;
        vehiculo.Modelo = vehiculoDTO.Modelo;
        vehiculo.Estado = vehiculoDTO.Estado;
        vehiculo.Tipo = vehiculoDTO.Tipo;
        vehiculo.SerialCarroceria = vehiculoDTO.SerialCarroceria;
        vehiculo.Año = vehiculoDTO.Año;
        vehiculo.Peso = vehiculoDTO.Peso;
        vehiculo.NumeroDeEjes = vehiculoDTO.NumeroDeEjes;
        vehiculo.Color  = vehiculoDTO.Color;
        vehiculo.NumeroDePuestos = vehiculoDTO.NumeroDePuestos;
        vehiculo.Id_Propietario= vehiculoDTO.Id_Propietario;
        vehiculo.Id_Marca= vehiculoDTO.Id_Marca;
        _dataBaseContext.Vehiculos.Add(vehiculo);
        _dataBaseContext.SaveChanges();
        return Task.CompletedTask;
    }

    public Task Update(VehiculoDTO  vehiculoDTO,string Placa)
    {
        var ItemToUpdate = _dataBaseContext.Vehiculos.Find(Placa);
        ItemToUpdate.Modelo = vehiculoDTO.Modelo;
        ItemToUpdate.Estado = vehiculoDTO.Estado;
        ItemToUpdate.Tipo = vehiculoDTO.Tipo;
        ItemToUpdate.SerialCarroceria = vehiculoDTO.SerialCarroceria;
        ItemToUpdate.Año = vehiculoDTO.Año;
        ItemToUpdate.Peso = vehiculoDTO.Peso;
        ItemToUpdate.NumeroDeEjes= vehiculoDTO.NumeroDeEjes;
        ItemToUpdate.Color= vehiculoDTO.Color;
        ItemToUpdate.NumeroDePuestos= vehiculoDTO.NumeroDePuestos;
        ItemToUpdate.Id_Propietario= vehiculoDTO.Id_Propietario;
        ItemToUpdate.Id_Marca= vehiculoDTO.Id_Marca;
        _dataBaseContext.SaveChanges();

        return Task.CompletedTask;
    }

    public Task Delete(string Placa)
    {
        var ItemToRemove = _dataBaseContext.Vehiculos.Find(Placa);
        _dataBaseContext.Vehiculos.Remove(ItemToRemove);
        _dataBaseContext.SaveChanges();
        return Task.CompletedTask;
    }
}