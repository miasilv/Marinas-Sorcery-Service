using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PotionSlot : MonoBehaviour, IPointerClickHandler {
    //===========POTION DATA===========//
    public string potionName;
    public string potionDescription;
    public Dictionary<Item, int> potionIngredients;
    public bool isFull;

    //===========POTION SLOT===========//
    public TMP_Text potionSlotNameText;

    //===========POTION DESCRIPTION INFO==========//
    public TMP_Text potionNameDescriptionText;
    public TMP_Text potionDescriptionText;
    public TMP_Text[] potionIngredientsText;
    public Image[] potionIngredientsImage;
    public TMP_Text potionIngredientsHeaderText;
    
    public GameObject selectedShader;
    public bool thisItemSelected;
    private PotionManager potionManager;
    public Sprite emptySprite;

    private void Awake() {
        potionManager = GameObject.Find("NotebookCanvas").GetComponent<PotionManager>();
    }

    public void AddPotion(string potionName, string potionDescription, Dictionary<Item, int> potionIngredients) {        
        // updating potion information
        this.potionName = potionName;
        this.potionDescription = potionDescription;
        this.potionIngredients = potionIngredients;

        // updating potion slot
        this.potionSlotNameText.text = this.potionName;
        isFull = true;
    }
    
    public void OnPointerClick(PointerEventData eventData) {
        // select a potion and update the potion description
        if (eventData.button == PointerEventData.InputButton.Left) {
            potionManager.DeselectAllSlots();
            selectedShader.SetActive(true);
            thisItemSelected = true;
            
        }

        potionNameDescriptionText.text = this.potionName;
        potionDescriptionText.text = this.potionDescription;
        int i = 0;
        foreach(KeyValuePair<Item, int> ingredient in potionIngredients) {
            potionIngredientsText[i].text = ingredient.Key.itemName + " x" + ingredient.Value;
            potionIngredientsImage[i].sprite = ingredient.Key.sprite; 
            i++;
        }
        potionIngredientsHeaderText.enabled = true;
    }

    public void DeselctSlot() {
        potionNameDescriptionText.text = "";
        potionDescriptionText.text = "";
        for (int i = 0; i < potionIngredientsText.Length; i++) {
            potionIngredientsText[i].text = "";
            potionIngredientsImage[i].sprite = emptySprite;
        }

        potionIngredientsHeaderText.enabled = false;
    }

}