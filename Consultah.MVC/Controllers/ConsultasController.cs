using AutoMapper;
using ConsultaH.Application.Interface;
using ConsultaH.Domain.Entities;
using ConsultaH.MVC.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ConsultaH.MVC.Controllers
{
    public class ConsultasController : Controller
    {
        private readonly IConsultaAppService _consultaApp;

        private readonly ITipoExameAppService _tipoExameApp;

        private readonly IExameAppService _exameApp;

        private readonly IPacienteAppService _pacienteApp;

        public ConsultasController(IConsultaAppService consultaApp, ITipoExameAppService tipoExameApp, IExameAppService exameApp, IPacienteAppService pacienteApp)
        {
            _consultaApp = consultaApp;
            _tipoExameApp = tipoExameApp;
            _exameApp = exameApp;
            _pacienteApp = pacienteApp;
        }

        // GET: Consultas
        public ActionResult Index()
        {
            var consultas = _consultaApp.GetAll();
            var consultaViewModel = Mapper.Map<IEnumerable<Consulta>, IEnumerable<ConsultaViewModel>>(consultas);

            return View(consultaViewModel);
        }

        // TODO - Fazer a parte do front-end da view Details
        // GET: Consultas/Details/5
        public ActionResult Details(int id)
        {
            var consulta = _consultaApp.GetById(id);
            var consultaViewModel = Mapper.Map<Consulta, ConsultaViewModel>(consulta);

            return View(consultaViewModel);
        }

        // GET: Consultas/Create
        public ActionResult Create()
        {
            var tipoExamesDomain = _tipoExameApp.GetAll();
            var tipoExamesViewModel = Mapper.Map<IEnumerable<TipoExame>, IEnumerable<TipoExameViewModel>>(tipoExamesDomain);
            ViewBag.TipoExameID = new SelectList(tipoExamesViewModel, "ID", "Nome");

            return View();
        }

        // POST: Consultas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PacienteID,TipoExameID,ExameID,Horario")] ConsultaViewModel consulta)
        {
            var tipoExamesDomain = _tipoExameApp.GetAll();
            var tipoExamesViewModel = Mapper.Map<IEnumerable<TipoExame>, IEnumerable<TipoExameViewModel>>(tipoExamesDomain);
            ViewBag.TipoExameID = new SelectList(tipoExamesViewModel, "ID", "Nome");

            if (ModelState.IsValid)
            {
                var consultaDomain = Mapper.Map<ConsultaViewModel, Consulta>(consulta);
                _consultaApp.Add(consultaDomain);

                return RedirectToAction("Index");
            }
            
            return View(consulta);
            
        }

        // TODO - Fazer a parte do front-end da view Edit
        // GET: Consultas/Edit/5
        public ActionResult Edit(int id)
        {
            var consulta = _consultaApp.GetById(id);
            var consultaViewModel = Mapper.Map<Consulta, ConsultaViewModel>(consulta);
            
            var tipoExamesDomain = _tipoExameApp.GetAll();
            var tipoExamesViewModel = Mapper.Map<IEnumerable<TipoExame>, IEnumerable<TipoExameViewModel>>(tipoExamesDomain);                       
            
            ViewBag.TipoExameID = new SelectList(tipoExamesViewModel, "ID", "Nome", consultaViewModel.TipoExameID);

            return View(consultaViewModel);
        }

        // TODO - Fazer a parte do front-end da view Edit
        // POST: Consultas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind(Include = "ID,PacienteID,TipoExameID,ExameID,Horario")] ConsultaViewModel consulta)
        {
            if (ModelState.IsValid)
            {
                var consultaDomain = Mapper.Map<ConsultaViewModel, Consulta>(consulta);
                _consultaApp.Update(consultaDomain);

                return RedirectToAction("Index");
            }    
            
            return View(consulta);
            
        }

        // GET: Consultas/Delete/5
        public ActionResult Delete(int id)
        {
            var consulta = _consultaApp.GetById(id);
            var consultaViewModel = Mapper.Map<Consulta, ConsultaViewModel>(consulta);

            return View(consultaViewModel);
        }

        // POST: Consultas/Deleted/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var consulta = _consultaApp.GetById(id);
            _consultaApp.Remove(consulta);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult GetSearchCpfOrName(string cpfOuNome)
        {
            var pacientes = Json(_pacienteApp.GetPacienteByNameOrCpf(cpfOuNome));

            return pacientes;
        }

        [HttpPost]
        public JsonResult GetAllPacientes()
        {
            var pacientes = Json(_pacienteApp.GetAll());

            return pacientes;
        }

        [HttpPost]
        public JsonResult GetAllExamesByTipo(int tipoExameId)
        {
            var examesByTipo = Json(_exameApp.GetExamesByTipoExameId(tipoExameId));

            return examesByTipo;
        }
    }
}
