using AutoMapper;
using System.Net.NetworkInformation;
using unam.Application.DTOs;
using unam.Domain.Entities;
using unam.Domain.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace unam.Application.UseCases
{
    public class AgregarMaestro
    {
        private readonly IMaestrosRepository _maestro;
        private readonly Random _random = new();

        public AgregarMaestro(IMaestrosRepository maestro)
        {
            _maestro = maestro;
        }

        public async Task<(bool status, string message)> AgregarMaestroTask(Solicitud solicitud)
        {

            var nuevoMaestro = new Maestro
            {
                Nombre = solicitud.Nombre,
                Apellido = solicitud.Apellido,
                Edad = solicitud.Edad,
                CorreoInstitucional = solicitud.Nombre.ToLower() + "@unad.edu.do",
                Pin = _random.Next(10000, 99999),
                NoDocumento = solicitud.NoDocumento,
                Domicilio = solicitud.Domicilio,
                Telefono = solicitud.NumeroTelefono,
                Calificacion = 0,
                FechaIngreso = DateTime.UtcNow,

            };
            await _maestro.AgregarMaestroAsync(nuevoMaestro);
            var maestroGuardado = await _maestro.GuardarMaestroAsync();
            if(!maestroGuardado)
            {
                return (false, "No se pudo agregar el maestro");
            }
            return (true, "Maestro agregado");
        }
    }
}
