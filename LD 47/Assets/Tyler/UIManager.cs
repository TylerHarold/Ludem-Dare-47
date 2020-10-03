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

    // Dialogue
    private Image dialogue_Background;

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

        // Overlay
        global_Overlay = GameObject.Find("global_Overlay").GetComponent<Image>();

        // Dialogue
        dialogue_Background = GameObject.Find("dialogue_Background").GetComponent<Image>();

        // Colors
        a_zero = new Color(0, 0, 0, 0);
        a_full = new Color(0, 0, 0, 255);
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
        Vector3 currentPosition = menu_ButtonsParent.position;
        Vector3 destinationPosition = new Vector3(currentPosition.x + 300, currentPosition.y, currentPosition.z);
        menu_ButtonsParent.position = Vector3.Lerp(currentPosition, destinationPosition, Time.deltaTime * 1f);
    }

    public void LoadDialogue()
    {
        bool isOpen = (dialogue_Background.color.a == 255) ? true : false;
        if (isOpen) dialogue_Background.color = Color.Lerp(a_full, a_zero, Time.deltaTime * 1f);
        else dialogue_Background.color = Color.Lerp(a_zero, a_full, Time.deltaTime * 1f);
    }
}
