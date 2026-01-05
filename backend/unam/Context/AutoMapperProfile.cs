using AutoMapper;
using unam.Application.DTOs;
using unam.Domain.Entities;

namespace unam.Context
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SolicitudDTO, Solicitud>().ReverseMap();
            CreateMap<EstudianteDTO, Estudiante>().ReverseMap();
            CreateMap<SeccionDTO, Seccion>().ReverseMap();
            CreateMap<MaestroDTO, Maestro>().ReverseMap();
        }
    }
}
