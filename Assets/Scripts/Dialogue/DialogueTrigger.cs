using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {
    [SerializeField] private GameObject visualCue;
    [SerializeField] private TextAsset[] inkJSON;
    public int dialogueIndex;
    public int characterIndex;
    public bool waitingForPotion;
    public bool hasPotion;

    private DialogueManager dialogueManager;

    public bool playerInRange;

    private void Awake() {
        playerInRange = false;
        visualCue.SetActive(false);
        waitingForPotion = false;
        dialogueIndex = 0;

        dialogueManager = GameObject.Find("DialogueCanvas").GetComponent<DialogueManager>();
    }

    private void Update() {
        if (playerInRange && !dialogueManager.dialogueIsPlaying) {
            visualCue.SetActive(true);

            if (Input.GetButtonDown("Interact"))  {
                // if character is currently waiting for a potion, and the player has the potion, add one to dialogueIndex
                // if character is currently waiting for a potion, the player had the potion, but doesn't anymore, remove one from dialogue index
                if (waitingForPotion) {
                    if (!hasPotion && gameManager.CheckPotion(characterIndex)) {
                        dialogueIndex++;
                        hasPotion = true;
                    } else if (hasPotion && !gameManager.CheckPotion(characterIndex)) {
                        dialogueIndex--;
                        hasPotion = false;
                    }
                }

                dialogueManager.EnterDialogueMode(inkJSON[dialogueIndex]);
            }
        }
        else {
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            playerInRange = false;
        }
    }
}
