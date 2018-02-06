using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarInteraction : Interaction {

    [SerializeField]
    PlaceableObject ScrollOfWisdom; //Druid
    [SerializeField]
    PlaceableObject ScrollOfValiance; //Leviathan
    [SerializeField]
    PlaceableObject ScrollOfNature; //Veado
    [SerializeField]
    PlaceableObject ScrollOfLife; //Graveyard
    [SerializeField]
    HolleInteraction mainQuestInteraction;


    protected override void OnInteract()
    {
        if (mainQuestInteraction.State == 0)
        {
            mainQuestInteraction.AltarBeforeTalkingToHolle();
        }

        else if(mainQuestInteraction.State == 1)
        {
            TempleQuest.Scroll scroll = gameManager.placeAltarScroll();

            Debug.Log("Scroll " + scroll);
            switch (scroll)
            {
                case TempleQuest.Scroll.Wisdom:
                    PlaceScrollOfWisdom();
                    mainQuestInteraction.PlaceScrollInteraction(TempleQuest.Scroll.Wisdom.ToString());
                    break;
                case TempleQuest.Scroll.Valiance:
                    PlaceScrollOfValiance();
                    mainQuestInteraction.PlaceScrollInteraction(TempleQuest.Scroll.Valiance.ToString());
                    break;
                case TempleQuest.Scroll.Nature:
                    PlaceScrollOfNature();
                    mainQuestInteraction.PlaceScrollInteraction(TempleQuest.Scroll.Nature.ToString());
                    break;
                case TempleQuest.Scroll.Life:
                    PlaceScrollOfLife();
                    mainQuestInteraction.PlaceScrollInteraction(TempleQuest.Scroll.Life.ToString());
                    break;
                default:
                    mainQuestInteraction.NoScrollToPlace();
                    Debug.Log("No scroll to place");
                    break;

            }
        }
        else if(mainQuestInteraction.State == 2)
        {
            mainQuestInteraction.AltarAllScrolls();
        }   
    }



public void PlaceScrollOfWisdom()
    {
        ScrollOfWisdom.gameObject.SetActive(true);
    }

    public void PlaceScrollOfValiance()
    {
        ScrollOfValiance.gameObject.SetActive(true);
    }

    public void PlaceScrollOfNature()
    {
        ScrollOfNature.gameObject.SetActive(true);
    }

    public void PlaceScrollOfLife()
    {
        ScrollOfLife.gameObject.SetActive(true);
    }
}
