using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaltGrab : GameBehaviour
{
    public float grabRadius = 0.5f;
    public float grabForce = 10f;
    public Transform handTransform;

    private GameObject heldObject;
    private bool isHoldingObject = false;

    private void FixedUpdate()
    {
        if (_GSM.gameState == GameState.Playing)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (isHoldingObject)
                {
                    ReleaseObject();
                }
                else
                {
                    GrabObject();
                }
            }

            if (isHoldingObject)
            {
                // Move held object to hand position
                heldObject.transform.position = handTransform.position;

                // Apply force to held object in direction of hand
                Vector3 grabDirection = (handTransform.position - heldObject.transform.position).normalized;
                heldObject.GetComponent<Rigidbody>().AddForce(grabDirection * grabForce, ForceMode.Acceleration);
            }
        }
    }

    private void GrabObject()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, grabRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Number1") || collider.CompareTag("Number2") || collider.CompareTag("Symbol"))
            {
                heldObject = collider.gameObject;
                heldObject.GetComponent<Rigidbody>().isKinematic = true;
                //heldObject.transform.SetParent(handTransform);
                isHoldingObject = true;
                break;
            }
        }
    }

    private void ReleaseObject()
    {
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        //heldObject.transform.SetParent(null);
        isHoldingObject = false;
        heldObject = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, grabRadius);
    }
}
