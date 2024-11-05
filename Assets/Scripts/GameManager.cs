using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    // ============ Managers ================
    private TaskManager taskManager;

    // ============ Game Status ================
    public int currentDay;
    public int tasksComplete;

    // ============ Constants ================
    private const int NUM_OF_DAY1_TASKS = 1;
    private const int NUM_OF_DAY2_TASKS = 3;

    // ======= Dialogue Triggers ================
    [Header("NPC Dialogue Triggers")]
    [SerializeField] private DialogueTrigger motherDT;
    
    

    void Start() {
        taskManager = GameObject.Find("NotebookCanvas").GetComponent<TaskManager>();
        currentDay = 1;
        tasksComplete = 0;
        
        StartDay1();
    }

    // Update is called once per frame
    void Update() {
        switch (currentDay) {
            case 1:
                // Insert stuff here 
                break;
            case 2:
                // Insert stuff here
                break;
            default:
                Debug.LogWarning("No valid day found");
                break;
        }
        
    }

    private void StartDay1() {
        currentDay = 1;
        tasksComplete = 0;

    }

    private void StartDay2() {
        currentDay = 2;
        tasksComplete = 0;
        
    }

    public void finishedTask() {
        tasksComplete++;
        if (tasksComplete == NUM_OF_DAY1_TASKS) {
            StartDay2();
        } else if (tasksComplete == NUM_OF_DAY2_TASKS) {
            // start day 3
        }
    }

    public void ClearDayTasks() {
        taskManager.EmptyAllSlots();
    }
}
