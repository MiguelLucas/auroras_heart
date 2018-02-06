using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC.TimeOfDaySystemFree;

public class NightMode : MonoBehaviour {

	[SerializeField]
	TimeOfDayManager time;

	GameObject[] nightObjects;
	GameObject[] dayObjects;

	// Use this for initialization
	void Start () {
		
		nightObjects = GameObject.FindGameObjectsWithTag ("Night");
		dayObjects = GameObject.FindGameObjectsWithTag ("Day");

	}
	
	// Update is called once per frame
	void Update () {

		bool night = time.IsNight;
		bool day = true;

		if (night) {
			day = false;
		}

		foreach (GameObject obj in nightObjects)
			obj.SetActive (night);
		foreach (GameObject obj in dayObjects)
			obj.SetActive (day);
		
	}
}
