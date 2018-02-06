using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YggdrasilQuest : Quest {


    public enum Rune { None, Urd, Verthandi, Skuld };

    [SerializeField]
    private int numberOfRunes = 3;
    [SerializeField]
    private bool runeOfUrd = false;
    [SerializeField]
    private bool runeOfVerthandi = false;
    [SerializeField]
    private bool runeOfSkuld = false;
    private int placedRunes = 0;

    // Use this for initialization
    void Start()
    {
        Finish = false;
        State = 0;
    }

    protected override bool OnComplete(int curr_value)
    {
        if (curr_value >= numberOfRunes)
            return true;

        return false;
    }

    public void newRune(Rune rune)
    {
        switch (rune)
        {
            case Rune.Urd:
                runeOfUrd = true;
                break;

            case Rune.Verthandi:
                runeOfVerthandi = true;
                break;

            case Rune.Skuld:
                runeOfSkuld = true;
                break;

            default:
                Debug.Log("Unknown rune.");
                break;
        }
    }

    public Rune hasRuneToPlace()
    {
        if (runeOfUrd)
            return Rune.Urd;

        if (runeOfVerthandi)
            return Rune.Verthandi;

        if (runeOfSkuld)
            return Rune.Skuld;

        return Rune.None;
    }

    public void placeRune(Rune rune)
    {
        switch (rune)
        {
            case Rune.Urd:
                runeOfUrd = false;
                placedRunes++;
                Debug.Log("Palce" + placedRunes);
                break;

            case Rune.Verthandi:
                runeOfVerthandi = false;
                placedRunes++;
                break;

            case Rune.Skuld:
                runeOfSkuld = false;
                placedRunes++;
                break;

            default:
                Debug.Log("Cannot place this rune.");
                break;
        }
    }

    public bool allRunesPlaced()
    {
        Debug.Log("place " + placedRunes + " " + numberOfRunes);
        if (placedRunes == numberOfRunes)
            return true;

        return false;
    }
}
