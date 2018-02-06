using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarSpell : MonoBehaviour {

    [SerializeField]
    private GameObject bloom;
    [SerializeField]
    private ParticleSystem emission;
    [SerializeField]
    private int waitSecsForEmission = 1;
    [SerializeField]
    private int durationOfSpell = 3;
    [SerializeField]
    private bool spell = false;
    private AudioSource spellSound;
	// Use this for initialization
	void Start () {
        bloom.SetActive(false);
        emission.Stop();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            spell = true;
        }

        if (spell)
        {
            bloom.SetActive(true);
            StartCoroutine(WaitForEmission(waitSecsForEmission));
        }
	}


    IEnumerator WaitForEmission(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        emission.Play();
        spellSound = GetComponent<AudioSource>();
        spellSound.Play();
        StartCoroutine(StopSpell(durationOfSpell));

    }

    IEnumerator StopSpell(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        bloom.SetActive(false);
        emission.Stop();
        spell = false;
    }
}
