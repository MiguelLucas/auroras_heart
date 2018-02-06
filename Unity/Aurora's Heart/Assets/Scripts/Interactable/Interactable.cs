using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

	public enum TypeInteractable {Character, Pickup, ObjPlacer};

	public string nameID = "";
	public TypeInteractable type; 
	public bool isSeen = false;
    public Interaction interaction;


    public bool IsInteracting()
    {
        if(type == TypeInteractable.Character)
        {
            if (nameID == "Holle")
                return interaction.IsInteracting();
            return interaction.Dialogue.PlayDialogue;
        }

        if(type == TypeInteractable.Pickup)
        {
            return false;
        }
        if (type == TypeInteractable.ObjPlacer)
        {
            return interaction.Dialogue.PlayDialogue;
        }

        return false;
    }

}
