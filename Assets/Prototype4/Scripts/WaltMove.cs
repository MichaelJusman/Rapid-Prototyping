using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaltMove : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 3f;
    public float grabDistance = 2f;

    public Transform handTransform;

    private Rigidbody rb;
    private GameObject heldObject;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * vertical + transform.right * horizontal;
        movement = Vector3.ClampMagnitude(movement, 1f) * movementSpeed;

        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);

        // Rotation
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 rotation = transform.localEulerAngles;
        rotation.y += mouseX * rotationSpeed;
        rotation.x -= mouseY * rotationSpeed;

        transform.localEulerAngles = rotation;

        // Grabbing objects
        if (Input.GetKey(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(handTransform.position, handTransform.forward, out hit, grabDistance))
            {
                GameObject obj = hit.collider.gameObject;
                if (obj.CompareTag("NumberCube") || obj.CompareTag("SymbolCylinder"))
                {
                    heldObject = obj;
                    heldObject.GetComponent<Rigidbody>().isKinematic = true;
                    heldObject.transform.SetParent(handTransform);
                }
            }
        }

        // Releasing objects
        if (Input.GetKeyUp(KeyCode.E) && heldObject != null)
        {
            heldObject.GetComponent<Rigidbody>().isKinematic = false;
            heldObject.transform.SetParent(null);
            heldObject = null;
        }
    }
}
