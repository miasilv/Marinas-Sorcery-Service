using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    // 0 - Player; 1 - NotebookManager; 2 - DialogueManager; 3 - Story Manager; 4 - Audio Manager
    private static GameObject[] persistentObjects = new GameObject[5];
    public int objectIndex;

    void Awake() {
        if(persistentObjects[objectIndex] == null) {
            persistentObjects[objectIndex] = gameObject;
            DontDestroyOnLoad(gameObject);
        }

        else if (persistentObjects[objectIndex] != gameObject) {
            Destroy(gameObject);
        }

    }
}
