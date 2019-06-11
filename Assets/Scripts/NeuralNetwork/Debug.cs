
using UnityEngine;

public class Debug : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var rede = new RedeNeural(2,3,1);
        var arr = new double[]{1,2};
        rede.feedFoward(arr);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
