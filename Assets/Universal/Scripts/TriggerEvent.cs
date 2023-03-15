using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public UnityEvent OnTriggerEnterEvent;
    public UnityEvent OnTriggerStayEvent;
    public UnityEvent OnTriggerExitEvent;

    public string[] triggerTag;


    
    public void OnTriggerEnter(Collider other)
    {
        if (GetComponent<Collider>() == null)
            return;

        if (triggerTag.Length == 0)
        { 
            OnTriggerEnterEvent.Invoke(); 
        }

        else
        {
            for (int i = 0; i < triggerTag.Length; i++)
            {
                if (other.CompareTag(triggerTag[1]) || triggerTag.Length == 0)
                    OnTriggerEnterEvent.Invoke();
            }
        }


            

    }
    public void OnTriggerStay(Collider other)
    {
        if (GetComponent<Collider>() == null)
            return;

        if (triggerTag.Length == 0)
        {
            OnTriggerStayEvent.Invoke();
        }

        else
        {
            for (int i = 0; i < triggerTag.Length; i++)
            {
                if (other.CompareTag(triggerTag[1]) || triggerTag.Length == 0)
                    OnTriggerStayEvent.Invoke();
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (GetComponent<Collider>() == null)
            return;

        if (triggerTag.Length == 0)
        {
            OnTriggerExitEvent.Invoke();
        }

        else
        {
            for (int i = 0; i < triggerTag.Length; i++)
            {
                if (other.CompareTag(triggerTag[1]) || triggerTag.Length == 0)
                    OnTriggerExitEvent.Invoke();
            }
        }
    }
}
