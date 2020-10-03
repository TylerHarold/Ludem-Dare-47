using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private InputManager input;
    private PlayerMovement player;

    private void Start()
    {
        input = FindObjectOfType<InputManager>();
        player = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        if (input.state == InputManager.GameState.PAUSE)
        {
            player.moveSpeed = 0;
        }
    }
}
