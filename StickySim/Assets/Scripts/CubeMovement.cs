using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{

    bool TileOrder = true;
    int level = 0;
    bool reset = false;
    float speed1 = 5, speed2 = -5;
    public GameObject FollowCam;
    public AudioSource Pling;
    void Start()
    {
        Debug.Log("Start");
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
        if (TileOrder == true && this.gameObject.CompareTag("Left") && transform.position.x >= -10)
        {
            Debug.Log("l");
            transform.position += new Vector3(speed1, 0, 0) * Time.deltaTime;
        } 

        if (TileOrder == false && this.gameObject.CompareTag("Right") && transform.position.z <= 10)
        {
            Debug.Log("r");
            transform.position += new Vector3(0, 0, speed2) * Time.deltaTime;
        }
    }

    private void TileStop()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(TileOrder);
            TileOrder = !TileOrder;
            Pling.Play();
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
        speed1 *= 1.025f;
        speed2 *= 1.025f;
    }
}
