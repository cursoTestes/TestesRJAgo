package br.com.k21;

import static org.junit.Assert.assertEquals;

import org.junit.Test;

public class TestCalculadoraComissao {
	
	private static final double PRECISAO = 0;

	@Test
	public void calcular_comissao_venda_100_retorna_5() {
		
		double venda = 100;
		double esperado = 5;
		
		double resultado = CalculadoraComissao.calcula(venda);
		
		assertEquals(esperado, resultado,PRECISAO);
	}
	
	@Test
	public void calcular_comissao_venda_10000_retorna_500() {
		
		double venda = 10000;
		double esperado = 500;
		
		double resultado = CalculadoraComissao.calcula(venda);
		
		assertEquals(esperado, resultado,PRECISAO);
	}	
	
	@Test
	public void calcular_comissao_venda_1000_retorna_50() {
		
		double venda = 1000;
		double esperado = 50;
		
		double resultado = CalculadoraComissao.calcula(venda);
		
		assertEquals(esperado, resultado,PRECISAO);
	}	
	
	@Test
	public void calcular_comissao_venda_10_retorna_50_centavos() {
		
		double venda = 10;
		double esperado = 0.5;
		
		double resultado = CalculadoraComissao.calcula(venda);
		
		assertEquals(esperado, resultado, PRECISAO);
	}	
	
	@Test
	public void calcular_comissao_venda_100_50centavos_retorna_5_reais_e_2centavos() {
		double venda = 100.50;
		double esperado = 5.02;
		
		double resultado = CalculadoraComissao.calcula(venda);
		
		assertEquals(esperado, resultado, PRECISAO);
	
	}
	
	@Test
	public void calcular_comissao_venda_55_59centavos_retorna_2_reais_e_77centavos() {
		double venda = 55.59;
		double esperado = 2.77;
		
		double resultado = CalculadoraComissao.calcula(venda);
		
		assertEquals(esperado, resultado, PRECISAO);
	
	}

}
