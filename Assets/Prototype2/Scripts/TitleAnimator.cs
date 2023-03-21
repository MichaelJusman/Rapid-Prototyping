using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnimator : GameBehaviour
{
    Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Level1()
    {
        anim.Play("Level1");
    }

    public void Level2()
    {
        anim.Play("Level2");
    }

    public void Exit()
    {
        anim.Play("Exit");
    }
}
