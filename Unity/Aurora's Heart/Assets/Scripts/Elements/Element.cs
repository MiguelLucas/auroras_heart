using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour {

    [SerializedField]
    private ElementType elemType;


	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
}

public enum ElementType
{
    ice,
    fire,
    earth,
    death,
    forest
}
