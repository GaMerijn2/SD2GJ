using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class CubeMovement : MonoBehaviour
{
    public static CubeMovement LastTile { get; private set; }
    [SerializeField]


    bool isStopped = false;
    bool TileOrder = true;
    public float level = 0;
    bool reset = false;
    float speed1 = 5, speed2 = -5;
    public GameObject FollowCam;
    public GameObject decoyTile;
    private Vector3 LeftStartpos;
    private Vector3 RightStartpos;
    int side;
    public ParticleSystem Particle;
    public AudioSource Pling;

    


    void Start()
    {
        side = 0;
        Debug.Log("Start");
        isStopped = false;
        transform.localScale = new Vector3(5, 0.5f, 5);
    }

    void Update()
    {
        TileMovement();
        TileStop();
        CameraMovement();
    }

     private void TileMovement()
    {
        switch (side)
        {
            case 1:
                transform.position += new Vector3(speed1, 0, 0) * Time.deltaTime;
                break;
            case 0:
                transform.position += new Vector3(0, 0, speed2) * Time.deltaTime;
                break;
        }
    }

    private void TileStop()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            placeTile();
            TileOrder = !TileOrder;
            reset = true;
            level += (0.5f);
            tileReset();
            Particle.Play();
            Pling.Play();

        }
    }

    private void tileReset()
    {
        
        switch (side)
        {
            case 0:
                this.transform.position = new Vector3(-10, level, 0);
                side = 1;

                break;
            case 1:
                this.transform.position = new Vector3(0, level, 10);
                side = 0;
                break;
        }
        speed1 *= 1.035f;
        speed2 *= 1.035f;
    }


    void placeTile()
    {
        var tileClone = Instantiate(decoyTile);
        tileClone.transform.position = new Vector3(transform.position.x, level, transform.position.z);
    }

    void CameraMovement()
    {
        FollowCam.transform.position = Vector3.Lerp(FollowCam.transform.position, new Vector3(0, level, 0), Time.deltaTime * 1f);
    }
}
