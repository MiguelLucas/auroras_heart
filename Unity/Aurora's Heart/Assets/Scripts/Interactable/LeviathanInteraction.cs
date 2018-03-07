using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeviathanInteraction : Interaction {

    private int state = 0;
    private LeviathanQuestDialogue dialogueQuest = new LeviathanQuestDialogue();
    private bool wait = true;
    private float startWalking = 0f;
    private float lookAroundAfterSecs = 10f; // 5 = two seconds
    private bool lookAround = true;

    public bool LookAround
    {
        get
        {
            return lookAround;
        }

        set
        {
            lookAround = value;
        }
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        if (Dialogue.IsDialoguePlaying && !wait)
        {
            wait = true;
        }else if(state != 0 && !Dialogue.IsDialoguePlaying && wait)
        {
            wait = false;
        }

        if (state != 0 && !LookAround)
        {
            StopToLookAround();
        }

    }

    protected override void OnInteract()
    {
        if (state == 0 || (state != 0 && LookAround))
        {
            if (state == 1) //Check if number of spirits is complete
            {
                if (gameManager.CompleteLeviathan())
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
                    gameManager.RemoveLeviathanBarriers(); //TODO: 
                    break;
                case 3:
                    AfterQuestInteraction();
                    break;
                default:
                    Debug.Log("Leviathan: Invalid State.");
                    break;
            }
        }
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


    private void StopToLookAround()
    {

        if (Time.time > startWalking + lookAroundAfterSecs)
        {
            lookAroundAfterSecs = Time.time;
            LookAround = true;
        }
    }

    public void StopLooking()
    {
        startWalking = Time.time;
        LookAround = false;
    }
}
