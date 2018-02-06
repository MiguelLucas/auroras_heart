using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC.TimeOfDaySystemFree;

public class RunesInteraction : Interaction
{
    private int state = 0;
    private YggdrasilQuestDialogue dialogueQuest = new YggdrasilQuestDialogue();
    [SerializeField]
    private TimeOfDay timeOfDay;
    [SerializeField]
    PlaceableObject RuneOfUrd; //Druid
    [SerializeField]
    PlaceableObject RuneOfVerthandi; //Leviathan
    [SerializeField]
    PlaceableObject RuneOfSkuld; //Veado
    [SerializeField]
    PortalSpell portallSpell;


    protected override void OnInteract()
    {
        if (state == 0)
        {
            InitialInteraction();
        }
        else if(state == 1)
        {
            if (gameManager.AllRunesPlaced())
                state++;
            else
            {
                YggdrasilQuest.Rune rune = gameManager.placeYggdrasilRune();

                Debug.Log("Rune " + rune);
                switch (rune)
                {
                    case YggdrasilQuest.Rune.Urd:
                        PlaceRuneOfUrd();
                        PlaceRuneInteraction(YggdrasilQuest.Rune.Urd.ToString());
                        break;
                    case YggdrasilQuest.Rune.Verthandi:
                        PlaceRuneOfVerthandi();
                        PlaceRuneInteraction(YggdrasilQuest.Rune.Verthandi.ToString());
                        break;
                    case YggdrasilQuest.Rune.Skuld:
                        PlaceRuneOfSkuld();
                        PlaceRuneInteraction(YggdrasilQuest.Rune.Skuld.ToString());
                        break;
                    default:
                        UnfinishedQuestInteraction();
                        break;

                }
            }
        }

        if (state == 2)
        {
            if (timeOfDay.IsMoonLight)
            {
                //SpellChanting();
                portallSpell.ActivateSpell();
                state++;
            }
            else
            {
                SpellNeedsMoonlingInteraction();
            }
        }
    }



    public void PlaceRuneOfUrd()
    {
        RuneOfUrd.gameObject.SetActive(true);
    }

    public void PlaceRuneOfVerthandi()
    {
        RuneOfVerthandi.gameObject.SetActive(true);
    }

    public void PlaceRuneOfSkuld()
    {
        RuneOfSkuld.gameObject.SetActive(true);
    }

    private void InitialInteraction()
    {
        Dialogue.DialogueStrings = dialogueQuest.StartDialogue();
        Dialogue.CharacterStrings = dialogueQuest.CharactersStart();
        Dialogue.PlayDialogue = true;
        Dialogue.Activate();
        state = 1;
    }

    private void UnfinishedQuestInteraction()
    {
        Dialogue.DialogueStrings = dialogueQuest.UnfinishedDialogue();
        Dialogue.CharacterStrings = dialogueQuest.CharactersUnfinished();
        Dialogue.PlayDialogue = true;
        Dialogue.Activate();

    }

    private void PlaceRuneInteraction(string name)
    {
        Dialogue.DialogueStrings = dialogueQuest.PlaceRuneDialogue(name);
        Dialogue.CharacterStrings = dialogueQuest.CharactersPlaceRune();
        Dialogue.PlayDialogue = true;
        Dialogue.Activate();

    }

    private void SpellNeedsMoonlingInteraction()
    {
        Dialogue.DialogueStrings = dialogueQuest.SpellNeedsMoonlightDialogue();
        Dialogue.CharacterStrings = dialogueQuest.CharactersSpellNeedsMoolight();
        Dialogue.PlayDialogue = true;
        Dialogue.Activate();

    }

    private void SpellChanting()
    {
        Dialogue.DialogueStrings = dialogueQuest.SpellChantingDialogue();
        Dialogue.CharacterStrings = dialogueQuest.CharactersSpellChanting();
        Dialogue.PlayDialogue = true;
        Dialogue.Activate();

    }
}
