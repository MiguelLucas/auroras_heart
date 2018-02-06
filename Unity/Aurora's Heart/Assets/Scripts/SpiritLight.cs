using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritLight : MonoBehaviour {

    [SerializeField]
    private float fadeOutValue;
    [SerializeField]
    private float timeToFade;
    [SerializeField]
    private float upperLimit;
    [SerializeField]
    private float lowerLimit;
    [SerializeField]
    private float acceleration;

    private float timer;
    private Light light;
    private float originalScale;

    private float middlePoint;
    private float currentSpeed;
    private bool goingUp;
    private bool accelerating;

    private float height;

	// Use this for initialization
	void Start () {
        timer = 0;
        originalScale = transform.localScale.x;
        light = GetComponentInChildren<Light>();
        middlePoint = (upperLimit + lowerLimit) / 2;
        currentSpeed = 0;
        transform.position.Set(transform.position.x, lowerLimit, transform.position.z);
        goingUp = true;
        accelerating = true;
        height = 0;
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        
        if (timer >= timeToFade)
        {
            light.intensity -= fadeOutValue;
            transform.localScale -= new Vector3(fadeOutValue * originalScale, fadeOutValue * originalScale, fadeOutValue * originalScale);
            timer = 0;
            if (light.intensity <= 0 )
                Destroy(gameObject);
        }

        if (goingUp)
        {
            height += acceleration;
            transform.Translate(new Vector3(0, height, 0));
        } else
        {
            height -= acceleration;
            transform.Translate(new Vector3(0, -height, 0));
        }

        if (height*100 > upperLimit)
        {
            goingUp = false;
        }

        if (height*100 < lowerLimit)
        {
            goingUp = true;
        }
        
    }
}
