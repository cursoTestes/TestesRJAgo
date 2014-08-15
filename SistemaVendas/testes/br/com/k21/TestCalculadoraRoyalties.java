package br.com.k21;

import static org.junit.Assert.assertEquals;

import java.util.Arrays;
import java.util.List;

import org.junit.Test;
import org.mockito.Mockito;

import br.com.k21.dao.VendaDAO;
import br.com.k21.modelo.Venda;

public class TestCalculadoraRoyalties {
	
	@Test
	public void mesSemVenda() {
		int mes = 1;
		int ano = 2014;
		double esperado = 0;
		CalculadoraComissao calculadoraComissao = Mockito.mock(CalculadoraComissao.class);
		VendaDAO daoVendas = Mockito.mock(VendaDAO.class);
		double retorno = new CalculadorRoyalties(calculadoraComissao, daoVendas).calcula(mes, ano);
				
		assertEquals(esperado, retorno, 0);
	}
	
	@Test
	public void mesComUmaVenda100Retorna19() {
		int mes = 1;
		int ano = 2014;
		double esperado = 19;
		CalculadoraComissao calculadoraComissao = Mockito.mock(CalculadoraComissao.class);
		VendaDAO daoVendas = Mockito.mock(VendaDAO.class);
		List<Venda> vendas = Arrays.asList(new Venda(1, 1, mes, ano, 100));
		Mockito.when(daoVendas.obterVendasPorMesEAno(ano, mes)).thenReturn(vendas);
		Mockito.when(calculadoraComissao.calcula(100)).thenReturn(5.0);
		double retorno = new CalculadorRoyalties(calculadoraComissao, daoVendas).calcula(mes, ano);
				
		assertEquals(esperado, retorno, 0);
	}


	@Test
	public void mesComUmaVenda() {
		int mes = 1;
		int ano = 2014;
		double esperado = 20;
		
		CalculadoraComissao calculadoraComissao = Mockito.mock(CalculadoraComissao.class);
		VendaDAO daoVendas = Mockito.mock(VendaDAO.class);
		
		List<Venda> vendas = Arrays.asList(new Venda(1, 1, mes, ano, 100));
		Mockito.when(daoVendas.obterVendasPorMesEAno(ano, mes)).thenReturn(vendas);
		Mockito.when(calculadoraComissao.calcula(100)).thenReturn(0.0);
		
		double retorno = new CalculadorRoyalties(calculadoraComissao, daoVendas).calcula(mes, ano);
				
		assertEquals(esperado, retorno, 0);
		
		Mockito.verify(calculadoraComissao,Mockito.times(1)).calcula(100);
	}

}
