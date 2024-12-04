using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler {
    //===========ITEM DATA===========//
    public string itemName;
    public Sprite itemSprite;
    public string itemDescription;
    public bool isFull;
    
    //===========ITEM SLOT===========//
    [SerializeField] private Image slotImage;

    
    //===========ITEM DESCRIPTION SLOT==========//
    public Image itemDescriptionImage;
    public TMP_Text itemDescriptionNameText;
    public TMP_Text itemDescriptionText;


    public GameObject selectedShader;
    public bool thisItemSelected;
    public Sprite emptySprite;
    private InventoryManager inventoryManager;
    
    private void Awake() {
        inventoryManager = GameObject.Find("NotebookCanvas").GetComponent<InventoryManager>();
    }

    public void AddItem(string itemName, Sprite itemSprite, string itemDescription)  {
        //check to see if the slot is already full
        if (isFull) {
            return;
        }

        // Update Name, Image, and Description
        this.itemName = itemName;
        this.itemSprite = itemSprite;
        this.itemDescription = itemDescription;

        // update slot image
        slotImage.sprite = itemSprite;  

        isFull = true;      
    }

    public void DropItem() {
        EmptySlot();
    }

    public void OnPointerClick(PointerEventData eventData) {
        // select an item and update the item description
        if (eventData.button == PointerEventData.InputButton.Left) {
            inventoryManager.DeselectAllSlots();
            selectedShader.SetActive(true);
            thisItemSelected = true;
            
            itemDescriptionNameText.text = itemName;
            itemDescriptionText.text = itemDescription;
            itemDescriptionImage.sprite = itemSprite;

            if (itemDescriptionImage.sprite == null) {
                itemDescriptionImage.sprite = emptySprite;
            }
        }
    } 

    public void EmptySlot() {
        // Remove the item data
        itemName = "";
        itemSprite = emptySprite;
        itemDescription = "";
        isFull = false;

        // Remove the slot data
        slotImage.sprite = emptySprite;
        
        // Remove the description information
        itemDescriptionNameText.text = "";
        itemDescriptionText.text = "";
        itemDescriptionImage.sprite = emptySprite;
    }
}
