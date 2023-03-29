using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotMovement1 : GameBehaviour<PivotMovement1>
{
    Camera cam;
    Collider planeCollider;
    RaycastHit hit;
    Ray ray;
    public Rigidbody rb;

    public GameObject neckPivot; //position of the point you want to rotate around
    public GameObject mouthPivot; //position of the point you want to rotate around
    public GameObject fireCollider; 

    public float rotationSpeed = 20;
    public float mouthRotation;

    public int maxHealth = 10;
    public int currentHealth;
    public int bonusHeath;

    private void Start()
    {
        currentHealth = maxHealth + bonusHeath;
        _UI3.UpdateHeath(currentHealth);
        fireCollider.SetActive(false);

        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        planeCollider = GameObject.FindWithTag("Plane").GetComponent<Collider>();
    }

    void Update()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider == planeCollider)
            {
                rb.transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
            }
        }


        //if (Input.GetKey(KeyCode.Mouse0))
        //{
        //    neckPivot.transform.RotateAround(neckPivot.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
        //    //neckPivot.transform.RotateAround(neckPivot.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
        //}

        //if (Input.GetKey(KeyCode.Mouse1))
        //{
        //    neckPivot.transform.RotateAround(neckPivot.transform.position, -Vector3.up, rotationSpeed * Time.deltaTime);
        //    //neckPivot.transform.RotateAround(neckPivot.transform.position, -Vector3.up, rotationSpeed * Time.deltaTime);
        //}

        //float xAxisValue = Input.GetAxis("Vertical") * rotationSpeed;

        ////transform.position = new Vector3(transform.position.x + xAxisValue, transform.position.y, transform.position.z + zAxisValue);

        //mouthPivot.transform.position = new Vector3(Mathf.Clamp(transform.position.x + xAxisValue, 0, 90), transform.position.y, transform.position.z);


        if (Input.GetKey(KeyCode.Mouse0))
        {
            mouthPivot.transform.Rotate(-Vector3.left, rotationSpeed * Time.deltaTime);

            //mouthPivot.transform.RotateAround(neckPivot.transform.position, -Vector3.left, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            mouthPivot.transform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime);
            //mouthPivot.transform.RotateAround(neckPivot.transform.position, Vector3.left, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            fireCollider.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            fireCollider.SetActive(false);
        }

        mouthRotation = Input.GetAxis("Vertical") * rotationSpeed;
        mouthPivot.transform.Rotate(Mathf.Clamp(mouthRotation, 0, 90), 0, 0, Space.Self);
        //var eulerANgle = mouthPivot.transform.eulerAngles;
        //eulerANgle.y = Mathf.Clamp(mouthPivot.transform.eulerAngles.y, 0, 90);

    }

    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;
        _UI3.UpdateHeath(currentHealth);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
