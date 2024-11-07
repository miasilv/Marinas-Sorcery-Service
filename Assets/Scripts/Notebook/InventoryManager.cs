using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {
    public ItemSlot[] itemSlot;

    public TMP_Text inputNumOfItemsToDrop;
    public TMP_Text invalidInputText;

    public void Awake() {
        DeselectAllSlots();
    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription) {
        // look for an unfilled slot
        for (int i = 0; i < itemSlot.Length; i++) {
            if(!itemSlot[i].isFull && itemSlot[i].name == name || itemSlot[i].quantity == 0) {
                int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription);
                if (leftOverItems > 0) {
                    leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription);
                }
                return leftOverItems;
            }
        }
        return quantity;
    }

    public void DropItem() {
        string str = inputNumOfItemsToDrop.text;
        string numToDropStr = "";    
        for (int i = 0; i < str.Length; i++) {
            if (char.IsDigit(str[i])) {
                numToDropStr += str[i];
            }
        }
        Debug.Log(numToDropStr);
        
        if (int.TryParse(numToDropStr, out int numToDrop) && numToDrop > 0 && numToDrop < 10) {
            for (int i = 0; i < itemSlot.Length; i++) {
                if (itemSlot[i].thisItemSelected) {
                    itemSlot[i].DropItem(numToDrop);
                }
            }
        }
        else {
            invalidInputText.enabled = true;
        }
    }

    public bool hasPotion(string potionName) {
        for (int i = 0; i < itemSlot.Length; i++) {
            if(itemSlot[i].itemName == potionName) {
                return true;
            }
        }
        return false;
    }

    public void DeselectAllSlots() {
        for (int i = 0; i < itemSlot.Length; i++) {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
        invalidInputText.enabled = false;
        inputNumOfItemsToDrop.text = "";

    }
}
