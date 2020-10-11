using ConsultaH.Application.Interface;
using ConsultaH.Domain.Entities;
using ConsultaH.Domain.Interfaces.Services;
using System;

namespace ConsultaH.Application
{
    public class ConsultaAppService : AppServiceBase<Consulta>, IConsultaAppService
    {
        private readonly IConsultaService _consultaService;

        public ConsultaAppService(IConsultaService consultaService) : base(consultaService)
        {
            _consultaService = consultaService;
        }

        public bool DateExists(DateTime dateTime)
        {
            return _consultaService.DateExists(dateTime);
        }
    }
}
