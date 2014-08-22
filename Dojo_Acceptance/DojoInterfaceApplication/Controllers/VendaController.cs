using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DojoInterfaceApplication.Models;
using NHibernate;
using NHibernate.Transform;

namespace DojoInterfaceApplication
{
    public class VendaController : Controller
    {
        //
        // GET: /Venda/Add

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(VendaModel model)
        {
            bool vendaOk = true;

            if (String.IsNullOrEmpty(model.Valor)) vendaOk = false;
            if (String.IsNullOrEmpty(model.Vendedor)) vendaOk = false;
            if (DateTime.Compare(model.DataVenda, DateTime.Now) > 0 ) vendaOk = false;

            if (vendaOk)
            {
                  ViewData["Message"] = "Venda Salva com sucesso!";
                  return  RedirectToAction("Index", "Home");
            }

            ViewData["Message"] = "Algumas condições para o cadastro na venda nao sao satisfatorias!";
            return View();
        }


        //
        // GET: /Venda/RelatorioMensal

        public ActionResult RelatorioMensal()
        {

          

           
      
   
            return View();
        }

        [HttpPost]
        public ActionResult RelatorioMensal(RelatorioVendaModel model)
        {
            ISession _session = Contexto.SessionFactory.OpenSession();
            string query = "select Vendedor, sum(Valor) as total  from venda where year(DataVenda)= :ano and  month(DataVenda)= :mes group by Vendedor ";

            IList<RelatorioVendaDTO> lista = _session.CreateSQLQuery(query).SetParameter("mes", model.mes)
                   .SetParameter("ano", model.ano).SetResultTransformer(Transformers.AliasToBean(typeof(RelatorioVendaDTO))).List<RelatorioVendaDTO>();

            model.listaVendas = lista;

            Console.Write(lista.Count);

            return View(model);
        }
    }


   
}
