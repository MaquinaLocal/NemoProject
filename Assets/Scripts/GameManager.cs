using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }
    private States states;
    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        else Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void UpdateStates(States newState)
    {
        switch(newState)
        {
            case States.Playing:
                break;
            case States.GameOver:
                Debug.Log("Perdiste");
                break;
            case States.GameWin:
                Debug.Log("Ganaste");
                break;
            default:
                break;     
        }
    }
}

public enum States
{
    Playing,
    GameOver,
    GameWin
}

