using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{

    bool isStopped = false;
    void Start()
    {
        Debug.Log("Start");
        isStopped = false;
    }

    void Update()
    {
        tileMovement();
    }
     private void tileMovement()
    {
        if (this.gameObject.CompareTag("Left") && transform.position.x >= -5 && !isStopped)
        {
            transform.position += new Vector3(3, 0, 0) * Time.deltaTime;
            // Debug.Log(transform.position.x);
        }

        if (this.gameObject.CompareTag("Right") && transform.position.z <= 5 && !isStopped)
        {
            transform.position += new Vector3(0, 0, -3) * Time.deltaTime;
             Debug.Log(transform.position.z);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            // transform.position = this.transform.position;
            isStopped = true;
            // Debug.Log("Stop");
        }
    }
}
