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
    public int[] dialogueIndicies;
    public bool[] waitingForPotions;
    private string[] potionsForTasks = {"MotherPotion", "Victamis", "Courinder", "Heillar", "Visamir", "Somnias"};

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
    

    void Start() {
        taskManager = GameObject.Find("NotebookCanvas").GetComponent<TaskManager>();
        inventoryManager = GameObject.Find("NotebookCanvas").GetComponent<InventoryManager>();
        currentDay = 1;
        
        completedTasks = new bool[12];
        for (int i = 0; i < completedTasks.Length; i++) {
            completedTasks[i] = false;
        }

        waitingForPotions = new bool[12];
        for (int i = 0; i < waitingForPotions.Length; i++) {
            waitingForPotions[i] = false;
        }

        dialogueIndicies = new int[12];
        for (int i = 0; i < dialogueIndicies.Length; i++) {
            dialogueIndicies[i] = 0;
        }
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
        GameObject.Find("NotebookCanvas").GetComponent<TaskManager>().AddTask(taskName, taskGiver, taskDescription);
        
        if (taskGiver.ToLower() == "mother") {
            dialogueIndicies[MOTHER] += 1;
        }
        else if (taskGiver.ToLower() == "serena") {
            dialogueIndicies[SERENA] += 1;
            waitingForPotions[SERENA] = true;
        }
        else if (taskGiver.ToLower() == "asa") {
            dialogueIndicies[ASA] += 1;
            waitingForPotions[ASA] = true;
        }
        else if (taskGiver.ToLower() == "ewald") {
            dialogueIndicies[EWALD] += 1;
            waitingForPotions[EWALD] = true;
        }
        else if (taskGiver.ToLower() == "dasha") {
            dialogueIndicies[DASHA] += 1;
            waitingForPotions[DASHA] = true;
        }
        else if (taskGiver.ToLower() == "josan") {
            dialogueIndicies[JOSAN] += 1;
            waitingForPotions[JOSAN] = true;
        }
    }

    public void AddtoDialogueIndex(int characterIndex, int numToAdd) {
        if (characterIndex > 0 && characterIndex < dialogueIndicies.Length) {
            dialogueIndicies[characterIndex] += numToAdd;
        }
        else {
            Debug.LogWarning("Character index is wrong");
        }
    }
    
    public void CompleteTask(int characterIndex) {
        if (characterIndex > 0 && characterIndex < completedTasks.Length) {
            completedTasks[characterIndex] = true;
            waitingForPotions[characterIndex] = false;
            inventoryManager.GivePotion(potionsForTasks[characterIndex]);
            AddtoDialogueIndex(characterIndex, 1);
        }
        else {
            Debug.LogWarning("Character index is wrong");
        }
    }

    public void NewDay() {
        switch(currentDay) {
            case 1:
                UpdateDay(2);
                break;
            
            case 2:
                UpdateDay(3);
                break;
            
            case 3:
                UpdateDay(4);
                break;

            case 4:
                UpdateDay(5);
                break;

            case 5:
                UpdateDay(6);
                break;
            
            case 6:
                UpdateDay(7);
                break;
            
            case 7:
                UpdateDay(8);
                break;
            
            default:
                Debug.LogWarning("Something's wrong, the day is no longer the day, we must go back to the beginning.");
                return false;
                break;
        }
        return false;
    }

    private void UpdateDay(int newDayNum) {
        Debug.Log("Starting day " + newDayNum);
        currentDay = newDayNum;
        taskManager.EmptyAllSlots();
        for (int i = 0; i < dialogueIndicies.Length; i++) {
            AddtoDialogueIndex(i, 1);
        }
    }
}
