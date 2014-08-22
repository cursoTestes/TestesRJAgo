using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DojoInterfaceApplication.Models
{

    #region Models
  

    public class VendaModel
    {
        public int idVenda { get; set; }

        [Required]
        [DisplayName("Id Vendedor")]
        public string Vendedor { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Data Venda")]
        public DateTime DataVenda { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Valor")]
        public  String Valor { get; set; }

        
    }


    public class RelatorioVendaModel
    {

        public RelatorioVendaModel()
        {
            listaVendas = new List<RelatorioVendaDTO>();
        }
        [Required]
        [DisplayName("Mês da venda")]
        public int mes { get; set; }

        [Required]
        [DisplayName("Ano da venda")]
        public string ano { get; set; }

        public IList<RelatorioVendaDTO> listaVendas { get; set; }
        
        public string vendaTotalMes { get; set; }


    }

    public class RelatorioVendaDTO
    {
        
        public int Vendedor { get; set; }

        
        public double totalVenda { get; set; }


    }

  
    #endregion

   

}
