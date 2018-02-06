using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    private AudioSource audioSource;
    [SerializeField]
    private AudioClip clickSound;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		if (audioSource.volume < 1) {
            audioSource.volume += 0.002f;
        }

	}

    public void Button_NewGame() {
        audioSource.PlayOneShot(clickSound);
        print("New Game Button Clicked");
    }

    public void Button_Settings() {
        print("Settings Button Clicked");
        audioSource.PlayOneShot(clickSound);
    }

    public void Button_Continue() {
        print("Continue Button Clicked");
        audioSource.PlayOneShot(clickSound);
    }
}
