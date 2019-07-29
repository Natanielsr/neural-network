using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject carPrefab; 
    public int carCount = 10;
    public List<GameObject> cars = new List<GameObject>();
    // Start is called before the first frame update
    
    public void StartCarSpawner(){
        for (int i = 0; i < carCount; i++)
        {
            var car = Instantiate(carPrefab, transform.position, transform.rotation);
            var carStatus = car.GetComponent<CarStatus>();
            carStatus.idCar = cars.Count;

            cars.Add(car);

        }
    }

}
