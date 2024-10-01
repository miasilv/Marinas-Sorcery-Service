using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    [SerializeField] private string itemName;
    [SerializeField] private int quantity;
    [SerializeField] private Sprite sprite;
    [TextArea][SerializeField] private string itemDescription;

    private InventoryManager inventoryManager;
    
    void Start() {
        inventoryManager = GameObject.Find("NotebookCanvas").GetComponent<InventoryManager>();
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
            Destroy(gameObject);
        }
    }
}
