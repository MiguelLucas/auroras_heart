using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugrelInteraction : Interaction {

    [SerializeField]
    private WolfAI hugrel;
    private int state = 0;
    private HugrelDialogue hugrelDialogue = new HugrelDialogue();
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
		
	}

     protected override void OnInteract()
    {
        switch (state){

            case 0:
                initialInteraction();
                break;

            default:
                Debug.Log("Unknow state on interact.");
                break;
        }
    }


    private void initialInteraction()
    {
        Dialogue.DialogueStrings = hugrelDialogue.DetectHugrel();
        Dialogue.CharacterStrings = hugrelDialogue.CharactersDetectHugrel();
        Dialogue.PlayDialogue = true;
        Dialogue.Activate();
        state++;
        hugrel.Wait = false;

    }
     
}
