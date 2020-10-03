using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Menu
    private Transform menu_ButtonsParent;
    private Button menu_PlayButton;
    private Button menu_OptionsButton;
    private Button menu_QuitButton;




    public IEnumerator TakeToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        yield return new WaitForSeconds(1f);
    }

    public IEnumerator MenuLoad()
    {
        yield return new WaitForSeconds(1f);
    }
}
