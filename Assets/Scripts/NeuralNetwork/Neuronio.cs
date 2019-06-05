using System;
using System.Collections.Generic;

public class Neuronio
{
  private List<float> valoresEntrada;
 
  public bool funcaoAtivacao = true;
  float somatorio;
  List<Ligacao> LigacoesSaidas;

  public Neuronio(){
    this.valoresEntrada = new List<float>();
    
  }

  public void receberValor(float valor){
    this.valoresEntrada.Add(valor);
  }


  public void Processar(){
    for (int i = 0; i < valoresEntrada.Count; i++)
    {
        var valorEntrada = valoresEntrada[i];
        somatorio += valorEntrada;
    }
  }

  float funcaoAtivacaoLogistica(float u){

    var euler = 2.718281;
    var inclinacao = 1;

    var a = -(inclinacao*u);
    var b = Math.Pow(euler,a);
    var c = (1+b);
    var resultado = 1/c;

    return (float)resultado;
  }

  public float EnviarValorASaida(){
    if(LigacoesSaidas== null){
      
      return funcaoAtivacaoLogistica(somatorio);;
    }
    for (int i = 0; i < LigacoesSaidas.Count; i++)
    {
        var ligacaoSaida = LigacoesSaidas[i];
        var valorConvertido = somatorio;
        if(funcaoAtivacao)
          valorConvertido = funcaoAtivacaoLogistica(somatorio);
        ligacaoSaida.receberValor(valorConvertido);
    }
    return somatorio;
  }

   public float Executar(List<Ligacao> LigacoesSaidas){
      this.LigacoesSaidas = LigacoesSaidas;
      this.Processar();
      return this.EnviarValorASaida();;
    }

    public float ExecutarPrimeiraVez(float valor, List<Ligacao> LigacoesSaidas){
      this.funcaoAtivacao = false;
      this.receberValor(valor);
      return Executar(LigacoesSaidas);
    }

}
