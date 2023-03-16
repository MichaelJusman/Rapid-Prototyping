using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameBehaviour : MJ.Behaviour
{
    //Project Specific
    // protected static *ManagerName* *_MN* { get { return *ManagerName*.Instance; } }

    protected static UIManager _UI { get { return UIManager.Instance; } }
    protected static SceneController _SC { get { return SceneController.Instance; } }
    protected static PlayerMovement _PM { get { return PlayerMovement.Instance; } }
    protected static Timer _TIMER { get { return Timer.Instance; } }
    protected static GameManager _GM { get { return GameManager.Instance; } }
    protected static GameStateManager _GMS { get { return GameStateManager.Instance; } }

    //Prototype2
    protected static GameManager2 _GM2 { get { return GameManager2.Instance; } }
    protected static UIManager2 _UI2 { get { return UIManager2.Instance; } } 


    public enum GameState { Title, Instruction, Playing, Pause, GameOver }


}

//
// Instanced GameBehaviour
//
public class GameBehaviour<T> : GameBehaviour where T : GameBehaviour
{
    public bool dontDestroy;
    static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("GameBehaviour<" + typeof(T).ToString() + "> not instantiated!\nNeed to call Instantiate() from " + typeof(T).ToString() + "Awake().");
            return _instance;
        }
    }
    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            if (dontDestroy) DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    //
    // Instantiate singleton
    // Must be called first thing on Awake()
    protected bool Instantiate()
    {
        if (_instance != null)
        {
            Debug.LogWarning("Instance of GameBehaviour<" + typeof(T).ToString() + "> already exists! Destroying myself.\nIf you see this when a scene is LOADED from another one, ignore it.");
            DestroyImmediate(gameObject);
            return false;
        }
        _instance = this as T;
        return true;
    }
}