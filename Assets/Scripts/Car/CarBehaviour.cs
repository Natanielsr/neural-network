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

    public List<Gas> GasUnitList;

    RaycastHit hit;
    public float rayDistance = 10f;

    public Transform[] rayTransforms;

    Vector3[] colisionsPoints;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        CurrentState = CarState.WORKING;
        currentGas = totalGas;
        GasUnitList = new List<Gas>();
        colisionsPoints = new Vector3[rayTransforms.Length];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(this.CurrentState == CarState.WORKING){

            moveCar();
            checkObstacles();
            consumeGas();
        }
    
    }

    void consumeGas(){
        if(currentGas <= 0)
        {
            finishGas();
            return;
        }

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

    public void AddFuel(Gas gas){
        this.GasUnitList.Add(gas);
        this.currentGas += gas.GasUnit;
    }

    public void RemoveEmptyGas(Gas gas){
        this.GasUnitList.Remove(gas);
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
        }
    }

}
