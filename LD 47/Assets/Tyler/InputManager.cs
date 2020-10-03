using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameState state;

    public enum GameState
    {
        UI,
        GAME,
        DIALOGUE,
        PAUSE,
        PUZZLE
    }


}
