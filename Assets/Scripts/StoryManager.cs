using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// dialogue Indices for NPCs
// 0 - default, 1 - give task, 2 - given task, no potion, 3 - given task, yes potion, 4 - finished task, 5- against, 6 - for 

public class StoryManager : MonoBehaviour {
    private PlayerManager player;
    [SerializeField] Animator fadeToBlack;
    [SerializeField] Animator rollCredits;
    // ============ Managers ================
    private TaskManager taskManager;
    private InventoryManager inventoryManager;

    // ============ Game Status ================
    public int currentDay;
    public bool[] completedTasks;
    public int totalCompletedTasks;
    public int[] dialogueIndicies;
    public bool[] waitingForPotions;
    public string[] potionsForTasks = {"Aegoria", "Victamis", "Courinder", "Heillar", "Visamir", 
                                        "Somnias", "Cipheriam", "Honey Drink", "Viennallis", "Heillus", 
                                        "Pervivious", "Blueberry Syrup", "Memoria"};

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
    private const int MAYOR = 13;
    
    void Start() {
        taskManager = GameObject.Find("NotebookCanvas").GetComponent<TaskManager>();
        inventoryManager = GameObject.Find("NotebookCanvas").GetComponent<InventoryManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        
        completedTasks = new bool[14];
        for (int i = 0; i < completedTasks.Length; i++) {
            completedTasks[i] = false;
        }

        waitingForPotions = new bool[14];
        for (int i = 0; i < waitingForPotions.Length; i++) {
            waitingForPotions[i] = false;
        }

        dialogueIndicies = new int[14];
        for (int i = 0; i < dialogueIndicies.Length; i++) {
            dialogueIndicies[i] = 0;
        }

        // Setup day 1
        currentDay = 1;
        totalCompletedTasks = 0;
        dialogueIndicies[SERENA] = 1;
        dialogueIndicies[MOTHER] = 1;
    }

    public bool CheckPotion(int characterIndex) {
        if (characterIndex >= 0 && characterIndex < potionsForTasks.Length) {
            return inventoryManager.HasPotion(potionsForTasks[characterIndex]);
        }
        else {
            Debug.LogWarning("Character index is wrong");
            return false;
        }
    }

