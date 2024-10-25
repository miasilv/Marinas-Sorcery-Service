using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PotionMaker : MonoBehaviour {
    [SerializeField] private GameObject potionCanvas;
    [SerializeField] private ItemSlotPM[] itemSlot;
    [SerializeField] private GameObject visualCue;
    [SerializeField] private Dictionary<string, int> itemsInCauldron;
    [SerializeField] private PotionSlot[] potions;
    [SerializeField] private GameObject[] potionPrefabs;

    [SerializeField] private GameObject potionCompletePanel;
    [SerializeField] private TMP_Text potionCompleteText;
    private InventoryManager inventoryManager;
    public bool playerInRange;
    public bool potionCanvasActive;

    private void Start() {
        playerInRange = false;
        potionCanvasActive = false;
        visualCue.SetActive(false);
        potionCanvas.SetActive(false);

        // Get a list of all potions
        itemsInCauldron = new Dictionary<string, int>();
        potions = GameObject.Find("NotebookCanvas").GetComponentsInChildren<PotionSlot>(true);

        // Find all item slot references from the notebook
        inventoryManager = GameObject.Find("NotebookCanvas").GetComponent<InventoryManager>();
        ItemSlot[] itemSlotReferences = GameObject.FindWithTag("NotebookCanvas").GetComponentsInChildren<ItemSlot>(true);
        for (int i = 0; i < itemSlot.Length && i < itemSlotReferences.Length; i++) {
            itemSlot[i].inventoryItemSlotReference = itemSlotReferences[i];
        }
        UpdateAllSlots();
    }

    private void Update() {
        if (playerInRange) {
            visualCue.SetActive(true);
            if (Input.GetButtonDown("Interact"))  {
                potionCanvas.SetActive(true);
                potionCanvasActive = true;
                UpdateAllSlots();
                // Have to disable character movement
            }
        }
        else {
            visualCue.SetActive(false);
        }

        if (potionCanvasActive && Input.GetButtonDown("Cancel")) {
            potionCanvas.SetActive(false);
            potionCanvasActive = false;
            // have to enable character movement
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            playerInRange = false;
        }
    }

    public void UpdateAllSlots() {
        for (int i = 0; i < itemSlot.Length; i++) {
            itemSlot[i].UpdateSlot();
        }
    }

    public void AddItemToCauldron(string itemName) {
        // If the item already exists in the cauldron, increment its quantity
        if (itemsInCauldron.ContainsKey(itemName)) {
            itemsInCauldron[itemName]++;
        }
        // if its a new item, add it to the dictionary
        else {
            itemsInCauldron.Add(itemName, 1);
        }
    }

    public void EmptyCauldron() {
        itemsInCauldron.Clear();
    }

    public void FinishPotion() {
        string potionText = "...something?";
        if (itemsInCauldron.Count > 0) {
            foreach (var potion in potions) {
                if (potion.isFull && CheckPotion(potion)) {
                    potionText = " " + potion.potionName;
                    break;
                }
            }
        }
        potionCompleteText.text = "You made" + potionText;
        potionCompletePanel.SetActive(true);
        EmptyCauldron();

    }

    private bool CheckPotion(PotionSlot potion) {
        // Check if the number of ingredients matches
        if (itemsInCauldron.Count != potion.potionIngredients.Count) {
            return false;
        }

        // Check each ingredient in the potion
        foreach (var potionIngredient in potion.potionIngredients) {
            string itemName = potionIngredient.Key.itemName;
            int requiredAmount = potionIngredient.Value;

            // Check if the cauldron has the ingredient and the correct amount
            if (!itemsInCauldron.ContainsKey(itemName) || itemsInCauldron[itemName] != requiredAmount) {
                return false;
            }
        }

        return true;
    }
}
