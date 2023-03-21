using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController2 : GameBehaviour
{
    public GameObject player;
    private Vector3 offset;
    public bool  isDocked;
    public float speed = 1;

    

    void Start()
    {
        

        offset = transform.position - player.transform.position;
        isDocked = true;
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isDocked = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = player.transform.position + offset;
        }

        if (isDocked)
        {
            float xAxisValue = Input.GetAxis("Horizontal") * speed;
            float zAxisValue = Input.GetAxis("Vertical") * speed;

            //transform.position = new Vector3(transform.position.x + xAxisValue, transform.position.y, transform.position.z + zAxisValue);

            transform.position = new Vector3(Mathf.Clamp(transform.position.x + xAxisValue, -400, 400), transform.position.y, Mathf.Clamp(transform.position.z + zAxisValue, -400, 400));
        }

        if (!isDocked)
        {
            transform.position = player.transform.position + offset;
        }

    }
}
