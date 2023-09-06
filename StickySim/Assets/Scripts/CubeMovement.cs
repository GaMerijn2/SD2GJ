using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{

    bool isStopped = false;
    bool TileOrder = true;
    int level = 0;
    bool reset = false;
    public GameObject FollowCam;
    void Start()
    {
        Debug.Log("Start");
        isStopped = false;
        if (this.CompareTag("Left")) 
        {
            transform.position = new Vector3(-10, 0);
        }
        if (this.CompareTag("Right"))
        {
            transform.position = new Vector3(0, 0, 10);
        }

    }

    void Update()
    {
        TileMovement();
        TileStop();
    }

     private void TileMovement()
    {
        if (TileOrder == true && this.gameObject.CompareTag("Left") && transform.position.x >= -10 /* && !isStopped*/)
        {
            Debug.Log("l");
            transform.position += new Vector3(5, 0, 0) * Time.deltaTime;
        } 

        if (TileOrder == false && this.gameObject.CompareTag("Right") && transform.position.z <= 10 /* && !isStopped*/)
        {
            Debug.Log("r");
            transform.position += new Vector3(0, 0, -5) * Time.deltaTime;
        }
    }

    private void TileStop()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(TileOrder);
            isStopped = true;
            TileOrder = !TileOrder;
            reset = true;
            level++;
            tileReset();    
        }
    }

    private void tileReset()
    {
        if (this.gameObject.CompareTag("Left"))
        {
            this.transform.position = new Vector3(-10, level);
            FollowCam.transform.position = new Vector3(0, level, 0);
        }

        if (this.gameObject.CompareTag("Right"))
        {
            this.transform.position = new Vector3(0, level, 10);
            FollowCam.transform.position = new Vector3(0, level, 0);
        }

    }
}
