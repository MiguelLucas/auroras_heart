using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC.TimeOfDaySystemFree;

public class ScreenFade : MonoBehaviour {

	[SerializeField]
	private WolfAI wolf;
	[SerializeField]
	private TimeOfDay timeOfDay;

	private float initFogDens; //initial fog density
    private float intiTimeLine;
	// Use this for initialization
	void Start () {

		initFogDens = timeOfDay.FogDensity;
        intiTimeLine = timeOfDay.timeline;
	}
	
	// Update is called once per frame
	void Update () {

		//calculateFogDensity ();
        //wolf.Energy = calculateEnergy();
    }

	void calculateFogDensity(){

		float energy = wolf.Energy;
		float density = 51f / 50f * (float)System.Math.Pow(energy, 2f) - 201f / 100f * energy + 1f;
		timeOfDay.FogDensity = density;

    }

    private float calculateEnergy()
    {
        float energy = -1f / 24 * System.Math.Abs((timeOfDay.timeline - intiTimeLine)) + 1;

        return energy;
    }
}
