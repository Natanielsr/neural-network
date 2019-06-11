using System;
using System.Collections.Generic;

public class Neuronio
{
  private List<float> valoresEntrada;
 

  public void receberValor(float valor){
    this.valoresEntrada.Add(valor);
  }


  public float Processar(){
    float somatorio = 0;
    for (int i = 0; i < valoresEntrada.Count; i++)
    {
        var valorEntrada = valoresEntrada[i];
        somatorio += valorEntrada;
    }
    return somatorio;
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


   public float Executar(List<float> entradas){
      this.valoresEntrada = entradas;
      var somatorio = this.Processar();
      return funcaoAtivacaoLogistica(somatorio);
   }


}
