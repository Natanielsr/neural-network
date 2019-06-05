using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Debug.Log("Start");
        
        //criar neuronios e ligacoes com pesos (1) <-- peso
        var e1 = new Ligacao(1);
        var e2 = new Ligacao(1);
        var e3 = new Ligacao(1);
        Neuronio NeuronioEntrada = new Neuronio();

        var p1 = new Ligacao(1);
        Neuronio NeuronioProcessamento = new Neuronio();

        var s1 = new Ligacao(1);
        Neuronio NeuronioSaida = new Neuronio();

        //-----------------------

        
        e1.ExecutarPrimeiraVez(1, NeuronioEntrada);//valor inicial
        e2.ExecutarPrimeiraVez(0, NeuronioEntrada);//valor inicial
        e3.ExecutarPrimeiraVez(0, NeuronioEntrada);//valor inicial
        NeuronioEntrada.Executar(new List<Ligacao>(){ p1});

        p1.ExecutarNormal(NeuronioProcessamento);
        NeuronioProcessamento.Executar(new List<Ligacao>(){s1});

        s1.ExecutarNormal(NeuronioSaida);
        var resultado = NeuronioSaida.Executar(null);


        UnityEngine.Debug.Log("Resultado: "+resultado);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
