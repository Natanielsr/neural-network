using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingCar : MonoBehaviour
{
    // Start is called before the first frame update

    CarSpawner carSpawner;
    public GameObject BestCar;

    void Start()
    {
        carSpawner = GetComponent<CarSpawner>();
    }

    GameObject getBestCar(){

        GameObject bestCar = null;
        foreach (var car in carSpawner.cars)
        {
            CarStatus carStatus = car.GetComponent<CarStatus>();

            if(bestCar == null)
                bestCar = car;
            else{
                CarStatus bestCarStatus = bestCar.GetComponent<CarStatus>();
                if(carStatus.carGasStationCatchs > bestCarStatus.carGasStationCatchs){
                    bestCar = car;
                }
                else if(carStatus.carGasStationCatchs == bestCarStatus.carGasStationCatchs){
                    if(carStatus.distanceToNextGasStation < bestCarStatus.distanceToNextGasStation)
                    {
                        bestCar = car;
                    }
                }
            }
            
        }
        return bestCar;
    } 


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            
            BestCar = getBestCar();
            print("car "+BestCar.GetComponent<CarStatus>().idCar);
        }
    }
}
