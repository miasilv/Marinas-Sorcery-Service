using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour {
    private TaskManager taskManager;
    private PotionManager potionManager;
    private InventoryManager inventoryManager;

    [SerializeField] Item[] items;
    
    void Start() {
        potionManager = GameObject.Find("NotebookCanvas").GetComponent<PotionManager>();  
        taskManager = GameObject.Find("NotebookCanvas").GetComponent<TaskManager>();
        inventoryManager = GameObject.Find("NotebookCanvas").GetComponent<InventoryManager>();

        // Hardcoding adding potion and task
        Dictionary<Item, int> myDictionary = new Dictionary<Item, int>();
        myDictionary.Add(items[0], 1);
        myDictionary.Add(items[1], 1);  
        myDictionary.Add(items[2], 1);
        myDictionary.Add(items[3], 1);

        Dictionary<Item, int> myDictionary2 = new Dictionary<Item, int>();
        myDictionary2.Add(items[3], 2);
        myDictionary2.Add(items[2], 2);  
        myDictionary2.Add(items[1], 2);
        myDictionary2.Add(items[0], 2);       

        potionManager.AddPotion("Victamis", "A common plant growth potion.", myDictionary);
        potionManager.AddPotion("Victamis 2", "A common plant growth potion pt.2.", myDictionary2);

        taskManager.AddTask("My First Task", "Serena", "Poor Serena, this season has hit everyone in the village hard, them especially. Maybe I can make things a bit easier for them.");

        inventoryManager.AddItem(items[0].itemName, 3, items[0].sprite, items[0].itemDescription); 
        inventoryManager.AddItem(items[1].itemName, 3, items[1].sprite, items[1].itemDescription); 
        inventoryManager.AddItem(items[2].itemName, 3, items[2].sprite, items[2].itemDescription); 
        inventoryManager.AddItem(items[3].itemName, 3, items[3].sprite, items[3].itemDescription);  
    }
}
