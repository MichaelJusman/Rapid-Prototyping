using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Playtime : GameBehaviour
{
    public enum Direction { Up, Down, Left, Right}

    public GameObject player;
    public float tweenTime = 2f;
    public float moveDistance = 5f;
    public Ease moveEase;
    public Ease scaleEase;

    // Start is called before the first frame update
    void Start()
    {
        //ExecuteAfterSeconds(2, () => ScaleToZero(player));

        //ExecuteAfterSeconds(2, () =>
        //{
        //    ChangePlayerColour();
        //    print("woo hoo");
        //});
        
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.Space))
    //    {
    //        ChangePlayerColour();
    //    }

    //    if (Input.GetKeyDown(KeyCode.D))
    //        MovePlayer(Direction.Right);
    //    if (Input.GetKeyDown(KeyCode.A))
    //        MovePlayer(Direction.Left);
    //    if (Input.GetKeyDown(KeyCode.W))
    //        MovePlayer(Direction.Up);
    //    if (Input.GetKeyDown(KeyCode.S))
    //        MovePlayer(Direction.Down);
    //    if (Input.GetKeyDown(KeyCode.R))
    //        ScalePlayer(Vector3.one);
    //}

    //void MovePlayer(Direction _direction)
    //{
    //    switch(_direction)
    //    {
    //        case Direction.Right:
    //            player.transform.DOMoveX(player.transform.position.x + moveDistance, tweenTime).SetEase(moveEase).OnComplete(() => ShakeCamera());
    //            break;
    //        case Direction.Left:
    //            player.transform.DOMoveX(player.transform.position.x - moveDistance, tweenTime).SetEase(moveEase).OnComplete(() => ShakeCamera());
    //            break;
    //        case Direction.Up:
    //            player.transform.DOMoveZ(player.transform.position.z + moveDistance, tweenTime).SetEase(moveEase).OnComplete(() => ShakeCamera());
    //            break;
    //        case Direction.Down:
    //            player.transform.DOMoveZ(player.transform.position.z - moveDistance, tweenTime).SetEase(moveEase).OnComplete(() => ShakeCamera());
    //            break;

    //    }
    //    ScalePlayer(player.transform.localScale * 2);
    //}

    void ScalePlayer(Vector3 _scaleTo)
    {
        player.transform.DOScale(_scaleTo, tweenTime).SetEase(scaleEase);
    }
    void ChangePlayerColour()
    {
        //player.GetComponent<Renderer>().material.color = GetRandomColour();
        player.GetComponent<Renderer>().material.DOColor(GetRandomColour(), 0.5f);
    }

    //void ShakeCamera()
    //{
    //    Camera.main.DOShakePosition(tweenTime/2, 1.2f);
    //    _UI.TweenScore();
    //}

}
