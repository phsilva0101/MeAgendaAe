using AutoMapper;
using MeAgendaAe.CamadaDados.Tabelas;
using MeAgendaAe.Dominio.Dtos;
using MeAgendaAe.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.CrossCutting.Config
{
    public class MapperConfig
    {
        public static MapperConfiguration RegistrarMaps()
        {
            var mappingsConfigs = new MapperConfiguration(config =>
            {
                config.CreateMap<TbAgendamentos, Agendamentos>().ReverseMap();
                config.CreateMap<TbAgendamentos, DtoAgendamento>().ReverseMap();
            });

            return mappingsConfigs;
        }
    }
}
