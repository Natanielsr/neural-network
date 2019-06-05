using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuralCars : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Neuronio Sensor1 = new Neuronio();
        var l1 = new Ligacao(-1);
        var l2 = new Ligacao(-1);

        Neuronio Sensor2 = new Neuronio();
        var l3 = new Ligacao(-1);
        var l4 = new Ligacao(0);

        Neuronio Sensor3 = new Neuronio();
        var l5 = new Ligacao(-1);
        var l6 = new Ligacao(1);

        Neuronio aceleracao = new Neuronio();
        Neuronio direcao = new Neuronio();


        Sensor1.ExecutarPrimeiraVez(1, new List<Ligacao>(){l1, l2});//entrada 
        l1.ExecutarNormal(aceleracao);
        l2.ExecutarNormal(direcao);

        Sensor2.ExecutarPrimeiraVez(1, new List<Ligacao>(){l3, l4});//entrada
        l3.ExecutarNormal(aceleracao);
        l4.ExecutarNormal(direcao);

        Sensor3.ExecutarPrimeiraVez(1, new List<Ligacao>(){l5, l6});//entrada
        l5.ExecutarNormal(aceleracao);
        l6.ExecutarNormal(direcao);

        var resAceleracao = aceleracao.Executar(null);//saida
        var resDirecao = direcao.Executar(null);//saida

        UnityEngine.Debug.Log("Aceleracao: "+resAceleracao);
        UnityEngine.Debug.Log("resDirecao: "+resDirecao);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
