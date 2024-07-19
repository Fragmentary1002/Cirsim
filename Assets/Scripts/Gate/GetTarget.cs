using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTarget : MonoBehaviour
{   
    public Transform Target;
    // Start is called before the first frame update 
    void away(){
    //    Target = GetComponent<Transform>();
    }

    void Start()
    {
        GetComponent<GateCon>().target =Target;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
