using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : GameBehaviour<PlayerMovement>
{
    public Rigidbody rb;
    public float speed = 5f;
    private GameObject focalPoint;

    public void Start()
    {
        focalPoint = GameObject.Find("FocalPoint");
    }

    //void Update()
    //{
    //    RaycastHit mousePosition = Input.mousePosition;


    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        RaycastHit info;
    //        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out info))
    //        {
    //            //info.point;  <<=== the Vector u are searc$$anonymous$$ng for
    //        }
    //    }
    //}

    void FixedUpdate()
    {
        //Add force to our rigidbody from our movement vector times our speed
        rb.velocity = transform.forward * speed;
    }

   

}

