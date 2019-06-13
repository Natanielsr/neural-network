using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CarState{
    WORKING = 0,
    BROKING = 1,
    NO_GAS = 2
}
public class CarBehaviour : MonoBehaviour
{
    Rigidbody rb;
    float speed;

    CarState CurrentState;
    public float accelerationPower = 100f;

    public float inputVertical = 0; 
    public float inputHorizontal = 0;
    public float steeringPower = 50f;

    public float totalGas = 100;
    float currentGas;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        CurrentState = CarState.WORKING;
        currentGas = totalGas;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(this.CurrentState == CarState.WORKING){
            //UnityEngine.Debug.Log("wORKING");
            if(currentGas <= 0)
            {
                finishGas();
              //  return;
            }

            moveCar();
            consumeGas();
        }
    
    }



    void consumeGas(){
        currentGas -= Time.deltaTime * 1;
    }

    void moveCar(){
        speed = inputVertical * accelerationPower;

        var angulo = new Vector3(0f,steeringPower*inputHorizontal,0f);
        var deltaRotation = Quaternion.Euler(angulo * Time.deltaTime);

        rb.MoveRotation(rb.rotation * deltaRotation);

        
        rb.AddRelativeForce(Vector3.forward * speed );
    }

    void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.tag == "obstacle")
        {
            brokeCar();
        }
    }

    void brokeCar(){
        this.CurrentState = CarState.BROKING;
    }

    void finishGas(){
        this.CurrentState = CarState.NO_GAS;
    }
}
