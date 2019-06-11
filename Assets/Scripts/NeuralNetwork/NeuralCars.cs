using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuralCars : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Neuronio neuronio = new Neuronio();
        var ligacao = new Ligacao();
        float peso1 = 0, peso2 = 0, peso3 = 0, peso4 = 0, peso5 = 0, peso6 = 0; 

        //camada 1
        var entrada1 = 1;//entrada
        if(entrada1 > 0)
        {
            peso1 = ligacao.calcularPeso(entrada1, 1);
            peso2 = ligacao.calcularPeso(entrada1, 1);
        }

        var entrada2 = 1;
        if(entrada2 > 0)
        {
            peso3 = ligacao.calcularPeso(entrada2, 1);
            peso4 = ligacao.calcularPeso(entrada2, 1);
        }

        var entrada3 = 1;
        if(entrada3 > 0)
        {
            peso5 = ligacao.calcularPeso(entrada3, 1);
            peso6 = ligacao.calcularPeso(entrada3, 1);
        }
        //

        //camada 2
        var resAceleracao = neuronio.Executar(new List<float>(){peso1, peso3, peso5});//saida
        var resDirecao = neuronio.Executar(new List<float>(){peso2, peso4 ,peso6});//saida
        //

        UnityEngine.Debug.Log("Aceleracao: "+resAceleracao);
        UnityEngine.Debug.Log("resDirecao: "+resDirecao);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
