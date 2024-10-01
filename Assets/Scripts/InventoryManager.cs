using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
    public GameObject inventoryMenu;
    private bool menuActivated;
    public ItemSlot[] itemSlot;

    // Update is called once per frame
    void Update() { 
        // toggle inventory
        if (Input.GetButtonDown("Menu") && !menuActivated) {
            Time.timeScale = 0;
            inventoryMenu.SetActive(true);
            menuActivated = true;
            itemSlot[0].OnLeftClick();
        } else if (Input.GetButtonDown("Menu") && menuActivated) {
            Time.timeScale = 1;
            DeselectAllSlots();
            inventoryMenu.SetActive(false);
            menuActivated = false;
        }
    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription) {
        for (int i = 0; i < itemSlot.Length; i++) {
            if(itemSlot[i].isFull == false && itemSlot[i].name == name || itemSlot[i].quantity == 0) {
                int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription);
                if (leftOverItems > 0) {
                    leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription);
                }
                return leftOverItems;
            }
        }
        return quantity;
    }

    public void DeselectAllSlots() {
        for (int i = 0; i < itemSlot.Length; i++) {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }
}
