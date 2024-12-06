using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlotPM : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    private bool clicked;
    private bool isUsable;
    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;
    
    //===========ITEM DATA===========//
    public string itemName;
    public Sprite itemSprite;
    public Sprite emptySprite;

    //===========ITEM SLOT===========//
    [SerializeField] private Image slotImage;
    [SerializeField] private GameObject moveableSprite;

    public ItemSlot inventoryItemSlotReference;

    
    void Start() {
        clicked = false;
        isUsable = false;
        /*
        xMin = 1050;
        xMax = 1750;
        yMin = 450;
        yMax = 700;
        */
        xMin = Screen.width * 0.55f;
        xMax = Screen.width * 0.91f;
        yMin = Screen.height * 0.41f;
        yMax = Screen.height * 0.65f;
        UpdateSlot();
    }

    void Update() {
        if (clicked) {
            moveableSprite.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0); 
        }
    }

    public void UpdateSlot() {
        this.itemName = inventoryItemSlotReference.itemName;
        this.itemSprite = inventoryItemSlotReference.itemSprite;

        // if there is no sprite, make the slot the empty sprite
        if (this.itemSprite == null) {
            this.slotImage.sprite = emptySprite;
            isUsable = false;
        }
        else {
            this.slotImage.sprite = this.itemSprite;
            isUsable = true;
        }
    } 

    public void DropItem() {
        inventoryItemSlotReference.DropItem();
        this.UpdateSlot();
        this.slotImage.sprite = emptySprite;
        this.moveableSprite.SetActive(false);
        isUsable = false;
    }

    public void OnPointerDown(PointerEventData eventData) {
        // move moveable sprite with mouse
        if (isUsable) {
            clicked = true;
            moveableSprite.GetComponent<Image>().sprite = this.itemSprite;
            moveableSprite.SetActive(true);
        }
    }

    public void OnPointerUp(PointerEventData eventData) {
        clicked = false;
        
        // if the moveable sprite is within cauldron boundaries
        if(moveableSprite.transform.position.x > xMin && moveableSprite.transform.position.x < xMax &&
           moveableSprite.transform.position.y > yMin && moveableSprite.transform.position.y < yMax) {
            Debug.Log("Dropping " + itemName + " in cauldron");
            GameObject.FindWithTag("PotionMaker").GetComponent<PotionMaker>().AddItemToCauldron(this.itemName);
            this.DropItem();   
        }
        
        // reset moveable sprite position and visiblity
        moveableSprite.transform.position = this.transform.position;
        moveableSprite.GetComponent<Image>().sprite = null;
        moveableSprite.SetActive(false);
    } 
}
