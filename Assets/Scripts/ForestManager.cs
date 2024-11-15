using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestManager : MonoBehaviour
{
    [SerializeField] GameObject serena;
    [SerializeField] GameObject willardRoot;
    [SerializeField] GameObject moonFrog;
    [SerializeField] GameObject lilyOfTheLake;
    [SerializeField] GameObject primrose;
    [SerializeField] GameObject orchid;
    [SerializeField] GameObject peony;
    [SerializeField] GameObject marigold;
    [SerializeField] GameObject moss;
    [SerializeField] GameObject starlite;
    [SerializeField] GameObject myrianQuartz;
    [SerializeField] GameObject amethyst;
    [SerializeField] GameObject longLegSpider;
    [SerializeField] GameObject ravenFeather;
    [SerializeField] GameObject owlFeather;
    [SerializeField] GameObject robinFeather;
    private StoryManager storyManager;
    void Start() {
        storyManager = GameObject.FindWithTag("StoryManager").GetComponent<StoryManager>();
        int currentDay = storyManager.currentDay;

        switch(currentDay) {
            case 1:
                serena.SetActive(true);

                moss.SetActive(true);
                primrose.SetActive(true);
                robinFeather.SetActive(true);
                moonFrog.SetActive(true);

                willardRoot.SetActive(false);
                peony.SetActive(false);
                longLegSpider.SetActive(false);
                orchid.SetActive(false);
                marigold.SetActive(false);
                starlite.SetActive(false);
                ravenFeather.SetActive(false);
                lilyOfTheLake.SetActive(false);
                myrianQuartz.SetActive(false);
                owlFeather.SetActive(false);
                starlite.SetActive(false);
                amethyst.SetActive(false);
                break;
            case 2:
                serena.SetActive(false);

                primrose.SetActive(true);
                willardRoot.SetActive(true);
                peony.SetActive(true);
                longLegSpider.SetActive(true);

                orchid.SetActive(true);
                marigold.SetActive(true);
                starlite.SetActive(true);
                moss.SetActive(true);

                robinFeather.SetActive(false);
                moonFrog.SetActive(false);
                ravenFeather.SetActive(false);
                lilyOfTheLake.SetActive(false);
                myrianQuartz.SetActive(false);
                owlFeather.SetActive(false);
                amethyst.SetActive(false);
                break;
            case 3:
                serena.SetActive(false);
                
                starlite.SetActive(true);
                ravenFeather.SetActive(true);
                lilyOfTheLake.SetActive(true);
                myrianQuartz.SetActive(true);

                owlFeather.SetActive(true);
                starlite.SetActive(true);
                amethyst.SetActive(true);
                moonFrog.SetActive(true);

                moss.SetActive(false);
                primrose.SetActive(false);
                robinFeather.SetActive(false);
                willardRoot.SetActive(false);
                peony.SetActive(false);
                longLegSpider.SetActive(false);
                orchid.SetActive(false);
                marigold.SetActive(false);
                break;
            default:
                serena.SetActive(false);

                ravenFeather.SetActive(true);
                lilyOfTheLake.SetActive(true);
                myrianQuartz.SetActive(true);
                owlFeather.SetActive(true);
                amethyst.SetActive(true);
                willardRoot.SetActive(true);
                peony.SetActive(true);
                longLegSpider.SetActive(true);
                orchid.SetActive(true);
                marigold.SetActive(true);
                starlite.SetActive(true);
                moss.SetActive(true);
                primrose.SetActive(true);
                robinFeather.SetActive(true);
                moonFrog.SetActive(true);
                break;
        }
    }
}
