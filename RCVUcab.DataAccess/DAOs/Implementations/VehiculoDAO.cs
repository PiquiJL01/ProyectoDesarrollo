using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.DAOs.Interfaces;
using RCVUcab.DataAccess.Database;
using RCVUcab.DataAccess.Entities;
using RCVUcab.DataAccess.Exceptions;

namespace RCVUcab.DataAccess.DAOs.Implementations
{

    public class VehiculoDAO : DAO<VehiculoEntity>, IVehiculoDAO
    {
        public override List<VehiculoEntity> Select()
        {
            try
            {
                var data = Context().Vehiculos
                    .Select(x => new VehiculoEntity
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

                    }).ToList();

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de Talleres: "
                    , ex.Message, ex);
            }
        }

        public List<VehiculoEntity> GetVehiculosByID(string id)
        {
            try
            {
                var data = Context().Vehiculos
                 .Where(x => x.Placa == id)
                 .Select(x => new VehiculoEntity
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

                 }).ToList();

                return data.ToList();

            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar el Taller para el: "
                  + id, ex.Message, ex);
            }

        }

        public override VehiculoEntity Select(string Placa)
        {
            var query = Context().Vehiculos
                .Where(x => x.Placa == Placa)
                .Select(x => new VehiculoEntity
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

        public override void Insert(VehiculoEntity vehiculo)
        {
            Context().Vehiculos.Add(vehiculo);
            Context().SaveChanges();
        }

        public override void Update(VehiculoEntity vehiculo)
        {
            Context().Vehiculos.Update(vehiculo);
            Context().SaveChanges();
        }

        public override void Delete(VehiculoEntity vehiculo)
        {
            Context().Vehiculos.Remove(vehiculo);
            Context().SaveChanges();
        }
    }
}