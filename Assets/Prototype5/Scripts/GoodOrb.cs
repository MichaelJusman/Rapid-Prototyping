using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodOrb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Ignoring collision on the enemy layer
        Physics.IgnoreLayerCollision(11, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
