using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotebookManager : MonoBehaviour {
    //===========NOTEBOOK==========//
    [SerializeField] GameObject notebookMenu;
    [SerializeField] GameObject notebookIcon;
    [SerializeField] GameObject closeIcon;
    private bool notebookActivated;

    //===========INVENTORY==========//
    private InventoryManager inventoryManager;
    [SerializeField] GameObject inventoryMenu;
    private bool inventoryActivated;

    //===========TASK==========//
    private TaskManager taskManager;
    [SerializeField] GameObject taskMenu;
    private bool taskActivated;
    
    //===========POTION==========//
    private PotionManager potionManager;
    [SerializeField] GameObject potionMenu;
    private bool potionActivated;

    private PlayerManager player;
    private AudioManager audioManager;
    [SerializeField] AudioClip singlePage;
    [SerializeField] AudioClip multiPage;

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

        // the potion is closed
        potionActivated = false;
        potionManager = GameObject.Find("NotebookCanvas").GetComponent<PotionManager>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    void Update() {
        // turn on notebooks
        if (Input.GetButtonDown("Inventory") && !inventoryActivated) {
            ToggleNotebookOn();
            OpenInventory();
        }

        if (Input.GetButtonDown("Task") && !taskActivated) {
            ToggleNotebookOn();
            OpenTask();
        }

        if (Input.GetButtonDown("Potion") && !potionActivated) {
            ToggleNotebookOn();
            OpenPotion();
        }

        // switch Between the two using arrow keys
        if (notebookActivated) {
            if (inventoryActivated && Input.GetKeyDown(KeyCode.RightArrow)) {
                OpenTask();
            } else if (taskActivated && Input.GetKeyDown(KeyCode.LeftArrow)) {
                OpenInventory();
            } else if (taskActivated && Input.GetKeyDown(KeyCode.RightArrow)) {
                OpenPotion();
            }

            if (Input.GetButtonDown("Cancel")) {
                ToggleNotebookOff();
            }
        }
    }

    public void ToggleNotebookOn() {
        if (!notebookActivated) {
            audioManager.PlayUI2(multiPage);
        }
        Time.timeScale = 0;
        notebookMenu.SetActive(true);
        player.canMove = false;
        notebookIcon.SetActive(false);
        closeIcon.SetActive(true);
        notebookActivated = true;
    }

    public void ToggleNotebookOff() {
        audioManager.PlayUI2(multiPage);
        Time.timeScale = 1;
        notebookMenu.SetActive(false);
        notebookActivated = false;
        inventoryActivated = false;
        taskActivated = false;
        potionActivated = false;
        player.canMove = true;
        notebookIcon.SetActive(true);
        closeIcon.SetActive(false);
    }

    public void OpenInventory() {
        Debug.Log("Opening Inventory");
        // close other pages
        taskMenu.SetActive(false);
        taskActivated = false;
        potionMenu.SetActive(false);
        potionActivated = false;

        // open inventory
        inventoryMenu.SetActive(true);
        inventoryActivated = true;
        inventoryManager.DeselectAllSlots();
        
        if (notebookActivated) {
            audioManager.PlayUI2(singlePage);
        }
    }

    public void OpenTask() {
        Debug.Log("Opening Task");
        // close other pages
        inventoryMenu.SetActive(false);
        inventoryActivated = false;
        potionMenu.SetActive(false);
        potionActivated = false;

        // open task
        taskMenu.SetActive(true);
        taskActivated = true;
        taskManager.DeselectAllSlots();

        if (notebookActivated) {
            audioManager.PlayUI2(singlePage);
        }
    }

    public void OpenPotion() {
        Debug.Log("Opening Potion");
        // close other pages
        inventoryMenu.SetActive(false);
        inventoryActivated = false;
        taskMenu.SetActive(false);
        taskActivated = false;


        // open potion
        potionMenu.SetActive(true);
        potionActivated = true;
        potionManager.DeselectAllSlots();

        if (notebookActivated) {
            audioManager.PlayUI2(singlePage);
        }
    }
}
