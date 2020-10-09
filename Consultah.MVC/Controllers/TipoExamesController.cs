using AutoMapper;
using ConsultaH.Application.Interface;
using ConsultaH.Domain.Entities;
using ConsultaH.MVC.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ConsultaH.MVC.Controllers
{
    public class TipoExamesController : Controller
    {
        private readonly ITipoExameAppService _tipoExameApp;

        public TipoExamesController(ITipoExameAppService tipoExameApp)
        {
            _tipoExameApp = tipoExameApp;
        }

        // GET: TipoExame
        public ActionResult Index()
        {
            var tipoExames = _tipoExameApp.GetAll();
            var tipoExameViewModel = Mapper.Map<IEnumerable<TipoExame>, IEnumerable<TipoExameViewModel>>(tipoExames);

            return View(tipoExameViewModel);            
        }

        // GET: TipoExame/Details/5
        public ActionResult Details(int id)
        {
            var tipoExame = _tipoExameApp.GetById(id);
            var tipoExameViewModel = Mapper.Map<TipoExame, TipoExameViewModel>(tipoExame);

            return View(tipoExameViewModel);
        }

        // GET: TipoExame/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: TipoExame/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Descricao")] TipoExameViewModel tipoExame)
        {
            if (ModelState.IsValid)
            {
                var tipoExameDomain = Mapper.Map<TipoExameViewModel, TipoExame>(tipoExame);
                _tipoExameApp.Add(tipoExameDomain);

                return RedirectToAction("Index");
            }

            return View(tipoExame);
        }

        // GET: TipoExame/Edit/5
        public ActionResult Edit(int id)
        {
            var tipoExame = _tipoExameApp.GetById(id);
            var tipoExameViewModel = Mapper.Map<TipoExame, TipoExameViewModel>(tipoExame);

            return View(tipoExameViewModel);
        }

        // POST: TipoExame/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind(Include = "ID,Nome,Descricao")] TipoExameViewModel tipoExame)
        {
            if (ModelState.IsValid)
            {
                var tipoExameDomain = Mapper.Map<TipoExameViewModel, TipoExame>(tipoExame);
                _tipoExameApp.Update(tipoExameDomain);

                return RedirectToAction("Index");
            }

            return View(tipoExame);
        }

        // GET: TipoExame/Delete/5
        public ActionResult Delete(int id)
        {
            var tipoExame = _tipoExameApp.GetById(id);
            var tipoExameViewModel = Mapper.Map<TipoExame, TipoExameViewModel>(tipoExame);

            return View(tipoExameViewModel);
        }

        // POST: TipoExame/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var tipoExame = _tipoExameApp.GetById(id);
            _tipoExameApp.Remove(tipoExame);

            return RedirectToAction("Index");
        }
    }
}
