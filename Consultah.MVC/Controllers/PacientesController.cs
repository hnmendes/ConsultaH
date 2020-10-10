using AutoMapper;
using Consultah.MVC.ViewModels.ExtensionMethods;
using ConsultaH.Application.Interface;
using ConsultaH.Domain.Entities;
using ConsultaH.MVC.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ConsultaH.MVC.Controllers
{
    public class PacientesController : Controller
    {
        private readonly IPacienteAppService _pacienteApp;

        public PacientesController(IPacienteAppService pacienteApp)
        {
            _pacienteApp = pacienteApp;
        }

        // GET: Pacientes
        public ActionResult Index()
        {
            var pacientes = _pacienteApp.GetAll();
            var pacientesViewModel = Mapper.Map<IEnumerable<Paciente>, IEnumerable<PacienteViewModel>>(pacientes);

            return View(pacientesViewModel);
        }

        // GET: Pacientes/Details/5
        public ActionResult Details(int id)
        {
            var paciente = _pacienteApp.GetById(id);
            var pacienteViewModel = Mapper.Map<Paciente, PacienteViewModel>(paciente);

            return View(pacienteViewModel);
        }

        // GET: Pacientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pacientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,CPF,DataNascimento,Sexo,Telefone,Email")] PacienteViewModel paciente)
        {
            paciente.CPF = paciente.CPF.RemoverCaractereCPF();
            paciente.Telefone = paciente.Telefone.RemoverCaractereTelefone();

            if (ModelState.IsValid)
            {                                
                var pacienteDomain = Mapper.Map<PacienteViewModel, Paciente>(paciente);
                _pacienteApp.Add(pacienteDomain);

                return RedirectToAction("Index");
            }

            return View(paciente);
        }

        // GET: Pacientes/Edit/5
        public ActionResult Edit(int id)
        {
            var paciente = _pacienteApp.GetById(id);
            var pacienteViewModel = Mapper.Map<Paciente, PacienteViewModel>(paciente);

            return View(pacienteViewModel);
        }

        // POST: Pacientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind(Include = "ID,Nome,CPF,DataNascimento,Sexo,Telefone,Email")] PacienteViewModel paciente)
        {
            paciente.CPF = paciente.CPF.RemoverCaractereCPF();
            paciente.Telefone = paciente.Telefone.RemoverCaractereTelefone();

            if (ModelState.IsValid)
            {                

                var pacienteDomain = Mapper.Map<PacienteViewModel, Paciente>(paciente);
                _pacienteApp.Update(pacienteDomain);

                return RedirectToAction("Index");
            }

            return View(paciente);
        }

        // GET: Pacientes/Delete/5
        public ActionResult Delete(int id)
        {
            var paciente = _pacienteApp.GetById(id);
            var pacienteViewModel = Mapper.Map<Paciente, PacienteViewModel>(paciente);

            return View(pacienteViewModel);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var paciente = _pacienteApp.GetById(id);
            _pacienteApp.Remove(paciente);

            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public JsonResult CPFExists(string CPF)
        {
            var paciente = Json(_pacienteApp.CPFExists(CPF));

            return paciente;
        }
    }
}
