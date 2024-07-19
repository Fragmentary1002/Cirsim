using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEnd : MonoBehaviour
{
    private Vector3 depth;
    private Vector3 offset;
    public Rigidbody rd;

    

    void Start()
    {
        rd = GetComponent<Rigidbody>();
    }


    //  private void OnTriggerEnter(Collider other)
    // {
    //      if (other.gameObject.tag == "RedBall"||other.gameObject.tag == "BlueBall")
    //     {
    //         Debug.Log("到达一段终点"+other.gameObject.tag);
    //         Destroy(other.gameObject);
    //         // BallCnt++;
    //         // RedBallCnt++;
    //     }
    // }

    private void OnCollisionEnter(Collision collision)
    {
         if (collision.gameObject.tag == "RedBall"||collision.gameObject.tag == "BlueBall")
        {
            Debug.Log("到达一段终点"+collision.gameObject.tag);
            Destroy(collision.gameObject);
            // BallCnt++;
            // RedBallCnt++;
        }
    }
}
