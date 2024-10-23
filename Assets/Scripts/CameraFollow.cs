using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    private GameObject player;

    [Header("Boundaries")]
    [SerializeField] private float Xmin;
    [SerializeField] private float Xmax;
    [SerializeField] private float Ymin;
    [SerializeField] private float Ymax;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        transform.position = new Vector3(
                Mathf.Clamp(player.transform.position.x, Xmin, Xmax), 
                Mathf.Clamp(player.transform.position.y, Ymin, Ymax), -10); 
    }
}
