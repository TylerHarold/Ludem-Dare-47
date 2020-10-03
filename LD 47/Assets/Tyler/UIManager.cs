using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    // Input Manager
    private InputManager input;

    // Black Overlay (Used for transition between scenes)
    private Image global_Overlay;

    // Menu
    private Transform menu_ButtonsParent;
    private Button menu_PlayButton;
    private Button menu_OptionsButton;
    private Button menu_QuitButton;

    private Transform menu_Logo;

    private Transform menu_RoomModel;
    private bool menuLoaded;

    // Dialogue
    private Image dialogue_Background;

    // Pause Menu
    private GameObject pause_Menu;

    // Puzzles
    private GameObject keycode_Parent;
    private GameObject keycode_ButtonsParent;
    private Text keycode_Text;

    // Colors for alpha fade
    private Color a_zero;
    private Color a_full;


    private void Start()
    {
        // Input Manager
        input = FindObjectOfType<InputManager>();

        // Menu
        menu_ButtonsParent = GameObject.Find("menu_ButtonsParent").transform;
        menu_PlayButton = menu_ButtonsParent.GetChild(0).GetComponent<Button>();
        menu_OptionsButton = menu_ButtonsParent.GetChild(1).GetComponent<Button>();
        menu_QuitButton = menu_ButtonsParent.GetChild(2).GetComponent<Button>();

        menu_Logo = GameObject.Find("Logo").transform;

        menu_RoomModel = GameObject.Find("menu_RoomModel").transform;
        menuLoaded = false;

        // Overlay
        global_Overlay = GameObject.Find("global_Overlay").GetComponent<Image>();

        // Pause Menu
        pause_Menu = GameObject.Find("pause_Menu");

        // Dialogue
        dialogue_Background = GameObject.Find("dialogue_Background").GetComponent<Image>();

        // Keycode
        keycode_Parent = GameObject.Find("keycode_Parent");

        // Colors
        a_zero = new Color(0, 0, 0, 0);
        a_full = new Color(0, 0, 0, 255);

        // Init Menu
        LoadMenu();
    }

    private void Update()
    {
        if (menuLoaded)
        {
            // Rotate the room model on the X axis
            menu_RoomModel.transform.Rotate(0, 2f * Time.deltaTime, 0);
        }

        // Toggle Pause
        if (input.state == InputManager.GameState.GAME)
        {
            if (Input.GetKeyDown(KeyCode.Escape)) TogglePause();
        }

    }

    public IEnumerator TakeToScene(string sceneName)
    {
        // Lower opacity to 0 (Black Screen) -> Load Scene -> Up opacity back to 100
        // To prevent anything ugly from being shown

        global_Overlay.color = Color.Lerp(a_zero, a_full, Time.deltaTime * 1f);
        yield return SceneManager.LoadSceneAsync(sceneName);
        global_Overlay.color = Color.Lerp(a_full, a_zero, Time.deltaTime * 1f);
    }

    public void LoadMenu()
    {
        // Move the buttons in
        Vector3 b_currentPosition = menu_ButtonsParent.position;
        LeanTween.move(menu_ButtonsParent.gameObject, new Vector3(200f, b_currentPosition.y, b_currentPosition.z), 0.3f).setEase(LeanTweenType.easeInQuad);

        // Move the model in
        Vector3 m_currentPosition = menu_RoomModel.position;
        LeanTween.move(menu_RoomModel.gameObject, new Vector3(m_currentPosition.x, -4f, m_currentPosition.z), 0.5f).setEase(LeanTweenType.easeInQuad);

        // Move the logo in
        Vector3 l_currentPosition = menu_Logo.position;
        LeanTween.move(menu_Logo.gameObject, new Vector3(350f, l_currentPosition.y, l_currentPosition.z), 0.7f).setEase(LeanTweenType.easeInQuad);

        menuLoaded = true;
    }

    public void ToggleDialogue()
    {
        bool isOpen = (dialogue_Background.color.a != 0) ? true : false;
        if (isOpen) LeanTween.alpha(dialogue_Background.gameObject, 1f, 0.3f).setEase(LeanTweenType.easeOutQuad);
        else LeanTween.alpha(dialogue_Background.gameObject, 1f, 0.3f).setEase(LeanTweenType.easeOutQuad); ;
    }

    public void TogglePause()
    {
        if (!pause_Menu.activeSelf)
        {
            // Set the pause menu game object to active
            pause_Menu.SetActive(true);
            // While the object is active, we are going to set the game state to pause, then
            // make sure that the player is unable to move
            input.state = InputManager.GameState.PAUSE;
        }
        else
        {
            pause_Menu.SetActive(false);
        }
    }

    public void ToggleKeycodePuzzle()
    {
        // No need to check for input state here
        if (!keycode_Parent.activeSelf) keycode_Parent.SetActive(true);
        else keycode_Parent.SetActive(false);
    }


}
