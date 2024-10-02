using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotebookManager : MonoBehaviour {
    //===========NOTEBOOK==========//
    [SerializeField] GameObject notebookMenu;
    private bool notebookActivated;

    //===========INVENTORY==========//
    private InventoryManager inventoryManager;
    [SerializeField] GameObject inventoryMenu;
    private bool inventoryActivated;

    //===========TASK==========//
    private TaskManager taskManager;
    [SerializeField] GameObject taskMenu;
    private bool taskActivated;

    void Awake() {
        // the notebook is closed
        notebookMenu.SetActive(false);
        notebookActivated = false;

        // the inventory is closed
        inventoryActivated = false;
        inventoryManager = GameObject.Find("NotebookCanvas").GetComponent<InventoryManager>();

        // the task is closed
        taskActivated = false;
        taskManager = GameObject.Find("NotebookCanvas").GetComponent<TaskManager>();

    }

    void Update() {
        // toggle inventory
        if (Input.GetButtonDown("Inventory") && !inventoryActivated) {
            ToggleNotebookOn();
            OpenInventory();
        } else if (Input.GetButtonDown("Inventory") && inventoryActivated) {
            ToggleNotebookOff();
        }

        // toggle task
        if (Input.GetButtonDown("Task") && !taskActivated) {
            ToggleNotebookOn();
            OpenTask();
        } else if (Input.GetButtonDown("Task") && taskActivated) {
            ToggleNotebookOff();
        }

        // switch Between the two
        if (notebookActivated) {
            if (inventoryActivated && Input.GetKeyDown(KeyCode.RightArrow)) {
                OpenTask();
            } else if (taskActivated && Input.GetKeyDown(KeyCode.LeftArrow)) {
                OpenInventory();
            }
        }
    }

    public void ToggleNotebookOn() {
        Time.timeScale = 0;
        notebookMenu.SetActive(true);
        notebookActivated = true;
    }

    public void ToggleNotebookOff() {
        Time.timeScale = 1;
        notebookMenu.SetActive(false);
        notebookActivated = false;
        inventoryActivated = false;
        taskActivated = false;
    }

    public void OpenInventory() {
        Debug.Log("Opening Inventory");
        // close other pages
        taskMenu.SetActive(false);
        taskActivated = false;

        // open inventory
        inventoryMenu.SetActive(true);
        inventoryActivated = true;
        inventoryManager.DeselectAllSlots();
    }

    public void OpenTask() {
        Debug.Log("Opening Task");
        // close other pages
        inventoryMenu.SetActive(false);
        inventoryActivated = false;

        // open task
        taskMenu.SetActive(true);
        taskActivated = true;
    }
}
