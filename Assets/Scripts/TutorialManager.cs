using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour {
    private TaskManager taskManager;
    private PotionManager potionManager;
    
    void Start() {
        potionManager = GameObject.Find("NotebookCanvas").GetComponent<PotionManager>();  
        taskManager = GameObject.Find("NotebookCanvas").GetComponent<TaskManager>();

        // Hardcoding adding potion and task
        potionManager.AddPotion("Victamis", "A common plant growth potion.", " - Robin’s feather x1\n - Moon frog x1\n - Primrose x1\n - Moss x1");
        taskManager.AddTask("My First Task", "Serena", "Poor Serena, this season has hit everyone in the village hard, them especially. Maybe I can make things a bit easier for them." );  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
