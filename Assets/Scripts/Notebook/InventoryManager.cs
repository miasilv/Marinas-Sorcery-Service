using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {
    public ItemSlot[] itemSlot;

    public void Awake() {
        DeselectAllSlots();
    }

    public void AddItem(string itemName, Sprite itemSprite, string itemDescription) {
        // look for an unfilled slot
        for (int i = 0; i < itemSlot.Length; i++) {
            if(!itemSlot[i].isFull) {
                itemSlot[i].AddItem(itemName, itemSprite, itemDescription);
                return;
            }
        }
    }

    public void DropItem() {        
        for (int i = 0; i < itemSlot.Length; i++) {
            if (itemSlot[i].thisItemSelected) {
                itemSlot[i].DropItem();
            }
        }
    }

    public bool HasPotion(string potionName) {
        for (int i = 0; i < itemSlot.Length; i++) {
            if(itemSlot[i].itemName == potionName) {
                return true;
            }
        }
        return false;
    }

    public void GivePotion(string potionName) {
        for (int i = 0; i < itemSlot.Length; i++) {
            if(itemSlot[i].itemName == potionName) {
                itemSlot[i].DropItem();
                return;
            }
        }
        Debug.LogWarning("No potion to give");
    }

    public void DeselectAllSlots() {
        for (int i = 0; i < itemSlot.Length; i++) {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }

    }

    public void Clear() {
        for (int i = 0; i < itemSlot.Length; i++) {
            itemSlot[i].EmptySlot();
        }
    }
}
