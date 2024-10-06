using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TaskSlot : MonoBehaviour {
    //===========TASK DATA===========//
    public string taskName;
    public string taskDescription;
    public string taskIngredients;
    public string taskDirections;
    public bool isFull;

    //===========TASK DESCRIPTION INFO==========//
    public TMP_Text taskNameText;
    public TMP_Text taskDescriptionText;
    public TMP_Text recipeIngredientsText;
    public TMP_Text recipeDirectionsText;

    
    public GameObject selectedShader;
    public bool thisItemSelected;
    private TaskManager taskManager;

    private void Awake() {
        taskManager = GameObject.Find("NotebookCanvas").GetComponent<TaskManager>();
    }

    public void OnPointerClick(PointerEventData eventData) {
        // select an item and update the item description
        if (eventData.button == PointerEventData.InputButton.Left) {
            taskManager.DeselectAllSlots();
            selectedShader.SetActive(true);
            thisItemSelected = true;
            
        }

        taskNameText = this.taskName;
        taskDescriptionText = this.taskDescription;
        recipeIngredientsText = this.recipeIngredients;
        recipeDirectionsText = this.recipeDirections;
    } 

}
