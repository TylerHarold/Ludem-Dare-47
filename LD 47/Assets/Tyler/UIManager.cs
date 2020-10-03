using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Black Overlay (Used for transition between scenes)
    private Image global_Overlay;

    // Menu
    private Transform menu_ButtonsParent;
    private Button menu_PlayButton;
    private Button menu_OptionsButton;
    private Button menu_QuitButton;

    private Transform menu_RoomModel;
    private bool menuLoaded;

    // Dialogue
    private Image dialogue_Background;

    // Puzzles
    private GameObject puzzle_KeycodeParent;

    // Colors for alpha fade
    private Color a_zero;
    private Color a_full;


    private void Start()
    {
        // Menu
        menu_ButtonsParent = GameObject.Find("menu_ButtonsParent").transform;
        menu_PlayButton = menu_ButtonsParent.GetChild(0).GetComponent<Button>();
        menu_OptionsButton = menu_ButtonsParent.GetChild(1).GetComponent<Button>();
        menu_QuitButton = menu_ButtonsParent.GetChild(2).GetComponent<Button>();

        menu_RoomModel = GameObject.Find("menu_RoomModel").transform;
        menuLoaded = false;

        // Overlay
        global_Overlay = GameObject.Find("global_Overlay").GetComponent<Image>();

        // Dialogue
        dialogue_Background = GameObject.Find("dialogue_Background").GetComponent<Image>();

        // Puzzles
        puzzle_KeycodeParent = GameObject.Find("puzzle_KeycodeParent");

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
        LeanTween.move(menu_ButtonsParent.gameObject, new Vector3(200f, b_currentPosition.y, b_currentPosition.z), 1f).setEase(LeanTweenType.easeInQuad);

        // Move the model in
        Vector3 m_currentPosition = menu_RoomModel.position;
        LeanTween.move(menu_RoomModel.gameObject, new Vector3(m_currentPosition.x, -5f, m_currentPosition.z), 1f).setEase(LeanTweenType.easeInQuad);

        menuLoaded = true;
    }

    public void ToggleDialogue()
    {
        bool isOpen = (dialogue_Background.color.a != 0) ? true : false;
        if (isOpen) dialogue_Background.color = Color.Lerp(a_full, a_zero, Time.deltaTime * 1f);
        else dialogue_Background.color = Color.Lerp(a_zero, a_full, Time.deltaTime * 1f);
    }
}
