using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{
     public float seconds=3;
    // Start is called before the first frame update
    void Start()
    {
      Destroy(gameObject,seconds);
     
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
