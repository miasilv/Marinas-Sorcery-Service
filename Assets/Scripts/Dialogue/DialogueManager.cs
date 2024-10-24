using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;


public class DialogueManager : MonoBehaviour {
    [Header("Params")]
    [SerializeField] private float typingSpeed = 0.04f;
    
    [Header("Dialogue UI")]
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] TextMeshProUGUI displayNameText;
    private Animator layoutAnimator;
    [SerializeField] GameObject continueIcon;
    private Story currentStory;
    public bool dialogueIsPlaying {get; private set;}
    private Coroutine displayLineCoroutine;
    private bool canContinueToNextLine = false;

    [Header("Choices UI")]
    [SerializeField] GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string LAYOUT_TAG = "layout";

    void Start() {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        layoutAnimator = dialoguePanel.GetComponent<Animator>();

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices) {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    void Update() {
        if (!dialogueIsPlaying) {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) 
                && canContinueToNextLine
                && currentStory.currentChoices.Count == 0) {
            ContinuePlaying();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON) {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        // stop player movement

        displayNameText.text = "???";
        layoutAnimator.Play("right");

        ContinuePlaying();
    }

    public void ContinuePlaying() {
         if (currentStory.canContinue) {
            // set text for the current dialogue line
            if (displayLineCoroutine != null) {
                StopCoroutine(displayLineCoroutine);
            }
            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));

            // handle tags
            HandleTags(currentStory.currentTags);

        }
        else {
            ExitDialogueMode();
        }
    }

    private IEnumerator DisplayLine(string line) {
        //empty the dialogue text
        dialogueText.text = "";

        // hide items while text is typing
        continueIcon.SetActive(false);
        HideChoices();

        canContinueToNextLine = false;

        // display each letter one at a time
        int i = 0;
        foreach (char letter in line.ToCharArray()) {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);

            // finish writing the line right away
            if (Input.GetKey(KeyCode.Space) && i > 3) {
                dialogueText.text = line;
                break;
            }
            i++;
        }
        // display choices, if any, for this dialogue line
        DisplayChoices();
    }

    private void ExitDialogueMode() {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        // start player movement
    }

    private void DisplayChoices() {
        List<Choice> currentChoices = currentStory.currentChoices;
        
        // checking if there are 3 or less choices
        if (currentChoices.Count > choices.Length) {
            Debug.LogError("More choices were given than the current UI can support.");
        }
        else if (currentChoices.Count <= 0) {
            continueIcon.SetActive(true);
            canContinueToNextLine = true;
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
        continueIcon.SetActive(false);
        canContinueToNextLine = false;
    }

    public void HideChoices() {
        foreach (GameObject choiceButton in choices) {
            choiceButton.SetActive(false);
        }
    }

    public void MakeChoice(int choiceIndex) {
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinuePlaying();
    }

    public void HandleTags(List<string> currentTags) {
        foreach (string tag in currentTags) {
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2) {
                Debug.LogError("Tag could not be appropriately parsed: " + tag);  
            }

            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey) {
                case SPEAKER_TAG:
                    displayNameText.text = tagValue;
                    break;
                case PORTRAIT_TAG:
                    Debug.Log("portrait = " + tagValue);
                    break;
                case LAYOUT_TAG:
                    layoutAnimator.Play(tagValue);
                    break;
                default:
                    Debug.LogWarning("Tag came in but is not currently being handled: " + tag);
                    break;
            }
        }
    }
}
