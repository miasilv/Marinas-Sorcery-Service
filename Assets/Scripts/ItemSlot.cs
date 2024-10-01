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
    public Sprite emptySprite;

    
    //===========ITEM SLOT===========//
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image itemImage;

    //===========ITEM DESCRIPTION SLOT==========//
    public Image itemDescriptionImage;
    public TMP_Text itemDescriptionNameText;
    public TMP_Text itemDescriptionText;


    public GameObject selectedShader;
    public bool thisItemSelected;
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
        itemImage.sprite = itemSprite;
        
        this.itemDescription = itemDescription;

        // Update Quantity
        this.quantity += quantity;

        // if quantity is greater than max number of items
        if (this.quantity >= maxNumberOfItems) {
            quantityText.text = maxNumberOfItems.ToString();
            quantityText.enabled = true;
            isFull = true;

            int extraItems = this.quantity - maxNumberOfItems;
            this.quantity = maxNumberOfItems;
            return extraItems;
        }

        // if quantity is less than max number of items     
        quantityText.text = this.quantity.ToString();
        quantityText.enabled = true;
        return 0;        
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (eventData.button == PointerEventData.InputButton.Left) {
            OnLeftClick();
        }
        
        if (eventData.button == PointerEventData.InputButton.Right) {
            OnRightClick();
        }
    }

    public void OnLeftClick() {
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

    public void OnRightClick() {

    }
}
