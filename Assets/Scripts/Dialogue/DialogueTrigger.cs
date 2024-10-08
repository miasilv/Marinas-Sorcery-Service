using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {
    [SerializeField] private GameObject visualCue;
    [SerializeField] private TextAsset inkJSON;

    private DialogueManager dialogueManager;

    public bool playerInRange;

    private void Awake() {
        playerInRange = false;
        visualCue.SetActive(false);

        dialogueManager = GameObject.Find("DialogueCanvas").GetComponent<DialogueManager>();
    }

    private void Update() {
        if (playerInRange && !dialogueManager.dialogueIsPlaying) {
            visualCue.SetActive(true);
            if (Input.GetButtonDown("Interact"))  {
                dialogueManager.EnterDialogueMode(inkJSON);
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
