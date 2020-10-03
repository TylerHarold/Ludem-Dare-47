using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    private UIManager ui;

    public Text dText;

    private Queue<string> sentences;

    private void Start()
    {
        sentences = new Queue<string>();
        ui = FindObjectOfType<UIManager>();
    }

    public void StartDialogue(DialogueObj dialogue)
    {
        // Toggle the background
        ui.ToggleDialogue();

        // Clear any pre-existing message
        sentences.Clear();

        foreach (string sentence in dialogue.message)
        {
            sentences.Enqueue(sentence);
        }

        // Display next
        DisplaySentence();
    }

    public void DisplaySentence()
    {
        if (sentences.Count == 0)
        {
            // Toggle the dialogue
            ui.ToggleDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public IEnumerator TypeSentence(string sentence)
    {
        dText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dText.text += letter;
            yield return null;
        }
    }
}
