using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaltRaycast : GameBehaviour
{
    public float grabDistance = 10f;
    public float grabSpeed = 5f;
    public float interactionDistance = 2f;
    public LayerMask interactableLayer;
    public GameObject wandPoint;

    private GameObject heldObject;
    private bool isHoldingObject = false;
    private bool isGrabbing = false;

    private void Update()
    {
        // Toggle grabbing on/off
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isGrabbing = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            isGrabbing = false;
            if (isHoldingObject)
            {
                ReleaseObject();
            }
        }

        if (isGrabbing)
        {
            if (isHoldingObject)
            {
                // Move held object towards player hand
                Vector3 targetPosition = wandPoint.transform.position;
                //Vector3 targetPosition = transform.position + transform.forward * 0.5f;
                heldObject.transform.position = Vector3.Lerp(heldObject.transform.position, targetPosition, Time.deltaTime * grabSpeed);
            }
            else
            {
                // Attempt to grab an object
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, grabDistance, interactableLayer))
                {
                    if (hit.collider.CompareTag("Number1") || hit.collider.CompareTag("Number2") || hit.collider.CompareTag("Symbol"))
                    {
                        heldObject = hit.collider.gameObject;
                        heldObject.GetComponent<Rigidbody>().isKinematic = true;
                        isHoldingObject = true;
                    }
                }
            }
        }
        else if (isHoldingObject)
        {
            // Release held object if E is not being held
            ReleaseObject();
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, interactableLayer))
            {
                if (hit.collider.CompareTag("Deathball"))
                {
                    Button button = hit.collider.GetComponent<Button>();
                    if (button != null)
                    {
                        // Call the onClick function on the TMP button
                        button.onClick.Invoke();
                    }
                }
            }

            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //if (Physics.Raycast(ray, out hit))
            //{
            //    Button button = hit.collider.GetComponent<Button>();
            //    if (button != null)
            //    {
            //        // Call the onClick function on the TMP button
            //        button.onClick.Invoke();
            //    }
            //}
        }
    }

    private void ReleaseObject()
    {
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        isHoldingObject = false;
        heldObject = null;
    }

    private void HighlightObject()
    {

    }

    private void OnDrawGizmosSelected()
    {
        // Draw grab raycast in editor
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * grabDistance);
    }

    //(hit.collider.CompareTag("Number1") || hit.collider.CompareTag("Number2") || hit.collider.CompareTag("Symbol"))
}
