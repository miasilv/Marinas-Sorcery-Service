using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;


public class DialogueManager : MonoBehaviour {
    private TaskManager taskManager;
    private StoryManager storyManager;
    private PlayerManager player;

    [Header("Params")]
    [SerializeField] private float typingSpeed = 0.04f;
    
    [Header("Dialogue UI")]
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] TextMeshProUGUI displayNameText;
    [SerializeField] Animator portraitAnimator;
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
    private const string GIVE_TASK_TAG = "task";
    private const string FINISH_TASK_TAG = "taskComplete";
    private const string FINISH_DAY_TAG = "dayEnd";
    private const string ADD_DIALOGUE_TAG = "addDialogueIndex";

    void Start() {
        taskManager = GameObject.Find("NotebookCanvas").GetComponent<TaskManager>();
        storyManager = GameObject.FindWithTag("StoryManager").GetComponent<StoryManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
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

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                && canContinueToNextLine
                && currentStory.currentChoices.Count == 0) {
            ContinuePlaying();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON) {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        player.canMove = false;

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
            
            string nextLine = currentStory.Continue();
            displayLineCoroutine = StartCoroutine(DisplayLine(nextLine));
            
            // handle tags
            HandleTags(currentStory.currentTags);

            /* this fixes the end dialogue empty one
            // handle case where tag is the last line
            if (nextLine.Equals("") && !currentStory.canContinue) {
                ExitDialogueMode();
            }
            else {
                displayLineCoroutine = StartCoroutine(DisplayLine(nextLine));

                // handle tags
                HandleTags(currentStory.currentTags);
            }
            */
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
            if ((Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space)) && i > 3) {
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
        player.canMove = true;
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
                    portraitAnimator.Play(tagValue);
                    break;
                
                case LAYOUT_TAG:
                    layoutAnimator.Play(tagValue);
                    break;
                
                case GIVE_TASK_TAG:
                    string[] taskInfo = tagValue.Split("$");
                    if (taskInfo.Length != 3) {
                        Debug.Log("Task is formatted wrong");
                        break;
                    }
                    Debug.Log("Adding task " + taskInfo[0]);
                    storyManager.AddTask(taskInfo[0].Trim(), taskInfo[1].Trim(), taskInfo[2].Trim());
                    break;

                case FINISH_TASK_TAG:
                    storyManager.CompleteTask(int.Parse(tagValue));
                    break;

                case FINISH_DAY_TAG:
                    storyManager.NewDay();
                    break;
                
                case ADD_DIALOGUE_TAG:
                    storyManager.AddtoDialogueIndex(int.Parse(tagValue), 1);
                    break;
                
                default:
                    Debug.LogWarning("Tag came in but is not currently being handled: " + tag);
                    break;
            }
        }
    }
}
