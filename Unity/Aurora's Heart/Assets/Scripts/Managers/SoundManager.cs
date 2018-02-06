using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC.TimeOfDaySystemFree;

public class SoundManager : MonoBehaviour {

    [SerializeField]
    TimeOfDayManager time;


    [SerializeField]
    private int currentScene = 1;
    [SerializeField]
    private float fadingTime = 0.5f;

    [SerializeField]
    private AudioClip[] mushroomSoundsNight;
    [SerializeField]
    private AudioClip[] lanternSoundsNight;
    [SerializeField]
    private AudioClip[] walkSoundsNight;
    [SerializeField]
    private AudioClip[] discoverySoundsNight;
    [SerializeField]
    private AudioClip[] mysterySoundsNight;
    [SerializeField]
    private AudioClip[] dangerSoundsNight;

    [SerializeField]
    private AudioClip[] iceSpellSounds;
    [SerializeField]
    private AudioClip[] fireSpellSounds;

    [SerializeField]
    private AudioClip[] footstepSounds;
    [SerializeField]
    private AudioClip[] caveFootstepSounds;

    [SerializeField]
    private GvrAudioSoundfield dayAmbientSound;
    [SerializeField]
    private GvrAudioSoundfield nightAmbientSound;
    [SerializeField]
    private GvrAudioSoundfield villageAmbientSound;
    [SerializeField]
    private GvrAudioSoundfield caveAmbientSound;

    [SerializeField]
    private GameObject[] waterSoundPoints;
    [SerializeField]
    private GameObject waterSoundSource;

    [SerializeField]
    private AudioClip[] climbSounds;
    [SerializeField]
    private AudioClip[] rockFallSounds;
    [SerializeField]
    private AudioClip[] chestSounds;
    [SerializeField]
    private AudioClip torchDropSound;

    [SerializeField]
    private AudioClip[] girlTalks;
    [SerializeField]
    private AudioClip[] leviathanTalks;
    [SerializeField]
    private AudioClip[] druidTalks;
    [SerializeField]
    private AudioClip[] deerTalks;

    private AudioClip[] mushroomSounds;
    private AudioClip[] lanternSounds;
    private AudioClip[] walkSounds;
    private AudioClip[] discoverySounds;
    private AudioClip[] mysterySounds;
    private AudioClip[] dangerSounds;

    private bool previousTime = true;

    GvrAudioSoundfield soundfield;

    AudioSource elias;

    public AudioClip[] MysterySounds {
        get {
            return mysterySounds;
        }

        set {
            mysterySounds = value;
        }
    }

    public AudioClip[] DiscoverySounds {
        get {
            return discoverySounds;
        }

        set {
            discoverySounds = value;
        }
    }

    public AudioClip[] WalkSounds {
        get {
            return walkSounds;
        }

        set {
            walkSounds = value;
        }
    }

    public AudioClip[] LanternSounds {
        get {
            return lanternSounds;
        }

        set {
            lanternSounds = value;
        }
    }

    public AudioClip[] MushroomSounds {
        get {
            return mushroomSounds;
        }

        set {
            mushroomSounds = value;
        }
    }

    public AudioClip[] DangerSounds {
        get {
            return dangerSounds;
        }

        set {
            dangerSounds = value;
        }
    }

    public AudioClip[] IceSpellSounds {
        get {
            return iceSpellSounds;
        }

        set {
            iceSpellSounds = value;
        }
    }

    public AudioClip[] FootstepSounds {
        get {
            return footstepSounds;
        }

        set {
            footstepSounds = value;
        }
    }

    public AudioClip[] FireSpellSounds {
        get {
            return fireSpellSounds;
        }

        set {
            fireSpellSounds = value;
        }
    }

    public GameObject[] WaterSoundPoints {
        get {
            return waterSoundPoints;
        }

        set {
            waterSoundPoints = value;
        }
    }

    public GameObject WaterSoundSource {
        get {
            return waterSoundSource;
        }

        set {
            waterSoundSource = value;
        }
    }

    public AudioClip[] ClimbSounds {
        get {
            return climbSounds;
        }

        set {
            climbSounds = value;
        }
    }

    public AudioClip[] RockFallSounds {
        get {
            return rockFallSounds;
        }

        set {
            rockFallSounds = value;
        }
    }

    public AudioClip[] ChestSounds {
        get {
            return chestSounds;
        }

        set {
            chestSounds = value;
        }
    }

    public AudioClip[] CaveFootstepSounds {
        get {
            return caveFootstepSounds;
        }

        set {
            caveFootstepSounds = value;
        }
    }

    public AudioClip TorchDropSound {
        get {
            return torchDropSound;
        }

        set {
            torchDropSound = value;
        }
    }

    public AudioClip[] GirlTalks {
        get {
            return girlTalks;
        }

        set {
            girlTalks = value;
        }
    }

