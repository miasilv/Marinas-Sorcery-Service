using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageManager : MonoBehaviour {
    [SerializeField] GameObject asa;
    [SerializeField] GameObject bess;
    [SerializeField] GameObject clarice;
    [SerializeField] GameObject dasha;
    [SerializeField] GameObject ewald;
    [SerializeField] GameObject isaac;
    [SerializeField] GameObject jessamine;
    [SerializeField] GameObject josan;
    [SerializeField] GameObject kieran;
    [SerializeField] GameObject mayor;
    [SerializeField] GameObject nancy;
    [SerializeField] GameObject royce;
    [SerializeField] GameObject serena;
    private StoryManager storyManager;
    void Start() {
        storyManager = GameObject.FindWithTag("StoryManager").GetComponent<StoryManager>();
        int currentDay = storyManager.currentDay;

        switch(currentDay) {
            case 1:
                TurnOffEverything()
                break;
            case 2:
                TurnOffEverything();
                asa.SetActive(true);
                ewald.SetActive(true);
                break;
            case 3:
                TurnOffEverything();
                mayor.SetActive(true);
                dasha.SetActive(true);
                josan.SetActive(true);
                break;
            case 4:
                TurnOffEverything();
                bess.SetActive(true);
                isaac.SetActive(true);
                clarice.SetActive(true);
                break;
            case 5:
                TurnOffEverything();
                royce.SetActive(true);
                nancy.SetActive(true);
                break;
            case 6:
                TurnOffEverything();
                mayor.SetActive(true);
                kieran.SetActive(true);
                jessamine.SetActive(true);
                break;
            case 7:
                TurnOffEverything();
                break;
            case 8: 
                TurnOffEverything();
                break;                
            default:
                TurnOffEverything();
                break;
        }
    }

    private void TurnOffEverything() {
        asa.SetActive(false);
        bess.SetActive(false);
        clarice.SetActive(false);
        dasha.SetActive(false);
        ewald.SetActive(false);
        isaac.SetActive(false);
        jessamine.SetActive(false);
        josan.SetActive(false);
        kieran.SetActive(false);
        mayor.SetActive(false);
        nancy.SetActive(false);
        royce.SetActive(false);
        serena.SetActive(false);
    }
}