    public void AddTask(string taskName, string taskGiver, string taskDescription) {       
        if (taskGiver.ToLower() == "mother") {
            dialogueIndicies[MOTHER] += 1;
            waitingForPotions[MOTHER] = true;
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
        else if (taskGiver.ToLower() == "bess") {
            dialogueIndicies[BESS] += 1;
            waitingForPotions[BESS] = true;
        }
        else if (taskGiver.ToLower() == "isaac") {
            dialogueIndicies[ISAAC] += 1;
            waitingForPotions[ISAAC] = true;
        }
        else if (taskGiver.ToLower() == "clarice") {
            dialogueIndicies[CLARICE] += 1;
            waitingForPotions[CLARICE] = true;
        }
        else if (taskGiver.ToLower() == "royce") {
            dialogueIndicies[ROYCE] += 1;
            waitingForPotions[ROYCE] = true;
        }
        else if (taskGiver.ToLower() == "nancy") {
            dialogueIndicies[NANCY] += 1;
            waitingForPotions[NANCY] = true;
        }
        else if (taskGiver.ToLower() == "kieran") {
            dialogueIndicies[KIERAN] += 1;
            waitingForPotions[KIERAN] = true;
        }
        else if (taskGiver.ToLower() == "jessamine") {
            dialogueIndicies[JESSAMINE] += 1;
            waitingForPotions[JESSAMINE] = true;
        }
        else {
            Debug.LogWarning("Incorrect task giver");
            return;
        }
        GameObject.Find("NotebookCanvas").GetComponent<TaskManager>().AddTask(taskName, taskGiver, taskDescription);
    }

    public void AddtoDialogueIndex(int characterIndex, int numToAdd) {
        if (characterIndex >= 0 && characterIndex < dialogueIndicies.Length) {
            dialogueIndicies[characterIndex] += numToAdd;
        }
        else {
            Debug.LogWarning("Character index is wrong");
        }
    }

    public void ChangeDialogueIndex(int characterIndex, int newDialogueIndex) {
        if (characterIndex >= 0 && characterIndex < dialogueIndicies.Length) {
            dialogueIndicies[characterIndex] = newDialogueIndex;
            // if it is the last dialogue of the mayor
            if (characterIndex == 13 && newDialogueIndex == 3 && totalCompletedTasks >= 7) {
                dialogueIndicies[characterIndex] = (newDialogueIndex + 1);
            }
        }
        else {
            Debug.LogWarning("Character index is wrong");
        }        
    }
    
    public void CompleteTask(int characterIndex) {
        if (characterIndex >= 0 && characterIndex < completedTasks.Length) {
            completedTasks[characterIndex] = true;
            waitingForPotions[characterIndex] = false;
            inventoryManager.GivePotion(potionsForTasks[characterIndex]);
            if (characterIndex != 0) {
                dialogueIndicies[characterIndex] = 4;
                totalCompletedTasks++;
            }
        }
        else {
            Debug.LogWarning("Character index is wrong");
        }
    }
    
    private void resetCompletedPotions() {
        for (int i = 0; i < waitingForPotions.Length; i++) {
            completedTasks[i] = false;       
        }
    }
    private void resetCharacterDialogueIndicies() {
        for (int i = 0; i < dialogueIndicies.Length; i++) {
            dialogueIndicies[i] = 0;       
        }
    }

    private void resetWaitingForPotion() {
        for (int i = 0; i < waitingForPotions.Length; i++) {
            waitingForPotions[i] = false;       
        }
    }

    public void NewDay() {
        switch(currentDay) {
            case 1:                
                UpdateDay(2);
                dialogueIndicies[MAYOR] = 0;
                dialogueIndicies[ASA] = 1;
                dialogueIndicies[EWALD] = 1;
                break;
            
            case 2:
                UpdateDay(3);
                dialogueIndicies[MOTHER] = 2;
                dialogueIndicies[DASHA] = 1;
                dialogueIndicies[JOSAN] = 1;
                break;
            
            case 3:
                UpdateDay(4);
                dialogueIndicies[BESS] = 1;
                dialogueIndicies[ISAAC] = 1;
                dialogueIndicies[CLARICE] = 1;
                break;

            case 4:
                UpdateDay(5);
                dialogueIndicies[MOTHER] = 3;
                dialogueIndicies[ROYCE] = 1;
                dialogueIndicies[NANCY] = 1;
                break;

            case 5:
                UpdateDay(6);
                dialogueIndicies[MAYOR] = 1;
                dialogueIndicies[KIERAN] = 1;
                dialogueIndicies[JESSAMINE] = 1;
                break;
            
            case 6:
                UpdateDay(7);
                dialogueIndicies[MOTHER] = 4;
                break;
            
            case 7:
                UpdateDay(8);
                for (int i = 0; i < completedTasks.Length && i < dialogueIndicies.Length; i++) {
                    if (completedTasks[i]) {
                        dialogueIndicies[i] = 6;
                    } else {
                        dialogueIndicies[i] = 5;
                    }
                }
                dialogueIndicies[MAYOR] = 2;
                // not in final scene
                dialogueIndicies[BESS] = 0;
                dialogueIndicies[KIERAN] = 0;
                dialogueIndicies[EWALD] = 0;
                dialogueIndicies[ROYCE] = 0;
                dialogueIndicies[NANCY] = 0;
                dialogueIndicies[ISAAC] = 0;
                dialogueIndicies[MOTHER] = 0;
                break;
            
            default:
                Debug.LogWarning("Something's wrong, the day is no longer the day, we must go back to the beginning.");
                UpdateDay(1);
                break;
        }
    }

    private void UpdateDay(int newDayNum) {
        Debug.Log("Starting day " + newDayNum);
        currentDay = newDayNum;
        taskManager.EmptyAllSlots();
        resetCharacterDialogueIndicies();
        resetWaitingForPotion();
        StartCoroutine(FadeToBlack("House"));
    }
    public IEnumerator FadeToBlack(string newScene) {
        fadeToBlack.Play("FadeIn");
        player.canMove = false;
        player.anim.SetBool("Walking", false);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(newScene);
        StartCoroutine(FadeFromBlack());
    }

    private IEnumerator FadeFromBlack() {
        fadeToBlack.Play("FadeOut");
        player.changePosition();
        yield return new WaitForSeconds(1);
        player.canMove = true;
    }

    public IEnumerator EndGame() {
        fadeToBlack.Play("FadeIn");
        player.canMove = false;
        player.anim.SetBool("Walking", false);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("House");
        rollCredits.Play("CreditsUp");       
    }

    public void Restart() {
        rollCredits.Play("CreditsStay");
        resetCompletedPotions();
        resetCharacterDialogueIndicies();
        resetWaitingForPotion();
        inventoryManager.Clear();
        currentDay = 1;
        dialogueIndicies[SERENA] = 1;
        dialogueIndicies[MOTHER] = 1;
        totalCompletedTasks = 0;
        SceneManager.LoadScene("House");
        player.sceneChange = 1;
        StartCoroutine(FadeFromBlack());
    }

    public void ExitGame() {
        Application.Quit();
    }
}
