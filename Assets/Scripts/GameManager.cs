using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    // ============ Managers ================
    private TaskManager taskManager;
    private InventoryManager inventoryManager;

    // ============ Game Status ================
    public int currentDay;
    public bool[] completedTasks;

    // ============ Constants ================
    // character indicies
    private const int MOTHER = 0;
    private const int SERENA = 1;
    private const int ASA = 2;
    private const int EWALD = 3;
    private const int DASHA = 4;
    private const int JOSAN = 5;
    private const int BESS = 6;
    private const int ISAAC = 7;
    private const int CLARICE = 8;
    private const int ROYCE = 9;
    private const int NANCY = 10;
    private const int KIERAN = 11;
    private const int JESSAMINE = 12;
    private string[] potionsForTasks = {"MotherPotion", "Victamis"};

    // ======= Dialogue Triggers ================
    [Header("NPC Dialogue Triggers")]
    [SerializeField] private DialogueTrigger[] dialogueTriggers;
    

    void Start() {
        taskManager = GameObject.Find("NotebookCanvas").GetComponent<TaskManager>();
        inventoryManager = GameObject.Find("NotebookCanvas").GetComponent<InventoryManager>();
        currentDay = 1;
        
        completedTasks = new bool[12];
        for (int i = 0; i < completedTasks.Length; i++) {
            completedTasks[i] = false;
        }
    }

    // Update is called once per frame
    void Update() {
                
    }

    public bool CheckPotion(int characterIndex) {
        if (characterIndex > 0 && characterIndex < potionsForTasks.Length) {
            return inventoryManager.HasPotion(potionsForTasks[characterIndex]);
        }
        else {
            Debug.LogWarning("Character index is wrong");
            return false;
        }
    }

    public void AddTask(string taskName, string taskGiver, string taskDescription) {
        taskManager.AddTask(taskName, taskGiver, taskDescription);
        
        if (taskGiver.ToLower() == "mother") {
            dialogueTriggers[MOTHER].dialogueIndex++;
        }
        else if (taskGiver.ToLower() == "serena") {
            dialogueTriggers[SERENA].dialogueIndex++;
        }
    }

    public void AddDialogueIndex(int characterIndex) {
        if (characterIndex > 0 && characterIndex < completedTasks.Length) {
            dialogueTriggers[characterIndex].dialogueIndex++;
        }
        else {
            Debug.LogWarning("Character index is wrong");
        }
    }
    
    public void CompleteTask(int characterIndex) {
        if (characterIndex > 0 && characterIndex < completedTasks.Length) {
            completedTasks[characterIndex] = true;
            AddDialogueIndex(characterIndex);
        }
        else {
            Debug.LogWarning("Character index is wrong");
        }
    }

    public void NewDay() {
        switch(currentDay) {
            case 1:
                if (completedTasks[SERENA]) {
                    UpdateDay(2);
                }
                else {
                    // not ready dialogue
                }
                break;
            
            case 2:
                if (completedTasks[ASA] && completedTasks[EWALD]) {
                    UpdateDay(3);
                }
                else {
                    // not ready dialogue
                }
                break;
            
            case 3:
                if (completedTasks[DASHA] && completedTasks[JOSAN]) {
                    UpdateDay(4);
                }
                else {
                    // not ready dialogue
                }
                break;

            case 4:
                if (completedTasks[BESS] && completedTasks[ISAAC] && completedTasks[CLARICE]) {
                    UpdateDay(5);
                }
                else {
                    // not ready dialogue
                }
                break;

            case 5:
                if (completedTasks[ROYCE] && completedTasks[NANCY]) {
                    UpdateDay(6);
                }
                else {
                    // not ready dialogue
                }
                break;
            
            case 6:
                if (completedTasks[KIERAN] && completedTasks[JESSAMINE]) {
                    UpdateDay(7);
                }
                else {
                    // not ready dialogue
                }
                break;
            
            default:
                Debug.LogWarning("Something's wrong, the day is no longer the day, we must go back to the beginning.");
                UpdateDay(1);
                break;
        }
    }

    private void UpdateDay(int dayNum) {
        Debug.Log("Starting day " + dayNum);
        currentDay = dayNum;
        taskManager.EmptyAllSlots();
        foreach(var trigger in dialogueTriggers) {
            trigger.dialogueIndex++;
        }
    }
}
