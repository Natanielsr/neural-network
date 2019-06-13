using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasStation : MonoBehaviour
{
    // Start is called before the first frame update

    Guid GasStationId;

    void Start()
    {
        GasStationId = Guid.NewGuid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider col)
    {
        if(col.gameObject.tag == "car")
        {
            CarBehaviour carro = col.gameObject.GetComponent<CarBehaviour>();

            var gas = JaExisteGasolina(carro.GasUnitList);
            if(gas == null)
            {
                carro.AddFuel(new Gas(GasStationId, 10));
            }
            else{
                if( DateTime.Now > gas.finishDate){
                    carro.RemoveEmptyGas(gas);
                    carro.AddFuel(new Gas(GasStationId, 10));
                }
            }
        }

    }

    Gas JaExisteGasolina(List<Gas> gasCar){

        for (int i = 0; i < gasCar.Count; i++)
        {
            var gas = gasCar[i];
            if(gas.id == GasStationId)
            {
                return gas;
            }
        }

        return null;
    }

}
