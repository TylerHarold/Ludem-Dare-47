using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // Where we'll put the dialogue object
    public DialogueObj dialogue;

    public void Init()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}
