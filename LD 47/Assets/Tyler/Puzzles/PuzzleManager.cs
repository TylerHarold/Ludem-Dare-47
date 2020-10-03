using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{

    // Input Manager
    private InputManager input;
    private UIManager ui;

    // Keycode
    private GameObject keycode_Parent;
    private GameObject keycode_ButtonsParent;
    private Text keycode_Text;

    private void Start()
    {
        input = FindObjectOfType<InputManager>();
        ui = FindObjectOfType<UIManager>();
    }

    public void InitializeKeycode(KeycodeObj keycodeObj)
    {
        // Set game state to puzzle
        input.state = InputManager.GameState.PUZZLE;

        // Toggle Keycode UI
        ui.ToggleKeycodePuzzle();

    }

    // This function will be added to each number button with their corresponding number
    public void KeycodeAddNumber(int number)
    {
        // Numbers will be converted from int to string
        // I think it'll be better to add, remove and check as a string than an int?
        if (keycode_Text.text.Length < 5) keycode_Text.text += number.ToString();
    }

    public bool KeycodeCheckCode(KeycodeObj keycodeObj)
    {
        // Function placed on button click
        if (keycode_Text.text == keycodeObj.keycode.ToString()) return true;
        else return false;
    }

    public void KeycodeClear()
    {
        // Check if the object is active first, then clear the text
        if (keycode_Text.gameObject.activeSelf) keycode_Text.text = "";
    }
}
