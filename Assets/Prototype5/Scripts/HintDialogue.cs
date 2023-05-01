using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HintDialogue : GameBehaviour
{
    public TMP_Text hintText;
    public bool hasSpoken;
    public bool hasStart;

    // Start is called before the first frame update
    void Start()
    {
        hintText.text = "Left click to shoot cannon orb\r\nRight hold to shoot smg orb";
        hasSpoken = false;
        hasStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_GM5.enemyCount > 0 && !hasSpoken && !hasStart)
        {
            hintText.text = "Left click to shoot cannon orb\r\nRight hold to shoot smg orb";
            hasStart = true;
        }

        if (_GM5.enemyCount <= 0 && !hasSpoken && hasStart)
        {
            hintText.text = "Go infront of the portal now!";
            hasSpoken=true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Heal") && _GM5.enemyCount <= 0)
        {
            hintText.text = "I'm coming home!";
            Debug.Log("im in");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Heal") && _GM5.enemyCount <= 0)
        {
            hintText.text = "Oh shidd, it's BIG BOI! We need to cure him!!";
            Debug.Log("im out");
        }
    }
}
