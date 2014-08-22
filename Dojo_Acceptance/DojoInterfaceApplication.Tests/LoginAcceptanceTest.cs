using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using MbUnit;
using MbUnit.Framework;
using OpenQA.Selenium;
using DojoInterfaceApplication.Models;
using NHibernate;
using OpenQA.Selenium.Chrome;

namespace TestProject1
{
    [TestFixture]
    public class LoginAcceptanceTest : TesteBase
    {
        [Test]
        public void teste_logar_com_sucesso()
        {
            int entradasEsperadasNaTabela = 1;
            String texto_mensagem_logado_com_sucesso = "Welcome, cfc!";

            //act

            driver.Navigate().GoToUrl("http://localhost:8080/AceitacaoComJava/login.seam");
            
            driver.FindElement(By.Id("loginForm:username")).SendKeys("cfc");
		    driver.FindElement(By.Id("loginForm:password")).SendKeys("123456");
		    driver.FindElement(By.Id("loginForm:submit")).Click();
      
	        IWebElement element = driver.FindElement(By.XPath("id('messages')/li[2]"));
		 
		    bool acheiTextoLogadoSucesso = element.Text.Equals(texto_mensagem_logado_com_sucesso);
		    Assert.IsTrue(acheiTextoLogadoSucesso);
            
            ISession session = Contexto.SessionFactory.OpenSession();
            int resultadoEntradasSucessoLog = (int)session.CreateSQLQuery("select count(*) from SucessoLogin").UniqueResult();
		    Assert.AreEqual(entradasEsperadasNaTabela,resultadoEntradasSucessoLog);
		
        }

        [Test]
        public void teste_tentativa_login_usuario_existente_senha_errada()
        {
            int entradasEsperadasNaTabela = 1;
            String texto_mensagem_esperada = "Login failed!";

            //act

            driver.Navigate().GoToUrl("http://localhost:8080/AceitacaoComJava/login.seam");

            driver.FindElement(By.Id("loginForm:username")).SendKeys("cfc");
            driver.FindElement(By.Id("loginForm:password")).SendKeys("999999");
            driver.FindElement(By.Id("loginForm:submit")).Click();

            IWebElement element = driver.FindElement(By.XPath("id('messages')/li[1]"));

            bool acheiTextoLogadoSucesso = element.Text.Equals(texto_mensagem_esperada);
            Assert.IsTrue(acheiTextoLogadoSucesso, "não encontrou o texto de logado com sucesso");

            ISession session = Contexto.SessionFactory.OpenSession();
            int resultadoEntradasSucessoLog = (int)session.CreateSQLQuery("select count(*) from FalhaLogin").UniqueResult();
            Assert.AreEqual(entradasEsperadasNaTabela, resultadoEntradasSucessoLog);

        }

        [Test]
        public void teste_tentativa_login_de_usuario_inexistente()
        {
            int entradasEsperadasNaTabela = 0;
            String texto_mensagem_esperada = "Login failed!";

            //act

            driver.Navigate().GoToUrl("http://localhost:8080/AceitacaoComJava/login.seam");

            driver.FindElement(By.Id("loginForm:username")).SendKeys("cfcOutro");
            driver.FindElement(By.Id("loginForm:password")).SendKeys("999999");
            driver.FindElement(By.Id("loginForm:submit")).Click();

            IWebElement element = driver.FindElement(By.XPath("id('messages')/li[1]"));

            bool acheiTextoLogadoSucesso = element.Text.Equals(texto_mensagem_esperada);
            Assert.IsTrue(acheiTextoLogadoSucesso, "não encontrou o texto de sucesso");

            ISession session = Contexto.SessionFactory.OpenSession();
            int resultadoEntradasFalhaLog = (int)session.CreateSQLQuery("select count(*) from FalhaLogin").UniqueResult();
            Assert.AreEqual(entradasEsperadasNaTabela, resultadoEntradasFalhaLog);

            int resultadoEntradasSucessoLog = (int)session.CreateSQLQuery("select count(*) from SucessoLogin").UniqueResult();
            Assert.AreEqual(entradasEsperadasNaTabela, resultadoEntradasSucessoLog);
        }
    }


}
