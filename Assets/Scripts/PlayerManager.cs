using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public float moveSpeed = 4.0f;
    private Animator anim;
    private SpriteRenderer sprite;

    [Header("New Scene Positions")]
    [SerializeField] private Vector3 enterHousePos;
    [SerializeField] private Vector3 enterWoodsFromHousePos;
    [SerializeField] private Vector3 enterWoodsFromVillagePos;
    [SerializeField] private Vector3 enterVillagePos;


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
        if (col.gameObject.tag == "SceneChanger") {
            if (SceneManager.GetActiveScene().name == "House") {
                Debug.Log("Changing Scene from House to Forest");
                SceneManager.LoadScene("Forest");
                this.transform.position = enterWoodsFromHousePos;
            }
            
            if (SceneManager.GetActiveScene().name == "Forest") {
                if (col.gameObject.name == "HouseTrigger") {
                    Debug.Log("Changing Scene from Forest to House");
                    SceneManager.LoadScene("House");
                    this.transform.position = enterHousePos;
                }

                if (col.gameObject.name == "VillageTrigger") {
                    Debug.Log("Changing Scene from Forest to Village");
                    SceneManager.LoadScene("Village");
                    this.transform.position = enterVillagePos;
                }
            }

            if (SceneManager.GetActiveScene().name == "Village") {
                Debug.Log("Changing Scene from Village to Forest");
                SceneManager.LoadScene("Forest");
                this.transform.position = enterWoodsFromVillagePos;
            }
        }
    }
}
