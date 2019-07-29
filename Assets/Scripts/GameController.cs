using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    STARTING_CARS,
    TESTING_CARS,
    FINISH_TEST
}
public class GameController : MonoBehaviour
{

    public GameState gameState;
    private CarSpawner carSpawner;

    public int carsStoped = 0;

    private bool finishedTest = false;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.STARTING_CARS;
        carSpawner = FindObjectOfType<CarSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case GameState.STARTING_CARS:
                //spwanar os carros

                carSpawner.StartCarSpawner();
                gameState = GameState.TESTING_CARS;

                finishedTest = false;
                carsStoped = 0;

                break;
            case GameState.TESTING_CARS:
                if(finishedTest == true)
                {
                    gameState = GameState.FINISH_TEST;
                }

                break;
            case GameState.FINISH_TEST:
                DestroyAllCars();
                finishedTest = false;
                gameState = GameState.STARTING_CARS;

                break;
        }
    }

    public void verifyCars(GameObject car){

        var carStatus = car.GetComponent<CarStatus>();

        carsStoped ++;

        if(carsStoped >= carSpawner.cars.Count){
            finishedTest = true;
        }
    }

    private void DestroyAllCars(){
        foreach (var car in carSpawner.cars)
        {
            Destroy(car);
        }
        carSpawner.cars = new List<GameObject>();

        
    }


}
