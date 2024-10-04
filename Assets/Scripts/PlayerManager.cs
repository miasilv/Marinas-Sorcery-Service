using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public float moveSpeed = 4.0f;

    public 
    
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

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "SceneChanger") {
            Debug.Log("Changing Scene to Forest");
            SceneManager.LoadScene("Forest");
            this.transform.position = new Vector3(0,0,0);
        }
    }
}
