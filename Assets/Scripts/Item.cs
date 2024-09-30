using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private int quantity;
    [SerializeField] private Sprite sprite;

    private InventoryManager inventoryManager;
    
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    void OnTriggerEnter2D(Collider2D col) 
    {
        Debug.Log("collided");
        if (col.gameObject.tag == "Player") 
        {
            inventoryManager.AddItem(itemName, quantity, sprite);
            Destroy(gameObject);
        }
    }
}
