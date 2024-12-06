using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpoonMovement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    private float lowerXBound;
    private float upperXBound;
    private float yPos;
    private bool clicked;
    
    void Start() {
        lowerXBound = Screen.width * 0.6f;
        upperXBound = Screen.width * 0.86f;
        yPos = Screen.height * 0.63f;

        clicked = false;
    }

    void Update() {
        if (clicked) {
            transform.position = new Vector3(
                Mathf.Clamp(Input.mousePosition.x, lowerXBound, upperXBound), 
                yPos, 0); 
        }    
    }

    public void OnPointerDown(PointerEventData eventData) {
        clicked = true;
    }

    public void OnPointerUp(PointerEventData eventData) {
        clicked = false; 
    } 
}
