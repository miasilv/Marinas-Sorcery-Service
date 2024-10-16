using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IngredientViewer : MonoBehaviour {
    [SerializeField] private TMP_Dropdown ingreidentDropdown;
    [SerializeField] private PotionSlot[] potions;
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
    }
}
