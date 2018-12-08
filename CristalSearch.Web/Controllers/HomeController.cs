using System.Web.Mvc;
using CristalSearch.Web.Models;
using CristalSearch.Web.Extends;
using CristalSearch.Domain.Cristais.Filtros;

namespace CristalSearch.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SalvarCristal(CristalModel cristal)
        {
            var cristalDTO = cristal.ToDTO();

            Domain.Domain.Cristal.CristalService.SalvarCristal(cristalDTO, out bool nomeDoCristalJaExiste);

            var retorno = new
            {
                NomeDoCristalJaExiste = nomeDoCristalJaExiste
            };
            return Json(retorno);
        }

        public ActionResult CarregarCristais()
        {
            var retorno = new
            {
                Dados = Domain.Domain.Cristal.CristalService.ObterCristais()
            };

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Filtrar(FiltroCristal filtro)
        {
            var retorno = new
            {
                Dados = Domain.Domain.Cristal.CristalService.Filtar(filtro)
            };
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Excluir(string id)
        {
            var tipoFoiAlteradoComSucesso = int.TryParse(id, out int valor);
            if (tipoFoiAlteradoComSucesso)
            {
                Domain.Domain.Cristal.CristalService.Excluir(valor);
            }
            var retorno = true;
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }
    }
}