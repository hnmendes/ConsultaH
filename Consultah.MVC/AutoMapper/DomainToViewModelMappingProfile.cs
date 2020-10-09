using AutoMapper;
using ConsultaH.Domain.Entities;
using ConsultaH.MVC.ViewModels;

namespace ConsultaH.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<PacienteViewModel, Paciente>();
            Mapper.CreateMap<ExameViewModel, Exame>();
            Mapper.CreateMap<TipoExameViewModel, TipoExame>();
            Mapper.CreateMap<ConsultaViewModel, Consulta>();
        }
    }
}