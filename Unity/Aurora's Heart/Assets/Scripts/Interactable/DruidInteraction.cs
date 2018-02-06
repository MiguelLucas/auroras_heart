using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DruidInteraction : Interaction
{

    private int state = 0;
    private DruidQuestDialogue dialogueQuest = new DruidQuestDialogue();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void OnInteract()
    {
        if (state == 1) //Check if number of spirits is complete
        {
            if (gameManager.CompleteDruid())
                state++;
        }

        switch (state)
        {
            case 0:
                InitialInteraction();
                break;
            case 1:
                UnfinishedQuestInteraction();
                break;
            case 2:
                FinishQuestInteraction();
                gameManager.RemoveDruidBarriers(); //TODO: 
                break;
            case 3:
                AfterQuestInteraction();
                break;
            default:
                Debug.Log("Druid Interaction: Invalid State.");
                break;
        }

    }

    private void InitialInteraction()
    {
        Dialogue.DialogueStrings = dialogueQuest.StartDialogue();
        Dialogue.CharacterStrings = dialogueQuest.CharactersStart();
        Dialogue.TalkIndexes = dialogueQuest.TalkStart();
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

    private void FinishQuestInteraction()
    {
        Dialogue.DialogueStrings = dialogueQuest.EndDialogue();
        Dialogue.CharacterStrings = dialogueQuest.CharactersEnd();
        Dialogue.PlayDialogue = true;
        Dialogue.Activate();
        state = 3;
    }

    private void AfterQuestInteraction()
    {
        Dialogue.DialogueStrings = dialogueQuest.AfterDialogue();
        Dialogue.CharacterStrings = dialogueQuest.CharactersAfter();
        Dialogue.PlayDialogue = true;
        Dialogue.Activate();
    }

}
