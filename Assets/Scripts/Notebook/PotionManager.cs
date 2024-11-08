using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PotionManager : MonoBehaviour {
    public PotionSlot[] potionSlot;
    public Item[] items;
    public TMP_Text potionIngredientsHeaderText;
    
    public void Awake() {
        DeselectAllSlots();

        Dictionary<Item, int> myDictionary = new Dictionary<Item, int>();
        myDictionary.Add(items[0], 1);
        myDictionary.Add(items[1], 1);  
        myDictionary.Add(items[2], 1);
        myDictionary.Add(items[3], 1);
        AddPotion("Victamis", "A common plant growth potion.", myDictionary);

        Dictionary<Item, int> myDictionary2 = new Dictionary<Item, int>();
        myDictionary2.Add(items[4], 1);
        myDictionary2.Add(items[5], 1);  
        myDictionary2.Add(items[6], 1);
        myDictionary2.Add(items[7], 1);
        AddPotion("Courinder", "Its light blue color may deter others at first glance but this concoction gives one the agility and speed needed for any long term exercise. Commonly given to horses, not recommended for any long term usages.", myDictionary2);

        Dictionary<Item, int> myDictionary3 = new Dictionary<Item, int>();
        myDictionary3.Add(items[8], 1);
        myDictionary3.Add(items[9], 1);  
        myDictionary3.Add(items[10], 1);
        myDictionary3.Add(items[11], 1);
        AddPotion("Heillar", "A soothing medicine. Can be consumed but some find it more beneficial to spread this orange potion onto their skin for faster effects.", myDictionary3);
    
        Dictionary<Item, int> myDictionary4 = new Dictionary<Item, int>();
        myDictionary4.Add(items[12], 1);
        myDictionary4.Add(items[13], 1);  
        myDictionary4.Add(items[14], 1);
        myDictionary4.Add(items[15], 1);
        AddPotion("Visamir", "An electrifying potion. Not to be taken in large quantities. Its black sludge appearance matches its less than ideal taste.", myDictionary4);

        Dictionary<Item, int> myDictionary5 = new Dictionary<Item, int>();
        myDictionary5.Add(items[16], 1);
        myDictionary5.Add(items[17], 1);  
        myDictionary5.Add(items[18], 1);
        myDictionary5.Add(items[19], 1);
        AddPotion("Somnias", "A calming potion. Some mothers find it most useful for small children and infants to dream easily. The pale glittering elixir resembles night clouds in the starry sky.", myDictionary5);
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
