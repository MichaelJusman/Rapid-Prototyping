using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaltRaycast : GameBehaviour
{
    public float grabDistance = 2f;
    public float grabSpeed = 5f;
    public float interactionDistance = 2f;

    private GameObject heldObject;
    private bool isHoldingObject = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isHoldingObject)
            {
                ReleaseObject();
            }
            else
            {
                GameObject interactableObject = GetInteractableObject();
                if (interactableObject != null)
                {
                    InteractWithObject(interactableObject);
                }
                else
                {
                    GrabObject();
                }
            }
        }

        if (isHoldingObject)
        {
            // Move held object towards player hand
            Vector3 targetPosition = transform.position + transform.forward * 0.5f;
            heldObject.transform.position = Vector3.Lerp(heldObject.transform.position, targetPosition, Time.deltaTime * grabSpeed);
        }
    }

    private void GrabObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, grabDistance))
        {
            if (hit.collider.CompareTag("Number1") || hit.collider.CompareTag("Number2") || hit.collider.CompareTag("Symbol"))
            {
                heldObject = hit.collider.gameObject;
                heldObject.GetComponent<Rigidbody>().isKinematic = true;
                isHoldingObject = true;
            }
        }
    }

    private void ReleaseObject()
    {
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        isHoldingObject = false;
        heldObject = null;
    }

    private GameObject GetInteractableObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance))
        {
            return hit.collider.gameObject;
        }
        return null;
    }

    private void InteractWithObject(GameObject interactableObject)
    {
        // Add code to interact with object
    }
}
