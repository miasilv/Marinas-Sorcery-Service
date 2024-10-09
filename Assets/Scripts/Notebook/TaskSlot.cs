using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TaskSlot : MonoBehaviour, IPointerClickHandler {
    //===========TASK DATA===========//
    public string taskName;
    public string taskGiver;
    public string taskDescription;
    public string taskIngredients;
    public bool isFull;

    //===========TASK SLOT===========//
    public TMP_Text taskSlotNameText;
    public TMP_Text taskSlotGiverText;

    //===========TASK DESCRIPTION INFO==========//
    public TMP_Text taskNameDescriptionText;
    public TMP_Text taskDescriptionText;
    public TMP_Text taskIngredientsDescriptionText;
    
    public GameObject selectedShader;
    public bool thisItemSelected;
    private TaskManager taskManager;

    private void Awake() {
        taskManager = GameObject.Find("NotebookCanvas").GetComponent<TaskManager>();
        gameObject.GetComponent<Image>().enabled = false;
    }

    public void AddTask(string taskName, string taskGiver, string taskDescription, string taskIngredients) {
        // updating task information
        this.taskName = taskName;
        this.taskGiver = taskGiver;
        this.taskDescription = taskDescription;
        this.taskIngredients = taskIngredients;

        // updating task slot
        gameObject.GetComponent<Image>().enabled = true;
        this.taskSlotNameText.text = this.taskName;
        this.taskSlotGiverText.text = "Task was given by " + taskGiver;
    }
    
    public void OnPointerClick(PointerEventData eventData) {
        // select an item and update the item description
        if (eventData.button == PointerEventData.InputButton.Left) {
            taskManager.DeselectAllSlots();
            selectedShader.SetActive(true);
            thisItemSelected = true;
            
        }

        taskNameDescriptionText.text = this.taskName;
        taskDescriptionText.text = this.taskDescription;
        taskIngredientsDescriptionText.text = this.taskIngredients;
    } 

    public void EmptySlot() {
        gameObject.GetComponent<Image>().enabled = false;
        this.taskName = "";
        this.taskGiver = "";
        this.taskDescription = "";
        this.taskIngredients = "";

        this.taskSlotNameText.text = "";
        this.taskSlotGiverText.text = "";

        this.taskNameDescriptionText.text = "";
        this.taskDescriptionText.text = "";
        this.taskIngredientsDescriptionText.text = "";
    }

}
