using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageManager : MonoBehaviour {
    [SerializeField] GameObject mayor;
    [SerializeField] GameObject asa;
    [SerializeField] GameObject dasha;
    [SerializeField] GameObject josan;
    [SerializeField] GameObject ewald;
    private StoryManager storyManager;
    void Start() {
        storyManager = GameObject.FindWithTag("StoryManager").GetComponent<StoryManager>();
        int currentDay = storyManager.currentDay;

        switch(currentDay) {
            case 1:
                mayor.SetActive(false);
                asa.SetActive(false);
                dasha.SetActive(false);
                josan.SetActive(false);
                ewald.SetActive(false);
                break;
            case 2:
                mayor.SetActive(false);
                asa.SetActive(true);
                dasha.SetActive(false);
                josan.SetActive(false);
                ewald.SetActive(true);
                break;
            case 3:
                mayor.SetActive(true);
                asa.SetActive(false);
                dasha.SetActive(true);
                josan.SetActive(true);
                ewald.SetActive(false);
                break;
            default:
                mayor.SetActive(true);
                asa.SetActive(true);
                dasha.SetActive(true);
                josan.SetActive(true);
                ewald.SetActive(true);
                break;
        }
    }
}
