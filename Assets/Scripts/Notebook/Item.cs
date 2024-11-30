using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    [SerializeField] public string itemName;
    [SerializeField] private int quantity;
    [SerializeField] public Sprite sprite;
    [SerializeField] public AudioClip soundWhenPicked;
    [TextArea][SerializeField] public string itemDescription;

    [SerializeField] private GameObject visualCue;
    private bool playerInRange;

    private InventoryManager inventoryManager;
    private AudioManager audioManager;
    
    void Awake() {
        inventoryManager = GameObject.Find("NotebookCanvas").GetComponent<InventoryManager>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        visualCue.SetActive(false);
        playerInRange = false;
    }

    void Update() {
        if (playerInRange) {
            visualCue.SetActive(true);
            if (Input.GetButton("Interact")) {
                audioManager.PlayPickUpItem(soundWhenPicked);
                int leftOverItems = inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
                if (leftOverItems <= 0) {
                    Destroy(gameObject);
                } else {
                    quantity = leftOverItems;
                }
            }
        }
        else {
            visualCue.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D col) {
         if (col.gameObject.tag == "Player") {
            playerInRange = false;
        }
    }
}
