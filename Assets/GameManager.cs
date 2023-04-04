using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameManager instace;

    public enum GameState { pause, play,  }
    // Start is called before the first frame update
    void Start()
    {
       GameManager instace = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
