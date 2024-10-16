using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler {
    //===========ITEM DATA===========//
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public string itemDescription;
    public bool isFull;
    
    //===========ITEM SLOT===========//
    [SerializeField] private TMP_Text slotQuantityText;
    [SerializeField] private Image slotImage;

    
    //===========ITEM DESCRIPTION SLOT==========//
    public Image itemDescriptionImage;
    public TMP_Text itemDescriptionNameText;
    public TMP_Text itemDescriptionText;


    public GameObject selectedShader;
    public bool thisItemSelected;
    public Sprite emptySprite;
    private InventoryManager inventoryManager;
    [SerializeField] public int maxNumberOfItems;
    
    private void Awake() {
        inventoryManager = GameObject.Find("NotebookCanvas").GetComponent<InventoryManager>();
    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)  {
        //check to see if the slot is already full
        if (isFull) {
            return quantity;
        }

        // Update Name, Image, and Description
        this.itemName = itemName;
        this.itemSprite = itemSprite;
        this.itemDescription = itemDescription;

        // update slot image
        slotImage.sprite = itemSprite;  

        // Update Quantity
        this.quantity += quantity;

        // if quantity is greater than max number of items
        if (this.quantity >= maxNumberOfItems) {
            slotQuantityText.text = maxNumberOfItems.ToString();
            slotQuantityText.enabled = true;
            isFull = true;

            int extraItems = this.quantity - maxNumberOfItems;
            this.quantity = maxNumberOfItems;
            return extraItems;
        }

        // if quantity is less than max number of items     
        slotQuantityText.text = this.quantity.ToString();
        slotQuantityText.enabled = true;
        return 0;        
    }

    public void DropItem(int numToDrop) {
        this.quantity -= numToDrop;
        slotQuantityText.text = this.quantity.ToString();
        if (this.quantity <= 0) {
            EmptySlot();
        }
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
        quantity = 0;
        itemDescription = "";
        isFull = false;

        // Remove the slot data
        slotQuantityText.enabled = false;
        slotImage.sprite = emptySprite;
        
        // Remove the description information
        itemDescriptionNameText.text = "";
        itemDescriptionText.text = "";
        itemDescriptionImage.sprite = emptySprite;
    }
}
