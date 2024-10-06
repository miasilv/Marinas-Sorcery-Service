using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;


public class DialogueManager : MonoBehaviour {
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] GameObject continueIcon;
    private Story currentStory;
    public bool dialogueIsPlaying {get; private set;}
    [SerializeField] GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    void Start() {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices) {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    void Update() {
        if (dialogueIsPlaying && Input.GetKeyDown(KeyCode.Space)) {
            ContinuePlaying();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON) {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        Time.timeScale = 0;

        ContinuePlaying();
    }

    public void ContinuePlaying() {
         if (currentStory.canContinue) {
            // set text for current dialogue line
            dialogueText.text = currentStory.Continue();

            // display choices, if any, for this dialogue line
            DisplayChoices();

        }
        else {
            ExitDialogueMode();
        }
    }

    private void ExitDialogueMode() {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        Time.timeScale = 1;
    }

    private void DisplayChoices() {
        List<Choice> currentChoices = currentStory.currentChoices;
        
        // checking if there are 3 or less choices
        if (currentChoices.Count > choices.Length) {
            Debug.LogError("More choices were given than the current UI can support.");
        }
        else if (currentChoices.Count < 0) {
            continueIcon.SetActive(true);
            return;
        }

        int index = 0;
        // enable and initialize the choices for current line of dialogue
        foreach (Choice choice in currentChoices) {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        // go through remaining choices and make sure they're hidden
        for (int i = index; i < choices.Length; i++) {
            choices[i].gameObject.SetActive(false);
        }

        continueIcon.SetActive(true);



    }

    public void MakeChoice(int choiceIndex) {
        currentStory.ChooseChoiceIndex(choiceIndex);
    }
}
