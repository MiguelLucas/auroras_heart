using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivate : MonoBehaviour {


	//[SerializeField]
	//Quest quest;

	void Start(){
		print("start");
	}

	public void onTriggerEnter(Collider coll){

		print("Colidiu");

	}


	public void onCollisionEnter(Collision coll){

		print("Colidiu2");

	}
}
