using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {
    [SerializeField] private GameObject visualCue;
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;

    private void Awake() {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update() {
        if (playerInRange) {
            visualCue.SetActive(true);
            if (Input.GetButtonDown("Interact"))  {
                Debug.Log(inkJSON);
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
