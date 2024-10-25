using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    [SerializeField] public string itemName;
    [SerializeField] private int quantity;
    [SerializeField] public Sprite sprite;
    [TextArea][SerializeField] public string itemDescription;

    [SerializeField] private GameObject visualCue;
    private bool playerInRange;

    private InventoryManager inventoryManager;
    
    void Awake() {
        inventoryManager = GameObject.Find("NotebookCanvas").GetComponent<InventoryManager>();
        visualCue.SetActive(false);
        playerInRange = false;
    }

    void Update() {
        if (playerInRange) {
            visualCue.SetActive(true);
            if (Input.GetButton("Interact")) {
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
