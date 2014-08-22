package br.com.k21;

import junit.framework.Assert;

import org.fluentlenium.adapter.FluentTest;
import org.junit.Test;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.ie.InternetExplorerDriver;

public class CadastroDeUmaVendaInterfaceTest extends FluentTest {

	@Override
	public WebDriver getDefaultDriver() {
		return new InternetExplorerDriver();
	}
	
	@Test
	public void teste_venda_com_sucesso() {
		goTo("http://localhost:58034/Venda/Add");
		fill("#Vendedor").with("01");
		fill("#DataVenda").with("01/01/2014");
		fill("#Valor").with("100");
		
		submit("input[type=\"submit\"]");
		
		Assert.assertEquals("Venda concluída.", findFirst("#vendaConcluida").getText());
					
	}	
	
	@Test
	public void teste_cadastra_uma_venda_Sem_preencher_campos_obrigatorios() {
		goTo("http://localhost:58034/Venda/Add");
		fill("#Vendedor").with("");
		fill("#DataVenda").with("");
		fill("#Valor").with("");
		
		submit("input[type=\"submit\"]");
		
		Assert.assertEquals("O campo Id Vendedor é obrigatório.", findFirst("#validacaoVendedor").getText()); 
		Assert.assertEquals("O campo Valor é obrigatório.", findFirst("#validacaoValor").getText()); 
		Assert.assertEquals("O campo Data Venda é obrigatório.", findFirst("#validacaoDataVenda").getText());
					
	}
	
	@Test
	public void teste_cadastra_uma_venda_com_data_invalida() {
		goTo("http://localhost:58034/Venda/Add");
		fill("#Vendedor").with("01");
		fill("#DataVenda").with("01/15/2014");
		fill("#Valor").with("100");
		
		submit("input[type=\"submit\"]");
		
		Assert.assertEquals("Data invalida.", findFirst("#validacaoDataVenda").getText());
					
	}
}
