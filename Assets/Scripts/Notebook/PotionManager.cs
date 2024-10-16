using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PotionManager : MonoBehaviour {
    public PotionSlot[] potionSlot;
    public TMP_Text potionIngredientsHeaderText;
    
    public void Awake() {
        DeselectAllSlots();
    }
    
    public void AddPotion(string potionName, string potionDescription, Dictionary<Item, int> potionIngredients) {
        // look for an unfilled slot
        for (int i = 0; i < potionSlot.Length; i++) {
            if(!potionSlot[i].isFull) {
                potionSlot[i].AddPotion(potionName, potionDescription, potionIngredients);
                return;
            }
        }
    }
    
    public void DeselectAllSlots() {
        for (int i = 0; i < potionSlot.Length; i++) {
            potionSlot[i].selectedShader.SetActive(false);
            potionSlot[i].thisItemSelected = false;
            potionSlot[i].DeselctSlot();
        }
        potionIngredientsHeaderText.enabled = false;
    }
}
