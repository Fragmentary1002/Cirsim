using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rd;


    void Start()
    {
        rd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
 //       transform.Translate(Vector3.right*Time.deltaTime,Space.Self); 自动向前移动
    }
}
