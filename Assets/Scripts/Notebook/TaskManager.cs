using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour {

    public void AddTask(string taskName, string taskDescription, string recipeDirections, string recipeIngredients) {
        // look for an unfilled slot
        for (int i = 0; i < taskSlot.Length; i++) {
            if(!itemSlot[i].isFull) {
                itemSlot[i] = AddItem(taskName, taskDescription, recipeDirections, recipeIngredients);
            }
        }
    }
    public void DeselectAllSlots() {
        for (int i = 0; i < itemSlot.Length; i++) {
            taskSlot[i].selectedShader.SetActive(false);
            taskSlot[i].thisItemSelected = false;
        }
    }
}
