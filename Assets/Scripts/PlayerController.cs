using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 4.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move() {
        float hori = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * hori * moveSpeed * Time.deltaTime);

        float vert = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * vert * moveSpeed * Time.deltaTime);
    }
}
