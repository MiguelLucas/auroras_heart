using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour {

    [SerializeField]
    protected Dialogue dialogue;
    [SerializeField]
    protected GameManager gameManager;

    public Dialogue Dialogue
    {
        get
        {
            return dialogue;
        }

        set
        {
            dialogue = value;
        }
    }


    public void Interact()
    {
        // Call virtual method onInteract
        this.OnInteract();
    }

    protected virtual void OnInteract() //to be override 
    { 
        // Do nothing
    }

    public bool IsInteracting()
    {
        return this.OnIsInteracting();
    }

    protected virtual bool OnIsInteracting() //to be override 
    {
        // Do nothing
        return false;
    }
}
