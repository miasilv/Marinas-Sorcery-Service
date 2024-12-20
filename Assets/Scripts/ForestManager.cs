using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestManager : MonoBehaviour
{
    [Header("NPCs")]
    [SerializeField] GameObject asa;
    [SerializeField] GameObject clarice;
    [SerializeField] GameObject dasha;
    [SerializeField] GameObject jessamine;
    [SerializeField] GameObject josan;
    [SerializeField] GameObject mayor;
    [SerializeField] GameObject serena;

    [Header("Crystals")]
    [SerializeField] GameObject amethyst;
    [SerializeField] GameObject blueAgate;
    [SerializeField] GameObject myrianQuartz;
    [SerializeField] GameObject pinkTopaz;

    [Header("Other")]
    [SerializeField] GameObject blueberry;
    [SerializeField] GameObject moss;
    [SerializeField] GameObject torianDust;
    [SerializeField] GameObject willardRoot;

    [Header("Feathers")]
    [SerializeField] GameObject hummingbirdFeather;
    [SerializeField] GameObject owlFeather;
    [SerializeField] GameObject ravenFeather;
    [SerializeField] GameObject robinFeather;

    [Header("Flowers")]
    [SerializeField] GameObject carnation;
    [SerializeField] GameObject daisy;
    [SerializeField] GameObject lavender;
    [SerializeField] GameObject lilyOfTheLake;
    [SerializeField] GameObject marigold;
    [SerializeField] GameObject orchid;
    [SerializeField] GameObject peony;
    [SerializeField] GameObject primrose;
    [SerializeField] GameObject rose;

    [Header("Frogs")]
    [SerializeField] GameObject highlandBellFrog;
    [SerializeField] GameObject moonFrog;
    [SerializeField] GameObject seerianFrog;

    [Header("Metals")]
    [SerializeField] GameObject gold;
    [SerializeField] GameObject iridium;
    [SerializeField] GameObject silverstone;
    [SerializeField] GameObject starlite;

    [Header("Spiders")]
    [SerializeField] GameObject devilsBiteSpider;
    [SerializeField] GameObject longLegSpider;
    [SerializeField] GameObject tarantula;
    
    private StoryManager storyManager;
    void Start() {
        storyManager = GameObject.FindWithTag("StoryManager").GetComponent<StoryManager>();
        int currentDay = storyManager.currentDay;

        switch(currentDay) {
            case 1:
                TurnOffEverything();

                serena.SetActive(true);

                moss.SetActive(true);
                primrose.SetActive(true);
                robinFeather.SetActive(true);
                moonFrog.SetActive(true);

                break;
                
            case 2:
                TurnOffEverything();

                robinFeather.SetActive(true);
                moonFrog.SetActive(true);
    
                primrose.SetActive(true);
                willardRoot.SetActive(true);
                peony.SetActive(true);
                longLegSpider.SetActive(true);

                orchid.SetActive(true);
                marigold.SetActive(true);
                starlite.SetActive(true);
                moss.SetActive(true);

                break;

            case 3:
                TurnOffEverything();

                robinFeather.SetActive(true);
                willardRoot.SetActive(true);
                peony.SetActive(true);
                longLegSpider.SetActive(true);
                orchid.SetActive(true);
                marigold.SetActive(true);
                
                starlite.SetActive(true);
                ravenFeather.SetActive(true);
                lilyOfTheLake.SetActive(true);
                myrianQuartz.SetActive(true);

                owlFeather.SetActive(true);
                starlite.SetActive(true);
                amethyst.SetActive(true);
                moonFrog.SetActive(true);

                break;
            
            case 4:
                TurnOffEverything();

                longLegSpider.SetActive(true);
                orchid.SetActive(true);
                marigold.SetActive(true); 
                ravenFeather.SetActive(true);
                lilyOfTheLake.SetActive(true);
                myrianQuartz.SetActive(true);
                owlFeather.SetActive(true);
                amethyst.SetActive(true);

                hummingbirdFeather.SetActive(true);
                rose.SetActive(true);
                silverstone.SetActive(true);
                
                // honey

                blueAgate.SetActive(true);
                willardRoot.SetActive(true);
                lavender.SetActive(true);
                carnation.SetActive(true);

                break;

            case 5:
                TurnOffEverything();
                
                lilyOfTheLake.SetActive(true);
                myrianQuartz.SetActive(true);
                owlFeather.SetActive(true);
                amethyst.SetActive(true);
                rose.SetActive(true);
                blueAgate.SetActive(true);
                willardRoot.SetActive(true);
                lavender.SetActive(true);
                carnation.SetActive(true);

                silverstone.SetActive(true);
                robinFeather.SetActive(true);
                highlandBellFrog.SetActive(true);
                seerianFrog.SetActive(true);

                gold.SetActive(true);
                tarantula.SetActive(true);
                peony.SetActive(true);
                daisy.SetActive(true);

                break;

            case 6:
                TurnOffEverything();

                silverstone.SetActive(true);
                robinFeather.SetActive(true);
                highlandBellFrog.SetActive(true);
                seerianFrog.SetActive(true);
                gold.SetActive(true);
                tarantula.SetActive(true);
                peony.SetActive(true);
                daisy.SetActive(true);

                rose.SetActive(true);
                blueberry.SetActive(true);

                iridium.SetActive(true);
                pinkTopaz.SetActive(true);
                ravenFeather.SetActive(true);
                moss.SetActive(true);

                break;

            case 7:
                TurnOffEverything();

                silverstone.SetActive(true);
                robinFeather.SetActive(true);
                highlandBellFrog.SetActive(true);
                seerianFrog.SetActive(true);
                gold.SetActive(true);
                tarantula.SetActive(true);
                peony.SetActive(true);
                daisy.SetActive(true);
                rose.SetActive(true);
                blueberry.SetActive(true);
                iridium.SetActive(true);
                pinkTopaz.SetActive(true);
                ravenFeather.SetActive(true);
                moss.SetActive(true);

                devilsBiteSpider.SetActive(true);
                ravenFeather.SetActive(true);
                blueAgate.SetActive(true);
                torianDust.SetActive(true);

                break;

            case 8:
                TurnOffEverything();

                asa.SetActive(true);
                clarice.SetActive(true);
                dasha.SetActive(true);
                jessamine.SetActive(true);
                josan.SetActive(true);
                mayor.SetActive(true);
                serena.SetActive(true);

                break;
            
            default:
                TurnOffEverything();
                break;
        }
    }

    private void TurnOffEverything() {
        asa.SetActive(false);
        clarice.SetActive(false);
        dasha.SetActive(false);
        jessamine.SetActive(false);
        josan.SetActive(false);
        mayor.SetActive(false);
        serena.SetActive(false);

        amethyst.SetActive(false);
        blueAgate.SetActive(false);
        myrianQuartz.SetActive(false);
        pinkTopaz.SetActive(false);
        
        blueberry.SetActive(false);
        moss.SetActive(false);
        torianDust.SetActive(false);
        willardRoot.SetActive(false);

        hummingbirdFeather.SetActive(false);
        owlFeather.SetActive(false);
        ravenFeather.SetActive(false);
        robinFeather.SetActive(false);

        carnation.SetActive(false);
        daisy.SetActive(false);
        lavender.SetActive(false);
        lilyOfTheLake.SetActive(false);
        marigold.SetActive(false);
        orchid.SetActive(false);
        peony.SetActive(false);
        primrose.SetActive(false);
        rose.SetActive(false);

        highlandBellFrog.SetActive(false);
        moonFrog.SetActive(false);
        seerianFrog.SetActive(false);

        gold.SetActive(false);
        iridium.SetActive(false);
        silverstone.SetActive(false);
        starlite.SetActive(false);

        devilsBiteSpider.SetActive(false);
        longLegSpider.SetActive(false);
        tarantula.SetActive(false);
    }
}
