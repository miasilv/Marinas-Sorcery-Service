using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public float moveSpeed = 4.0f;
    public Animator anim;
    private SpriteRenderer sprite;
    private StoryManager storyManager;
    public bool canMove;
    private int sceneChange = 0;
    private AudioManager audioManager;
    public AudioClip[] songs;
    public AudioClip[] walkingSounds;
    public bool inHouse;

    [Header("New Scene Positions")]
    [SerializeField] private Vector3 enterHousePos;
    [SerializeField] private Vector3 enterWoodsFromHousePos;
    [SerializeField] private Vector3 enterWoodsFromVillagePos;
    [SerializeField] private Vector3 enterVillagePos;


    void Start() {
        anim = gameObject.GetComponentInChildren<Animator>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        sprite = gameObject.GetComponentInChildren<SpriteRenderer>();
        storyManager = GameObject.FindWithTag("StoryManager").GetComponent<StoryManager>();
        canMove = true;
        inHouse = true;
    }

    // Update is called once per frame
    void Update() {
        if (canMove) {
            Move();
        }
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
            audioManager.StopWalking();
        } else {
            anim.SetBool("Walking", true);
            if (inHouse) {
                audioManager.PlayWalking(walkingSounds[0]);
            } 
            else {
                audioManager.PlayWalking(walkingSounds[1]);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "SceneChanger") {
            if (SceneManager.GetActiveScene().name == "House") {
                Debug.Log("Changing Scene from House to Forest");
                StartCoroutine(storyManager.FadeToBlack("Forest"));
                //this.transform.position = enterWoodsFromHousePos;
                inHouse = false;
                sceneChange = 0;
            }
            
            if (SceneManager.GetActiveScene().name == "Forest") {
                if (col.gameObject.name == "HouseTrigger") {
                    Debug.Log("Changing Scene from Forest to House");
                    StartCoroutine(storyManager.FadeToBlack("House"));
                    inHouse = true;
                    //this.transform.position = enterHousePos;
                    sceneChange = 1;
                }

                if (col.gameObject.name == "VillageTrigger") {
                    Debug.Log("Changing Scene from Forest to Village");
                    StartCoroutine(storyManager.FadeToBlack("Village"));
                    //this.transform.position = enterVillagePos;
                    inHouse = false;
                    sceneChange = 2;
                }
            }

            if (SceneManager.GetActiveScene().name == "Village") {
                Debug.Log("Changing Scene from Village to Forest");
                StartCoroutine(storyManager.FadeToBlack("Forest"));
                //this.transform.position = enterWoodsFromVillagePos;
                inHouse = false;
                sceneChange = 3;
            }
        }
    }
    public void changePosition() {
        switch(sceneChange) {
            case 0: 
                this.transform.position = enterWoodsFromHousePos;
                break;
            case 1:
                this.transform.position = enterHousePos;
                break;
            case 2:
                this.transform.position = enterVillagePos;
                audioManager.ChangeBackgroundMusic(songs[1]);
                break;
            case 3:
                this.transform.position = enterWoodsFromVillagePos;
                audioManager.ChangeBackgroundMusic(songs[0]);
                break;
            default:
                this.transform.position = enterHousePos;
                break;
        }
    }
}
