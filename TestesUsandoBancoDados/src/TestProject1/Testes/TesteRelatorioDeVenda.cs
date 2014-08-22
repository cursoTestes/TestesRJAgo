using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using MbUnit.Framework;
using SistemaVendas.Negocio;
using NHibernate;

namespace TestProject1.Testes
{
    [TestFixture]
    public class TesteRelatorioDeVenda : TesteBase
    {
        private ISession _session;
        private RelatorioVendas _relatorioVendas;

        [SetUp]
        public void Initialize()
        {
            //colocar codigo comum a varios testes dentro deste metodo. Ele é rodado antes dos testes.
            _session = Contexto.SessionFactory.OpenSession();
            _relatorioVendas = new RelatorioVendas(_session);
        }
        [Test]
        public void teste_consulta_vendedor_inexistente()
        {
            decimal valorEsperado = 0;
            int idVendedor = 0;
            int ano = 2011;

            decimal valorAnual = _relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);
            
            Assert.AreEqual(valorEsperado, valorAnual);
        }

        [Test]
        public void teste_consulta_vendedor_com_uma_venda_no_ano()
        {
            decimal valorEsperado = 1000;
            int idVendedor = 1;
            int ano = 2011;

            decimal valorAnual = _relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);
        }

        [Test]
        public void teste_consulta_vendedor_com_duas_vendas_no_ano()
        {
            decimal valorEsperado = 5000;
            int idVendedor = 2;
            int ano = 2012;

            decimal valorAnual = _relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);
        }

        [Test]
        public void teste_consulta_vendedor_com_duas_vendas_em_anos_diferentes()
        {
            decimal valorEsperado = 20000;
            int idVendedor = 3;
            int ano = 2000;

            decimal valorAnual = _relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);
        }

        [Test]
        public void teste_consulta_um_vendedor_com_uma_venda_compartilhada()
        {
            decimal valorEsperado = 3750;
            int idVendedor = 3;
            int ano = 2008;

            decimal valorAnual = _relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);
        }

        [Test]
        public void teste_consulta_um_vendedor_com_uma_venda_compartilhada_e_uma_venda_simples()
        {
            decimal valorEsperado = 11750;
            int idVendedor = 4;
            int ano = 2009;

            decimal valorAnual = _relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);
        }
    }
}
