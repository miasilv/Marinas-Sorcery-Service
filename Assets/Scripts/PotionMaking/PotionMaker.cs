using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PotionMaker : MonoBehaviour {
    private PlayerManager player;
    [SerializeField] private GameObject potionCanvas;
    [SerializeField] private ItemSlotPM[] itemSlot;
    [SerializeField] private GameObject visualCue;
    [SerializeField] private Dictionary<string, int> itemsInCauldron;
    [SerializeField] private PotionSlot[] potions;
    [SerializeField] private GameObject[] potionPrefabs;

    [SerializeField] private GameObject potionCompletePanel;
    [SerializeField] private TMP_Text potionCompleteText;
    private InventoryManager inventoryManager;
    private AudioManager audioManager;
    public AudioClip cauldronBubble;
    public AudioClip emptyPotion;
    public AudioClip dropIngredient;
    public bool playerInRange;
    public bool potionCanvasActive;
    [SerializeField] public Sprite potionSprite;

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
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    private void Update() {
        if (playerInRange) {
            visualCue.SetActive(true);
            if (Input.GetButtonDown("Interact"))  {
                audioManager.PlayCauldronBubble(cauldronBubble);
                potionCanvas.SetActive(true);
                potionCanvasActive = true;
                UpdateAllSlots();
                player.canMove = false;
            }
        }
        else {
            visualCue.SetActive(false);
        }

        if (potionCanvasActive && Input.GetButtonDown("Cancel")) {
            potionCanvas.SetActive(false);
            potionCanvasActive = false;
            player.canMove = true;
            audioManager.StopCauldronBubble();
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
        audioManager.PlayUI2(dropIngredient);
    }

    public void EmptyCauldron() {
        itemsInCauldron.Clear();
    }

    public void EmptyCauldronWithSound() {
        itemsInCauldron.Clear();
        audioManager.PlayUI2(emptyPotion);
    }

    public void FinishPotion() {
        if (itemsInCauldron.Count <= 0) {
            potionCompleteText.text = "Goodbye!";
        }
        else {
            string potionText = "...something?";
            if (itemsInCauldron.Count > 0) {
                foreach (var potion in potions) {
                    if (potion.isFull && CheckPotion(potion)) {
                        potionText = " " + potion.potionName;
                        inventoryManager.AddItem(potion.potionName, 1, potionSprite, potion.potionDescription);
                        break;
                    }
                }
            }
            potionCompleteText.text = "You made" + potionText;
        }
        potionCompletePanel.SetActive(true);
        itemsInCauldron.Clear();
        player.canMove = true;
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
