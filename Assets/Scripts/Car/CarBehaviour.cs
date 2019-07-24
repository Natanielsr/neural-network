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

    public CarState CurrentState;
    public float accelerationPower = 100f;

    public float inputVertical = 0; 
    public float inputHorizontal = 0;
    public float steeringPower = 50f;

    CarStatus status;

    

    RaycastHit hit;
    public float rayDistance = 10f;

    public Transform[] rayTransforms;

    public float[] distanceSensors;

    // Start is called before the first frame update
    void Start()
    {
        
        status = GetComponent<CarStatus>();
        status.EncheOTanqueMeuConsagrado();
        rb = GetComponent<Rigidbody>();
       
        
        distanceSensors = new float[rayTransforms.Length];
        CurrentState = CarState.WORKING;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(this.CurrentState == CarState.WORKING){

            moveCar();
            checkObstacles();
            var gas = status.consumeGas();
            if(gas <= 0)
                finishGas();
        }
    
    }

    

    void moveCar(){
        speed = inputVertical * accelerationPower;

        var angulo = new Vector3(0f,steeringPower*inputHorizontal,0f);
        var deltaRotation = Quaternion.Euler(angulo * Time.deltaTime);

        rb.MoveRotation(rb.rotation * deltaRotation);

        
        rb.AddRelativeForce(Vector3.forward * speed );
    }

    void OnTriggerEnter (Collider col)
    {
        //UnityEngine.Debug.Log("O carro bateu na parde");
        if(col.gameObject.tag == "obstacle")
        {
            rb.velocity = Vector3.zero;
            brokeCar();
            
        }
    }

    void brokeCar(){
        this.CurrentState = CarState.BROKING;
    }

    void finishGas(){
        this.CurrentState = CarState.NO_GAS;
    }


    void checkObstacles(){
       
        for (int i = 0; i < rayTransforms.Length; i++)
        {
            createRay(i);
        }
        
    }

    void createRay(int i){

        var rayTransform = rayTransforms[i];
        Vector3 forward = rayTransform.TransformDirection(Vector3.forward) * rayDistance;
        Ray ladingRay = new Ray(rayTransform.position, forward);
        UnityEngine.Debug.DrawRay(rayTransform.position, forward, Color.green);

        if(Physics.Raycast(ladingRay, out hit, rayDistance, 1 << 8)){

           // UnityEngine.Debug.Log("Detector "+i+" Ativou");
            UnityEngine.Debug.DrawRay(hit.point, forward, Color.red);
            float dist = Vector3.Distance(hit.point, rayTransform.position);
            distanceSensors[i] = dist;

        }
        else
           distanceSensors[i] = rayDistance; 
    }

}
