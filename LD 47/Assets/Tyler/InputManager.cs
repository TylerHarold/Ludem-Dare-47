using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameState state;

    private UIManager UI;
    private GameInput game;
    private DialogueManager dialogue;
    private Pause pause;
    private PuzzleManager puzzle;


    public enum GameState
    {
        UI,
        GAME,
        DIALOGUE,
        PAUSE,
        PUZZLE
    }


}
