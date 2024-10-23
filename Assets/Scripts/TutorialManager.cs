using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour {
    private TaskManager taskManager;
    private PotionManager potionManager;

    [SerializeField] Item[] items;
    
    void Start() {
        potionManager = GameObject.Find("NotebookCanvas").GetComponent<PotionManager>();  
        taskManager = GameObject.Find("NotebookCanvas").GetComponent<TaskManager>();

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

        taskManager.AddTask("My First Task", "Serena", "Poor Serena, this season has hit everyone in the village hard, them especially. Maybe I can make things a bit easier for them." );  
    }
}
