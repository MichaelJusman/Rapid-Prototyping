using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Homing : MonoBehaviour
{
    public GameObject target;
    public float homingSpeed = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.transform.position;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * homingSpeed);
    }
}
