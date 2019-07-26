using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasStationController : MonoBehaviour
{
    public GasStation[] gasStations;
    // Start is called before the first frame update
    void Start()
    {
        gasStations = FindObjectsOfType<GasStation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
