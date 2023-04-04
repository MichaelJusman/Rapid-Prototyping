using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController3 : GameBehaviour<CameraController3>
{
    public Animator anim;
    public GameObject player;

    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGameAnimation()
    {
        anim.SetTrigger("Start");
    }

    public void ChangeGameState()
    {
        _DI.OnDialogueEnd();
    }
}
