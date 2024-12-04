using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PotionManager : MonoBehaviour {
    public PotionSlot[] potionSlot;
    
    [Header("Crystals")]
    [SerializeField] Item amethyst;
    [SerializeField] Item blueAgate;
    [SerializeField] Item myrianQuartz;
    [SerializeField] Item pinkTopaz;

    [Header("Other")]
    [SerializeField] Item blueberry;
    [SerializeField] Item honey;
    [SerializeField] Item moss;
    [SerializeField] Item torianDust;
    [SerializeField] Item willardRoot;

    [Header("Feathers")]
    [SerializeField] Item hummingbirdFeather;
    [SerializeField] Item owlFeather;
    [SerializeField] Item ravenFeather;
    [SerializeField] Item robinFeather;

    [Header("Flowers")]
    [SerializeField] Item carnation;
    [SerializeField] Item daisy;
    [SerializeField] Item lavender;
    [SerializeField] Item lilyOfTheLake;
    [SerializeField] Item marigold;
    [SerializeField] Item orchid;
    [SerializeField] Item peony;
    [SerializeField] Item primrose;
    [SerializeField] Item rose;

    [Header("Frogs")]
    [SerializeField] Item highlandBellFrog;
    [SerializeField] Item moonFrog;
    [SerializeField] Item seerianFrog;

    [Header("Metals")]
    [SerializeField] Item gold;
    [SerializeField] Item iridium;
    [SerializeField] Item silverstone;
    [SerializeField] Item starlite;

    [Header("Spiders")]
    [SerializeField] Item devilsBiteSpider;
    [SerializeField] Item longLegSpider;
    [SerializeField] Item tarantula;
    public TMP_Text potionIngredientsHeaderText;
    
    public void Awake() {
        DeselectAllSlots();

        Dictionary<Item, int> aegoria = new Dictionary<Item, int>();
        aegoria.Add(devilsBiteSpider, 1);
        aegoria.Add(ravenFeather, 1);  
        aegoria.Add(blueAgate, 1);
        aegoria.Add(torianDust, 1);
        AddPotion("Aegoria", "Not much is known about this concoction. It’s believed to have started out as a simple tincture. Over the years other witches have added their own touches to the recipe, enhancing its effectiveness.", aegoria);
        
        Dictionary<Item, int> blueberrySyrup = new Dictionary<Item, int>();
        blueberrySyrup.Add(blueberry, 1);
        blueberrySyrup.Add(rose, 1);  
        AddPotion("Blueberry Syrup", "A sweet, thick blue syrup.", blueberrySyrup);
        
        Dictionary<Item, int> cipheriam = new Dictionary<Item, int>();
        cipheriam.Add(hummingbirdFeather, 1);
        cipheriam.Add(rose, 1);  
        cipheriam.Add(silverstone, 1);
        AddPotion("Cipheriam", "A small vial containing a vivid red liquid. Just a dollop on the tongue can give someone the pipes of a renowned opera singer. Best used temporarily lest one endangers their vocal cords for good.", cipheriam);
        
        Dictionary<Item, int> courinder = new Dictionary<Item, int>();
        courinder.Add(primrose, 1);
        courinder.Add(willardRoot, 1);  
        courinder.Add(peony, 1);
        courinder.Add(longLegSpider, 1);
        AddPotion("Courinder", "Its light blue color may deter others at first glance but this concoction gives one the agility and speed needed for any long term exercise. Commonly given to horses, not recommended for any long term usages.", courinder);

        Dictionary<Item, int> heillar = new Dictionary<Item, int>();
        heillar.Add(orchid, 1);
        heillar.Add(marigold, 1);  
        heillar.Add(starlite, 1);
        heillar.Add(moss, 1);
        AddPotion("Heillar", "A soothing medicine. Helps with muscle pains and tense, old bones. Can be consumed but some find it more beneficial to spread this orange potion onto their skin for faster effects.", heillar);
    
        Dictionary<Item, int> heillus = new Dictionary<Item, int>();
        heillus.Add(silverstone, 1);
        heillus.Add(robinFeather, 1);  
        heillus.Add(highlandBellFrog, 1);
        heillus.Add(seerianFrog, 1);
        AddPotion("Heillus", "A dark, viscous potion. Rough down the throat and better followed by a glass of water. Alleviates any coughing fits or furious sneezes. Commonly used for flimsy colds in the winter.", heillus);
        
        Dictionary<Item, int> honeyDrink = new Dictionary<Item, int>();
        honeyDrink.Add(honey, 1);
        AddPotion("Honey Drink", "A simple sweet drink.", honeyDrink);
        
        Dictionary<Item, int> memoria = new Dictionary<Item, int>();
        memoria.Add(iridium, 1);
        memoria.Add(pinkTopaz, 1);  
        memoria.Add(ravenFeather, 1);
        memoria.Add(moss, 1);
        AddPotion("Memoria", "A dark brown brew. Gives a brightened, calmer mind and eases the thoughts allowing for increased motor skills, enhanced memory, and improved intelligence.", memoria);
        
        Dictionary<Item, int> pervivious = new Dictionary<Item, int>();
        pervivious.Add(gold, 1);
        pervivious.Add(tarantula, 1);  
        pervivious.Add(peony, 1);
        pervivious.Add(daisy, 1);
        AddPotion("Pervivious", "A light pink potion, Smells like fresh flowers blooming in Spring. Dipping flowers into this elixir will cause a slight permanent glow. Not recommended for digestion, the sourness will cause irritation.", pervivious);
        
        Dictionary<Item, int> somnias = new Dictionary<Item, int>();
        somnias.Add(owlFeather, 1);
        somnias.Add(starlite, 1);  
        somnias.Add(amethyst, 1);
        somnias.Add(moonFrog, 1);
        AddPotion("Somnias", "A calming potion. Some mothers find it most useful for small children and infants to dream easily. The pale glittering elixir resembles night clouds in the starry sky.", somnias);
        
        Dictionary<Item, int> victamis = new Dictionary<Item, int>();
        victamis.Add(robinFeather, 1);
        victamis.Add(moss, 1);  
        victamis.Add(moonFrog, 1);
        victamis.Add(primrose, 1);
        AddPotion("Victamis", "A vibrant green elixir, a staple for those in need of a quick solution to dried up crops and arid soil. Instantaneous and safe to use around animal life.", victamis);
        
        Dictionary<Item, int> viennallis = new Dictionary<Item, int>();
        viennallis.Add(blueAgate, 1);
        viennallis.Add(willardRoot, 1);  
        viennallis.Add(lavender, 1);
        viennallis.Add(carnation, 1);
        AddPotion("Viennallis", "As clear as water from a mountain spring. Some say drinking this refreshing potion heightens their senses giving them a clear head and clearer sight to continue their day.", viennallis);

        Dictionary<Item, int> visamir = new Dictionary<Item, int>();
        visamir.Add(starlite, 1);
        visamir.Add(ravenFeather, 1);  
        visamir.Add(lilyOfTheLake, 1);
        visamir.Add(myrianQuartz, 1);
        AddPotion("Visamir", "An electrifying, energizing potion. Not to be taken in large quantities and shouldn’t be taken repeatedly. Its black sludge appearance matches its less than ideal taste.", visamir);
    
    }
    
    public void AddPotion(string potionName, string potionDescription, Dictionary<Item, int> potionIngredients) {
        // look for an unfilled slot
        for (int i = 0; i < potionSlot.Length; i++) {
            if(!potionSlot[i].isFull) {
                potionSlot[i].AddPotion(potionName, potionDescription, potionIngredients);
                return;
            }
        }
    }
    
    public void DeselectAllSlots() {
        for (int i = 0; i < potionSlot.Length; i++) {
            potionSlot[i].selectedShader.SetActive(false);
            potionSlot[i].thisItemSelected = false;
            potionSlot[i].DeselctSlot();
        }
        potionIngredientsHeaderText.enabled = false;
    }
}
