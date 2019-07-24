using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject carPrefab; 
    public int carCount = 10;
    public List<GameObject> cars = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < carCount; i++)
        {
            var car = Instantiate(carPrefab, transform.position, transform.rotation);
            cars.Add(car);

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
