using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerDoor : GameBehaviour
{
    public Animator anim;
    public GameObject warpPortal;
    public bool canWarp;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        canWarp = false;
        warpPortal.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (_GM5.enemyCount <= 0)
        {
            warpPortal.SetActive(true);
            Debug.Log("im on");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && _GM5.enemyCount <= 0)
        {
            
            anim.Play("DoorOpen");
        }
    }
}
