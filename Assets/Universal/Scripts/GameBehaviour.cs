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
    protected static GameStateManager _GSM { get { return GameStateManager.Instance; } }

    //Prototype2
    protected static GameManager2 _GM2 { get { return GameManager2.Instance; } }
    protected static UIManager2 _UI2 { get { return UIManager2.Instance; } } 
    protected static RocketTree _RT { get { return RocketTree.Instance; } }

    //Prototype3
    protected static GameManager3 _GM3 { get { return GameManager3.Instance; } }
    protected static UIManager3 _UI3 { get { return UIManager3.Instance; } }
    protected static Dialogue _DI { get { return Dialogue.Instance; } }
    protected static CameraController3 _CM3 { get { return CameraController3.Instance; } }
    protected static PivotMovement1 _PM1 { get { return PivotMovement1.Instance; } }
    protected static FoodSpawner _FS { get { return FoodSpawner.Instance; } }

    //Prototype 4
    protected static GameManager4 _GM4 { get { return GameManager4.Instance; } }
    protected static UIManager4 _UI4 { get { return UIManager4.Instance; } }
    protected static MathScript _MS { get { return MathScript.Instance; } }

    //Prototype 5
    protected static GameManager5 _GM5 { get { return GameManager5.Instance; } }
    protected static UIManager5 _UI5 { get { return UIManager5.Instance; } }
    protected static FiringPoint _FP { get { return FiringPoint.Instance; } }



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