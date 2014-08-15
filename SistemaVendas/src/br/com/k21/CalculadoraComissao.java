package br.com.k21;

public class CalculadoraComissao {

	public static double calcula(double venda) {
		double total = venda * 0.05;
		
		total *=100;
		total = Math.floor(total);
		total = total /100;
		
		return total;
	}

}
