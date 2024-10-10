using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour {
    public TaskSlot[] taskSlot;
    
    public void Awake() {
        DeselectAllSlots();
    }
    
    public void AddTask(string taskName, string taskGiver, string taskDescription) {
        // look for an unfilled slot
        for (int i = 0; i < taskSlot.Length; i++) {
            if(!taskSlot[i].isFull) {
                taskSlot[i].AddTask(taskName, taskGiver, taskDescription);
                taskSlot[i].gameObject.SetActive(true);
                return;
            }
        }
    }
    
    public void DeselectAllSlots() {
        for (int i = 0; i < taskSlot.Length; i++) {
            taskSlot[i].selectedShader.SetActive(false);
            taskSlot[i].thisItemSelected = false;
        }
    }

    public void EmptyAllSlots() {
        for (int i = 0; i < taskSlot.Length; i++) {
            taskSlot[i].EmptySlot();
        }
    }
}
