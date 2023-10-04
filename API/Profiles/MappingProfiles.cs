using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pais,PaisDto>().ReverseMap();
            CreateMap<Cita,CitaDto>().ReverseMap();
            CreateMap<Ciudad,CiudadDto>().ReverseMap();
            CreateMap<Cliente,ClienteDto>().ReverseMap();
            CreateMap<ClienteTelefono,ClienteTelefonoDto>().ReverseMap();
            CreateMap<Departamento,DepartamentoDto>().ReverseMap();
            CreateMap<Mascota,MascotaDto>().ReverseMap();
            CreateMap<Raza,RazaDto>().ReverseMap();
            CreateMap<Servicio,ServicioDto>().ReverseMap();
            /* me falto hacer el de las direcciones por eso solo hay 9 y no 10 */
        }
    }
}