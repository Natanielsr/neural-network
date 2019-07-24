using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStatus : MonoBehaviour
{
    public int carGasStationCatchs = 0;
    public List<Gas> GasUnitList;

    public float totalGas = 100;
    private float currentGas;

    void Start()
    {
       
        GasUnitList = new List<Gas>();
    }

    public void EncheOTanqueMeuConsagrado(){
        currentGas = totalGas;
    }
    

    public void getGasStation(){
        carGasStationCatchs++;
    }

    public void AddFuel(Gas gas){
        this.GasUnitList.Add(gas);
        this.currentGas += gas.GasUnit;
        getGasStation();
    }

    public float consumeGas(){
        
        currentGas = currentGas - Time.deltaTime * 1;
        UnityEngine.Debug.Log(currentGas+"carStatus");
        return currentGas;
    }
    
    public void RemoveEmptyGas(Gas gas){
        this.GasUnitList.Remove(gas);
    }
}
