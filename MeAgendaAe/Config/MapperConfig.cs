using AutoMapper;
using MeAgendaAe.Dominio.Dtos;
using MeAgendaAe.Dominio.Entidades;
using MeAgendaAe.Dominio.Model;
using MeAgendaAe.Dominio.ViewModel.Clientes.Saida;
using MeAgendaAe.Dominio.ViewModel.Empresas.Saida;

namespace MeAgendaAe.Config
{
    public class MapperConfig
    {
        public static MapperConfiguration RegistrarMaps()
        {
            var mappingsConfigs = new MapperConfiguration(config =>
            {
                config.CreateMap<TbAgendamentos, Agendamentos>().ReverseMap();
                config.CreateMap<TbAgendamentos, DtoAgendamento>().ReverseMap();

                config.CreateMap<TbCliente, ClientesModel>().ReverseMap();
                config.CreateMap<TbEmpresas, EmpresasModel>().ReverseMap();
            });

            return mappingsConfigs;
        }
    }
}