    public AudioClip[] LeviathanTalks {
        get {
            return leviathanTalks;
        }

        set {
            leviathanTalks = value;
        }
    }

    public AudioClip[] DruidTalks {
        get {
            return druidTalks;
        }

        set {
            druidTalks = value;
        }
    }

    public AudioClip[] DeerTalks {
        get {
            return deerTalks;
        }

        set {
            deerTalks = value;
        }
    }

    // Use this for initialization
    void Start () {
        soundfield = transform.Find("AmbientSound").Find("DaySound").GetComponent<GvrAudioSoundfield>();
        // GvrAudioSoundfield soundfield = transform.Find("DaySound").name;
        if (soundfield == null)
            print("Soundfield NULL");

        soundfield.enabled = true;


        StartCoroutine(LateStart(1));

        elias = GetComponent<AudioSource>();

        if (mysterySoundsNight.Length <= 0 || dangerSoundsNight.Length <= 0 || lanternSoundsNight.Length <= 0 || mushroomSoundsNight.Length <= 0 || discoverySoundsNight.Length <= 0 || walkSoundsNight.Length <= 0) {
            print("SoundManager error! Not all night clips are loaded.");
            return;
        }

    }

    IEnumerator LateStart(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        soundfield.Play();
    }

    // Update is called once per frame
    void Update () {
        switch (currentScene) {
            case 0:
                checkSounds();
                break;
            case 1:
                caveSounds();
                break;

        }
        
    }

    public void checkSounds() {

        dayAmbientSound.enabled = true;
        nightAmbientSound.enabled = true;
        villageAmbientSound.enabled = true;
        caveAmbientSound.enabled = false;

        bool night = time.IsNight;

        if (night && previousTime != night) {
            mushroomSounds = mushroomSoundsNight;
            dangerSounds = dangerSoundsNight;
            discoverySounds = discoverySoundsNight;
            mysterySounds = mysterySoundsNight;
            lanternSounds = lanternSoundsNight;
            walkSounds = walkSoundsNight;
            print("Changed to night sounds");

            StartCoroutine(fadeInAudio(nightAmbientSound));
            StartCoroutine(fadeOutAudioElias(0));
            StartCoroutine(fadeOutAudio(dayAmbientSound));
        } else if (!night && previousTime != night) {
            mushroomSounds = new AudioClip[0];
            dangerSounds = new AudioClip[0];
            discoverySounds = new AudioClip[0];
            mysterySounds = new AudioClip[0];
            lanternSounds = new AudioClip[0];
            walkSounds = new AudioClip[0];
            print("Changed to day sounds");

            StartCoroutine(fadeInAudio(dayAmbientSound));
            StartCoroutine(fadeInAudioElias());
            StartCoroutine(fadeOutAudio(nightAmbientSound));
        }

        previousTime = night;
    }

    public void caveSounds() {
        dayAmbientSound.enabled = false;
        nightAmbientSound.enabled = false;
        villageAmbientSound.enabled = false;
        caveAmbientSound.enabled = true;
        caveAmbientSound.volume = 1;
        elias.volume = 0.6f;
    }

    public IEnumerator fadeInAudio(GvrAudioSoundfield soundfield) {

        soundfield.enabled = true;

        soundfield.Play();
        while (soundfield.volume < 1) {
            soundfield.volume += 0.03f;
            //print("Incresing volume " + soundfield.volume);
            yield return new WaitForSeconds(fadingTime);
        }
    }

    public IEnumerator fadeOutAudio(GvrAudioSoundfield soundfield) {
        while (soundfield.volume > 0) {
            soundfield.volume -= 0.03f;
            //print("Decreasing volume " + soundfield.volume);
            yield return new WaitForSeconds(fadingTime);
        }

        soundfield.enabled = false;
    }

    IEnumerator fadeInAudioElias() {

        elias.enabled = true;

        while (elias.volume < 1) {
            elias.volume += 0.03f;
            //print("ELIAS incresing volume " + elias.volume);
            yield return new WaitForSeconds(fadingTime);
        }
    }

    IEnumerator fadeOutAudioElias(float fadeLimit) {
        while (elias.volume > fadeLimit) {
            elias.volume -= 0.03f;
            //print("ELIAS decreasing volume " + elias.volume);
            yield return new WaitForSeconds(fadingTime);
        }

        if (elias.volume <= 0) {
            elias.enabled = false;
        }
       
    }

    public void enterVillage() {
        StartCoroutine(fadeInAudio(villageAmbientSound));
        StartCoroutine(fadeOutAudioElias(0.4f));

        if (dayAmbientSound.enabled)
            StartCoroutine(fadeOutAudio(dayAmbientSound));
        if (nightAmbientSound.enabled)
            StartCoroutine(fadeOutAudio(nightAmbientSound));
    }

    public void exitVillage() {
        previousTime = !time.IsNight;
        checkSounds();
        StartCoroutine(fadeOutAudio(villageAmbientSound));
    }
}
