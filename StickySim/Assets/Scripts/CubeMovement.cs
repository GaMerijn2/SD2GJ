using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    Vector3 posY;
    bool isStopped = false;
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Debug.Log("Start");
        isStopped = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= -5 && !isStopped)
        {
            transform.position += new Vector3(3, 0, 0) * Time.deltaTime;
           // Debug.Log(transform.position.x);
        }

        else if (transform.position.z >= 5 && !isStopped)
        {
            transform.position += new Vector3(0, 0, -3) * Time.deltaTime;
           // Debug.Log(transform.position.z);
        }

        if (Input.GetKey(KeyCode.Space))
        {
           // transform.position = this.transform.position;
           isStopped = true;
            Debug.Log("Stop");
        }

    }
}
