using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RAIN.Core;

public class HolleInteraction : Interaction {

    private int state = 0;
    private HolleQuestDialogue dialogueQuest = new HolleQuestDialogue();
    private AIRig tRig;
    private bool complete = false;
    private bool talk = false;


    public int State
    {
        get
        {
            return state;
        }

        set
        {
            state = value;
        }
    }

    void Start()
    {
        //Get leviathan AI rig
        tRig = GetComponentInChildren<AIRig>();

        //Change state of memory
        tRig.AI.WorkingMemory.SetItem<System.Boolean>("Complete", complete);
        //Change state of memory
        tRig.AI.WorkingMemory.SetItem<System.Boolean>("Talk", false);
    }

    void Update()
    {
        if (state == 1) //Check if all scrolls are place in the altar
        {
            if (gameManager.AllScrollsPlaced())
                state++;
        }
        if (!Dialogue.IsDialoguePlaying)
            talk = false;
        if (Dialogue.Finished) //Update values of AI
        {
            //Change state of memory
            tRig.AI.WorkingMemory.SetItem<System.Boolean>("Complete", complete);
        }
        tRig.AI.WorkingMemory.SetItem<System.Boolean>("Talk", talk);
    }

    protected override void OnInteract()
    {
        
        switch (state)
        {
            case 0:
                InitialInteraction();
                talk = true;
                break;
            case 1:
                UnfinishedQuestInteraction();
                talk = true;
                break;
            case 2:
                FinishQuestInteraction();
                talk = true;
                complete = true;
                break;
            case 3:
                AfterQuestInteraction();
                talk = true;
                break;
            default:
                Debug.Log("Holle: Invalid State.");
                break;
        }

    }

    protected override bool OnIsInteracting()
    {
        if (dialogue.IsDialoguePlaying)
            return true;
        if (complete)
            return true;
        return false;
    }



    private void InitialInteraction()
    {
        Dialogue.DialogueStrings = dialogueQuest.StartDialogue();
        Dialogue.CharacterStrings = dialogueQuest.CharactersStart();
        Dialogue.PlayDialogue = true;
        Dialogue.Activate();
        State = 1;
    }

    public void UnfinishedQuestInteraction()
    {
        Dialogue.DialogueStrings = dialogueQuest.UnfinishedDialogue();
        Dialogue.CharacterStrings = dialogueQuest.CharactersUnfinished();
        Dialogue.PlayDialogue = true;
        Dialogue.Activate();

    }

    private void FinishQuestInteraction()
    {
        Dialogue.DialogueStrings = dialogueQuest.EndDialogue();
        Dialogue.CharacterStrings = dialogueQuest.CharactersEnd();
        Dialogue.PlayDialogue = true;
        Dialogue.Activate();
        State = 3;
    }

    private void AfterQuestInteraction()
    {
        Dialogue.DialogueStrings = dialogueQuest.AfterDialogue();
        Dialogue.CharacterStrings = dialogueQuest.CharactersAfter();
        Dialogue.PlayDialogue = true;
        Dialogue.Activate();
    }

    public void AltarBeforeTalkingToHolle()
    {
        Dialogue.DialogueStrings = dialogueQuest.AltarBeforeTalkingToHolle();
        Dialogue.CharacterStrings = dialogueQuest.CharactersAltarBeforeTalkingToHolle();
        Dialogue.PlayDialogue = true;
        Dialogue.Activate();
    }

    public void AltarAllScrolls()
    {
        Dialogue.DialogueStrings = dialogueQuest.AltarAllScrolls();
        Dialogue.CharacterStrings = dialogueQuest.CharactersAltarAllScrolls();
        Dialogue.PlayDialogue = true;
        Dialogue.Activate();
    }

    public void PlaceScrollInteraction(string name)
    {
        Dialogue.DialogueStrings = dialogueQuest.PlaceScrollDialogue(name);
        Dialogue.CharacterStrings = dialogueQuest.CharactersPlaceScroll();
        Dialogue.PlayDialogue = true;
        Dialogue.Activate();
    }

    public void NoScrollToPlace()
    {
        Dialogue.DialogueStrings = dialogueQuest.NoScrollsToPlaceDialogue();
        Dialogue.CharacterStrings = dialogueQuest.CharactersNoScrollToPlace();
        Dialogue.PlayDialogue = true;
        Dialogue.Activate();
    }
    
    public void StartAltarSpell()
    {
        Dialogue.DialogueStrings = dialogueQuest.StartAltarSpell();
        Dialogue.CharacterStrings = dialogueQuest.CharactersAltarSpell();
        Dialogue.PlayDialogue = true;
        Dialogue.Activate();

    }
}
