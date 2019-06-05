

public class Ligacao
{
    float peso;
    float valorEntrada;
    float pesoCalculado;
    private Neuronio NeuronioSaida;

    public Ligacao(float peso){
      
        this.peso = peso;
    }

    public void receberValor(float valor){
        this.valorEntrada = valor;
    }

    public void calcularPeso(){
        var resultado = valorEntrada * peso;
        pesoCalculado =  resultado;
    }

    public void transmitirValorAoNeuronio(){
        NeuronioSaida.receberValor(pesoCalculado);
    }

    public void ExecutarPrimeiraVez(float valor, Neuronio NeuronioSaida){
        this.NeuronioSaida = NeuronioSaida;
        this.receberValor(valor);
       // this.calcularPeso();
        this.pesoCalculado = valor;
        this.transmitirValorAoNeuronio();
    }

     public void ExecutarNormal(Neuronio NeuronioSaida){
        this.NeuronioSaida = NeuronioSaida;
        this.calcularPeso();
        this.transmitirValorAoNeuronio();
    }

    
}
