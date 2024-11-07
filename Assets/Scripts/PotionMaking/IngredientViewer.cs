using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IngredientViewer : MonoBehaviour {
    [SerializeField] private TMP_Dropdown ingreidentDropdown;
    [SerializeField] private PotionSlot[] potions;
    [SerializeField] private GameObject[] recipeIngredients;
    void Start() {
        potions = GameObject.FindWithTag("NotebookCanvas").GetComponentsInChildren<PotionSlot>(true);
        List<string> options = new List<string>();
        for (int i = 0; i < potions.Length; i++) {
            if (potions[i].isFull) {
                options.Add(potions[i].potionName);
            }
        }
        ingreidentDropdown.ClearOptions();
        ingreidentDropdown.AddOptions(options);
        UpdateIngredients(0);
    }

    public void UpdateIngredients(int index) {
        if(potions[index].isFull) {
            Debug.Log(potions[index].potionName);
            int i = 0;
            foreach(KeyValuePair<Item, int> ingredient in potions[index].potionIngredients) {
                recipeIngredients[i].GetComponentInChildren<Image>().sprite = ingredient.Key.sprite;
                recipeIngredients[i].GetComponentInChildren<TextMeshProUGUI>().text = "x " + ingredient.Value;
                i++;
            }
        }
    }
}
