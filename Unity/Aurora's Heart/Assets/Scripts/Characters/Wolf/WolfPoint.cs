using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfPoint : MonoBehaviour {

    [SerializeField]
    private Transform playerLocation;
    private float moveSpeed = 5f;
    // Use this for initialization
    void Start () {

        transform.position = playerLocation.position;
		
	}
	
	// Update is called once per frame
	void LateUpdate () {

        //move towards the player
        transform.position = playerLocation.position + new Vector3(1f,0,4f);

    }
}
