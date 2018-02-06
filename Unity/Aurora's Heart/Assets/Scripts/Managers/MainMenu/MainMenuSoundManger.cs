using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuSoundManger : MonoBehaviour {

    [SerializeField]
    private AudioClip aurorasHeartTheme;
    [SerializeField]
    private AudioClip clickSound;
    [SerializeField]
    private float fadeInRate = 0.001f;

    private GvrAudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<GvrAudioSource>();
        audioSource.clip = aurorasHeartTheme;
        StartCoroutine(playDelayed());
	}
	
	// Update is called once per frame
	void Update () {
        if (audioSource.volume < 1) {
            audioSource.volume += fadeInRate;
        }
    }

    public void playClickSound() {
        audioSource.PlayOneShot(clickSound);
    }

    public IEnumerator playDelayed() {
        yield return new WaitForSeconds(0.5f);
        audioSource.Play();
    }
}
