using AutoMapper;
using unam.Application.DTOs;
using unam.Domain.Entities;
using unam.Domain.Interfaces;

namespace unam.Application.UseCases
{
    public class AgregarMaestro
    {
        private readonly IMaestrosRepository _maestro;
        private readonly IMapper _mapper;

        public AgregarMaestro(IMaestrosRepository maestro, IMapper mapper)
        {
            _maestro = maestro;
            _mapper = mapper;
        }

        public IMapper Mapper { get; }

        public async Task<(bool status, string message)> AgregarMaestroTask(MaestroDTO maestroDTO)
        {

            var nuevoMaestro = _mapper.Map<Maestro>(maestroDTO);
            await _maestro.AgregarMaestroAsync(nuevoMaestro);
            var maestroAgregado = await _maestro.GuardarMaestroAsync();
            if (!maestroAgregado)
            {
                return (false, "Ha ocurrido un error");
            }
            return (true, "Maestro agregado correctamente");
        }
    }
}
