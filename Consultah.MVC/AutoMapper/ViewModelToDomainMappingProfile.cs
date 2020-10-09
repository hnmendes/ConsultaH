using AutoMapper;
using ConsultaH.Domain.Entities;
using ConsultaH.MVC.ViewModels;

namespace ConsultaH.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Paciente, PacienteViewModel>();
            Mapper.CreateMap<Exame, ExameViewModel>();
            Mapper.CreateMap<TipoExame, TipoExameViewModel>();
            Mapper.CreateMap<Consulta, ConsultaViewModel>();
        }
    }
}