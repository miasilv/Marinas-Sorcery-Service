using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpoonMovement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    private int lowerXBound;
    private int upperXBound;
    private int yPos;
    private bool clicked;
    
    void Start() {
        lowerXBound = 1150;
        upperXBound = 1655;
        yPos = 680;

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
        Debug.Log("clicking"); 
    }

    public void OnPointerUp(PointerEventData eventData) {
        clicked = false; 
        Debug.Log("not clicking");
    } 
}
