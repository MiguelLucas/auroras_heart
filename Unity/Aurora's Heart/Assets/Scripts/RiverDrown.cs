using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverDrown : MonoBehaviour {

    [SerializeField]
    private Player player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("COLIDIU "  + collider.tag);
        if(collider.tag == "Player")
        {
            player.instantKill();
        }
    }
}
