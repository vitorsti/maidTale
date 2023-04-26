using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instace;

    public enum GameState { none,pause, play, interaction}
    public GameState _state;
    // Start is called before the first frame update
    void Awake()
    {
        instace = this;
        _state = GameState.play;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetState(GameState state)
    {
        _state = state;
    }

    public GameState GetState()
    {
        return _state;
    }
}
