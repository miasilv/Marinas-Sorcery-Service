using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public float moveSpeed = 4.0f;

    private Animator anim;
    private SpriteRenderer sprite;

    public Vector3 enterHousePos;

    public Vector3 enterWoodsPos;

    void Start() {
        anim = gameObject.GetComponentInChildren<Animator>();
        sprite = gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    public void Move() {
        float hori = Input.GetAxis("Horizontal");
        if (hori > 0) {
            sprite.flipX = true;
            transform.Translate(Vector3.right * hori * moveSpeed * Time.deltaTime);
        }
        else if (hori < 0) {
            sprite.flipX = false;
            transform.Translate(Vector3.right * hori * moveSpeed * Time.deltaTime);
        }

        float vert = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * vert * moveSpeed * Time.deltaTime);

        if (vert == 0 && hori == 0) {
            anim.SetBool("Walking", false);
        } else {
            anim.SetBool("Walking", true);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "SceneChanger" && SceneManager.GetActiveScene().name == "House") {
            Debug.Log("Changing Scene to Forest");
            SceneManager.LoadScene("Forest");
            this.transform.position = enterWoodsPos;
        }
    }

    void OnTriggerStay2D(Collider2D col) {
        // should change this mechanic
        if (col.gameObject.tag == "SceneChanger" && SceneManager.GetActiveScene().name == "Forest" && Input.GetButtonDown("Jump")) {
            Debug.Log("Changing Scene to House");
            SceneManager.LoadScene("House");
            this.transform.position = enterHousePos;
        }
    }
}
