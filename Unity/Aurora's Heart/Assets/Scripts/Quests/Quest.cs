using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour {

	protected bool Finish {get; set;}
	protected int State {get; set;}


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool Complete(int curr_value)
    {
        // Call virtual method onInteract
        return this.OnComplete(curr_value);
    }

    protected virtual bool OnComplete(int curr_value) //to be override 
    {
        // Do nothing
        return false;
    }
}
