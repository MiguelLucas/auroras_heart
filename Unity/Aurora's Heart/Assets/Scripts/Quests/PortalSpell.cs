using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpell : MonoBehaviour {

    [SerializeField]
    private ParticleSystem[] lights;
    [SerializeField]
    private ParticleSystem ray;
    [SerializeField]
    private ParticleSystem explosion;
    [SerializeField]
    private int secsBetweenLights = 1;
    [SerializeField]
    private int secsExplosion = 1;
    [SerializeField]
    private bool spell = false;
    [SerializeField]
    private int degRot = 50;
    [SerializeField]
    private int upTransf = 1;
    [SerializeField]
    private AudioClip chantSpell;
    [SerializeField]
    private AudioClip lightsSpell;
    private bool rotate = false;
    private bool activateRay = true;
    private GvrAudioSource audioSpell;
   

	// Use this for initialization
	void Start () {

        deactivateLights();

        ray.Stop();
        explosion.Stop();
        audioSpell = GetComponent<GvrAudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        if (rotate)
        {
            // Rotate the object around its local X axis at 1 degree per second
            //this.transform.Rotate(Vector3.right * Time.deltaTime * 10);

            // ...also rotate around the World's Y axis
            this.transform.Rotate(Vector3.up * degRot * Time.deltaTime, Space.World);
            if(degRot < 360)
            {
                degRot += 1;
            }
            else
            {
                this.transform.Translate(Vector3.up * upTransf * Time.deltaTime, Space.World);
                if (activateRay)
                {
                    ray.Play();
                    StartCoroutine(WaitExplosion(secsExplosion));
                    activateRay = false;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.O)) //TODO: REMOVE
        {
            spell = true;
        }

        if (spell)
            ActivateSpell();
    }

    private void deactivateLights()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].Stop();

        }
    }

    public void ActivateSpell()
    {
        audioSpell.PlayOneShot(chantSpell);
        StartLightsSpell();
    }

    public void StartLightsSpell() {

        audioSpell.PlayOneShot(lightsSpell);
        int secs = 0;
        for (int i = 0; i < lights.Length; i++) {
            //lights[i].Play();
            StartCoroutine(WaitLights(i, secs));
            //System.Threading.Thread.Sleep(secsBetweenLights);
            secs += secsBetweenLights;

        }
        spell = false;
    }

    IEnumerator WaitLights(int i, int seconds)
    {
        yield return new WaitForSeconds(seconds);
        lights[i].Play();
        if(i + 1 == lights.Length)
        {
            rotate = true;
        }
    }

    IEnumerator WaitExplosion(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        ray.Stop();
        explosion.Play();
        deactivateLights();
    }

    IEnumerator spellWithDelay(float delay) {
        yield return new WaitForSeconds(delay);
        StartLightsSpell();
    }
}
