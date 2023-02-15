using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playtime : GameBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        ExecuteAfterSeconds(2, () => ScaleToZero(player));

        ExecuteAfterSeconds(2, () =>
        {
            ChangePlayerColour();
            print("woo hoo");

            
        });
        
        ScaleToZero(player);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ChangePlayerColour();
        }
    }

    void ChangePlayerColour()
    {
        player.GetComponent<Renderer>().material.color = GetRandomColour();
    }
}
