using System;
using UnityEngine;

public class Debug : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var timeA = DateTime.Now;
        var rede = new RedeNeural(6,4,2);
        var arr = new double[]{1,2,3,4,5,6};
        rede.feedFoward(arr);
        var timeB = DateTime.Now;

        var time = timeB - timeA;
        UnityEngine.Debug.Log(time);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
