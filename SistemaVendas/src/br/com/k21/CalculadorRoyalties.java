package br.com.k21;

import java.util.List;

import br.com.k21.dao.VendaDAO;
import br.com.k21.modelo.Venda;

public class CalculadorRoyalties {

	private CalculadoraComissao calculadoraComissao;
	private VendaDAO daoVendas;
	
	public CalculadorRoyalties(CalculadoraComissao calculadoraComissao,
			VendaDAO daoVendas) {
		this.calculadoraComissao = calculadoraComissao;
		this.daoVendas = daoVendas;
	}

	
	public double calcula(int mes, int ano) {
		List<Venda> vendasPorMesEAno = daoVendas.obterVendasPorMesEAno(ano, mes);
		double valorTotal = 0;
		
		for (Venda venda : vendasPorMesEAno) {
			valorTotal += (venda.getValor() );
		}
		
		return valorTotal*0.2;
	}

}
