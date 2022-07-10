using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;
using System;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using System.Threading.Tasks;
using System.Linq;
using ProyectoDesarrollo.Persistence.Data;

namespace ProyectoDesarrollo.Persistence.DAO.Implementations;

public class VehiculoDAO: DAO<VehiculoDTO>
{
    public VehiculoDAO(DataBaseContext dataBaseContext):base(dataBaseContext)
    {

    }

    public override List<VehiculoDTO> Select()
    {
        throw new NotImplementedException();
    }

    public override VehiculoDTO Select(string Placa)
    {
        var query = Context().Vehiculos
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

    public override void Insert(VehiculoDTO vehiculoDTO)
    {
        Vehiculo vehiculo = new Vehiculo
        {
            Placa = vehiculoDTO.Placa,
            Modelo = vehiculoDTO.Modelo,
            Estado = vehiculoDTO.Estado,
            Tipo = vehiculoDTO.Tipo,
            SerialCarroceria = vehiculoDTO.SerialCarroceria,
            Año = vehiculoDTO.Año,
            Peso = vehiculoDTO.Peso,
            NumeroDeEjes = vehiculoDTO.NumeroDeEjes,
            Color = vehiculoDTO.Color,
            NumeroDePuestos = vehiculoDTO.NumeroDePuestos,
            Id_Propietario = vehiculoDTO.Id_Propietario,
            Id_Marca = vehiculoDTO.Id_Marca
        };
        Context().Vehiculos.Add(vehiculo);
        Context().SaveChanges();
    }

    public override void Update(VehiculoDTO  vehiculoDto)
    {
        var itemToUpdate = new Vehiculo
        {
            Placa = vehiculoDto.Placa,
            Modelo = vehiculoDto.Modelo,
            Estado = vehiculoDto.Estado,
            Tipo = vehiculoDto.Tipo,
            SerialCarroceria = vehiculoDto.SerialCarroceria,
            Año = vehiculoDto.Año,
            Peso = vehiculoDto.Peso,
            NumeroDeEjes = vehiculoDto.NumeroDeEjes,
            Color = vehiculoDto.Color,
            NumeroDePuestos = vehiculoDto.NumeroDePuestos,
            Id_Propietario = vehiculoDto.Id_Propietario,
            Id_Marca = vehiculoDto.Id_Marca
        };
        Context().Vehiculos.Update(itemToUpdate);
        Context().SaveChanges();
    }

    public override void Delete(VehiculoDTO vehiculoDto)
    {
        var itemToRemove = Context().Vehiculos.Find(vehiculoDto.Placa);
        Context().Vehiculos.Remove(itemToRemove);
        Context().SaveChanges();
    }
}