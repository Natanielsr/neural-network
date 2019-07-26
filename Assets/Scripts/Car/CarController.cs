using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    float horizontal;
    float vertical;

    public CarBehaviour car; 
    // Start is called before the first frame update
    void Start()
    {
        car = GetComponent<CarBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        car.inputVertical = vertical;
        car.inputHorizontal = horizontal;
    }
}
