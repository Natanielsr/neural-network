using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarNeuralNetworkController : MonoBehaviour
{
    // Start is called before the first frame update

    public double[] Sensors;

    RedeNeural network;

    CarBehaviour car; 

    void Start()
    {
        
        car = GetComponent<CarBehaviour>();
        network = new RedeNeural(car.distanceSensors.Length,car.distanceSensors.Length-1,2);
        Sensors = new double[car.distanceSensors.Length];
    }

    // Update is called once per frame
    void Update()
    {
        receiveSensors();
        var result = processNetwork();
        car.inputVertical = (float)result.data[0][0];
        car.inputHorizontal = (float)result.data[1][0];
    }

    void receiveSensors(){
        for (int i = 0; i <  car.distanceSensors.Length; i++)
        {
            Sensors[i] = car.distanceSensors[i];
        }
    }

    Matrix processNetwork(){
        var timeA = DateTime.Now;
        var result = network.feedFoward(Sensors);
        var timeB = DateTime.Now;
        var time = timeB - timeA;
        //UnityEngine.Debug.Log(time);
        return result;
    }
}
