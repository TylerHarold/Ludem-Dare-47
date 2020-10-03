using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    private UIManager ui;
    private InputManager input;

    private Text dText;

    private Queue<string> sentences;

    private void Start()
    {
        sentences = new Queue<string>();
        ui = FindObjectOfType<UIManager>();

        dText = GameObject.Find("dialogue_Text").GetComponent<Text>();
        input = FindObjectOfType<InputManager>();
    }

    public void StartDialogue(DialogueObj dialogue)
    {
        // Set input to Dialogue
        input.state = InputManager.GameState.DIALOGUE;

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
        if (input.state == InputManager.GameState.DIALOGUE)
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

        } else
        {
            ui.ToggleDialogue();
            return;
        }

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
