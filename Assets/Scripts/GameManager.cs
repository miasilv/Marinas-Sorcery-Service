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

    public void CompleteTask(int taskGiver) {
        completedTasks[taskGiver] = true;
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
