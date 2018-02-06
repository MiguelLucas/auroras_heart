using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour {


    public float damageHP;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Enemy")
        {
            Character enemy = collider.GetComponent<Character>();
            enemy.damageHp(damageHP);
            //Debug.Log("Hit Enemy " + enemy.hp);
        }
    }
}
