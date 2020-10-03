using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private GameState state;

    private UIManager UI;
    private GameInput game;
    private Dialogue dialogue;
    private Pause pause;


    public enum GameState
    {
        UI,
        GAME,
        DIALOGUE,
        PAUSE
    }

    private void Update()
    {
        switch(state)
        {
            case GameState.UI:
                // UIManager.Initiate();
                break;
            case GameState.GAME:
                // Game.Initiate();
                break;
            case GameState.DIALOGUE:
                // Dialogue.Initiate();
                break;
            case GameState.PAUSE:
                // Pause.Initiate();
                break;
        }
    }


}
