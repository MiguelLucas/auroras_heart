using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleQuest : Quest
{
    public enum Scroll { None, Wisdom, Valiance, Nature, Life};

    [SerializeField]
    private int numberOfScrolls = 4;
    [SerializeField]
    private bool scrollOfWisdom = false;
    [SerializeField]
    private bool scrollOfValiance = false;
    [SerializeField]
    private bool scrollOfNature = false;
    [SerializeField]
    private bool scrollOfLife = false;
    private int placedScrolls = 0;

    // Use this for initialization
    void Start()
    {

        Finish = false;
        State = 0;

    }

    protected override bool OnComplete(int curr_value)
    {
        if (curr_value >= numberOfScrolls)
            return true;

        return false;
    }

    public Scroll hasScrollToPlace()
    {
        if (scrollOfWisdom)
            return Scroll.Wisdom;

        if (scrollOfValiance)
            return Scroll.Valiance;

        if (scrollOfNature)
            return Scroll.Nature;

        if (scrollOfLife)
            return Scroll.Life;

        return Scroll.None;
    }

    public void placeScroll(Scroll scroll)
    {
        switch (scroll)
        {
            case Scroll.Wisdom:
                scrollOfWisdom = false;
                placedScrolls++;
                break;

            case Scroll.Valiance:
                scrollOfValiance = false;
                placedScrolls++;
                break;

            case Scroll.Nature:
                scrollOfNature = false;
                placedScrolls++;
                break;

            case Scroll.Life:
                scrollOfLife = false;
                placedScrolls++;
                break;

            default:
                Debug.Log("Cannot place this scroll.");
                break;
        }
    }

    public bool allScrollsPlaced()
    {
        if (placedScrolls == numberOfScrolls)
            return true;

        return false;
    }
}
