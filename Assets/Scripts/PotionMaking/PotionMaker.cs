using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionMaker : MonoBehaviour {
    [SerializeField] private GameObject potionCanvas;
    [SerializeField] private ItemSlotPM[] itemSlot;
    [SerializeField] private GameObject visualCue;
    [SerializeField] private List<string> itemsInCauldron;
    [SerializeField] private PotionSlot[] potions;
    public bool playerInRange;
    public bool potionCanvasActive;

    private void Start() {
        playerInRange = false;
        potionCanvasActive = false;
        visualCue.SetActive(false);
        potionCanvas.SetActive(false);

        // Get a list of all potions
        itemsInCauldron = new List<string>();
        potions = GameObject.FindWithTag("NotebookCanvas").GetComponentsInChildren<PotionSlot>(true);

        // Find all item slot references from the notebook
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
        itemsInCauldron.Add(itemName);
    }

    public void EmptyCauldron() {
        itemsInCauldron.Clear();
    }

    public void FinishPotion() {
        foreach (var potion in potions) {
            foreach (var potionIngredient in potion.potionIngredients) {
                // put functionality here
            }
        }
    }
}
