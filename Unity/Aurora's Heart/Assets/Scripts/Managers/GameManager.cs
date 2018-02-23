using AC.TimeOfDaySystemFree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    [SerializeField]
    private int spirits;
    [SerializeField]
    private int mushrooms;
    [SerializeField]
    private int runes;
    [SerializeField]
    private int scrolls;
    [SerializeField]
    private LeviathanQuest leviathanQuest;
    [SerializeField]
    private DruidQuest druidQuest;
    [SerializeField]
    private TempleQuest templeQuest;
    [SerializeField]
    private YggdrasilQuest yggdrasilQuest;
    [SerializeField]
    private int currentScene = 1;
    [SerializeField]
    private TimeOfDay timeOfDay;

    public int Spirits
    {
        get
        {
            return spirits;
        }

        set
        {
            spirits = value;
        }
    }

    public int Mushrooms
    {
        get
        {
            return mushrooms;
        }

        set
        {
            mushrooms = value;
        }
    }

    public int Runes
    {
        get
        {
            return runes;
        }

        set
        {
            runes = value;
        }
    }

    public int Scrolls
    {
        get
        {
            return scrolls;
        }

        set
        {
            scrolls = value;
        }
    }

    public int CurrentScene {
        get {
            return currentScene;
        }

        set {
            currentScene = value;
        }
    }

    private void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(this.currentScene == 1) //Cave
        {
            timeOfDay.timeline = 0;
        }
    }
 
    public bool CompleteLeviathan()
    {
        return leviathanQuest.Complete(spirits);
    }

    public void RemoveLeviathanBarriers()
    {
        leviathanQuest.RemoveBridgeBarriers();
    }

    public void GiveRewardLeviathan()
    {
        runes++;
        yggdrasilQuest.newRune (leviathanQuest.runeReward());


    }

    public bool CompleteDruid()
    {
        return druidQuest.Complete(mushrooms);
    }

    public void RemoveDruidBarriers()
    {
        druidQuest.RemoveCaveBarrier();
    }

    public TempleQuest.Scroll placeAltarScroll()
    {
        TempleQuest.Scroll scroll = templeQuest.hasScrollToPlace();
        templeQuest.placeScroll(scroll);

        return scroll;
    }

    public bool AllScrollsPlaced()
    {
        
        return templeQuest.allScrollsPlaced();
    }

    public YggdrasilQuest.Rune placeYggdrasilRune()
    {
        YggdrasilQuest.Rune rune = yggdrasilQuest.hasRuneToPlace();
        yggdrasilQuest.placeRune(rune);

        return rune;
    }

    public bool AllRunesPlaced()
    {

        return yggdrasilQuest.allRunesPlaced();
    }

    public void CaveReward()
    {
        runes++;
        yggdrasilQuest.newRune(YggdrasilQuest.Rune.Skuld);
    }
}
