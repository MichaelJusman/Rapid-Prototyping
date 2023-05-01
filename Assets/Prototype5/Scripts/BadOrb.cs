using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadOrb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Ignoring collision on the enemy layer
        Physics.IgnoreLayerCollision(12, 2);
        Physics.IgnoreLayerCollision(12, 11);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
