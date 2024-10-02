using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {
    public GameObject inventoryMenu;
    private bool menuActivated;
    public ItemSlot[] itemSlot;

    // Drop and Equip Capability
    public TMP_Text NumOfItemsToDrop;
    public TMP_Text InvalidInputText;

    public void Awake() {
        DeselectAllSlots();
        inventoryMenu.SetActive(false);
        menuActivated = false;
    }
    
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

    public void DropItems() {
        string str = NumOfItemsToDrop.text;
        string numToDropStr = "";    
        for (int i = 0; i < str.Length; i++) {
            if (char.IsDigit(str[i])) {
                numToDropStr += str[i];
            }
        }
        
        if (int.TryParse(numToDropStr, out int numToDrop) && numToDrop > 0 && numToDrop < 10) {
            for (int i = 0; i < itemSlot.Length; i++) {
                if (itemSlot[i].thisItemSelected) {
                    itemSlot[i].DropItems(numToDrop);
                }
            }
        }
        else {
            InvalidInputText.enabled = true;
        }
    }

    public void EquipItem() {
        for (int i = 0; i < itemSlot.Length; i++) {
            if (itemSlot[i].thisItemSelected) {
                itemSlot[i].EquipItem();
            }
        }
    }

    public void DeselectAllSlots() {
        for (int i = 0; i < itemSlot.Length; i++) {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
        InvalidInputText.enabled = false;
        NumOfItemsToDrop.text = "";

    }
}
