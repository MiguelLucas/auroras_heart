using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RAIN.Core;
using System;

public class WolfAI : MonoBehaviour {

	[SerializeField]
	private float empathy = 0.5f; // Degree of empathy with the player
	[SerializeField]
	private float hunger = 1f; // Hunger level
	[SerializeField]
	private float energy = 1f; // Energy level
	[SerializeField]
	private int currentQuest = 0;
	[SerializeField]
	private bool wait = true; //Wait to perform a action in BT

	public float Empathy {
		get {
			return this.empathy;
		}
	}
    public float Hunger {
		get {
			return this.hunger;
		}
	}

	public float Energy {
		get {
			return this.energy;
		}
        set
        {
            this.energy = value;
        }
	}

	public int CurrentQuest {
		get {
			return this.currentQuest;
		}
	}

	public bool Wait {
		get {
			return this.wait;
		}
        set
        {
            this.wait = value;
        }

    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//Get wolf AI rig
		AIRig tRig = GetComponentInChildren<AIRig>();

		//Change state of memory
		tRig.AI.WorkingMemory.SetItem<System.Boolean>("Wait", wait);

	}

}
