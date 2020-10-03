using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycodeTrigger : MonoBehaviour
{
    public KeycodeObj keyObj;

    public void Init()
    {
        FindObjectOfType<PuzzleManager>().InitializeKeycode(keyObj);
    }
}
