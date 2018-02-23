using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character {

    [Header("Player stats")]
    [SerializeField]
    private float maxMana;
    [Header("Game Rates")]
    [SerializeField]
    [Range(0, 100)]
    private int rockFallPercentage = 5;
    [SerializeField]
    [Range(0, 20)]
    private float hpRecoveryRate = 5;
    [SerializeField]
    [Range(0, 10)]
    private float manaRecoveryRate = 2;
    [SerializeField]
    [Range(0, 300)]
    private float torchFireRate = 60;

    //------------------- UI Elements -------------------
    [Header("UI Elements")]
    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Slider healthSlider;
    [SerializeField]
    private Text manaText;
    [SerializeField]
    private Slider manaSlider;
    [SerializeField]
    private Text spiritText;
    [SerializeField]
    private Text mushroomText;
    [SerializeField]
    private Text scrollText;
    [SerializeField]
    private Text runeText;

    private float currentMana;
    private float currentHp;

    private int numberSpiritLights;
    private bool wristMenuActivated;

    private int previousMushroomSound = 0;
    private int previousIceSpellSound = 0;
    private int previousFireSpellSound = 0;
    private int previousBridgeSound = 0;
    private int previousLanternSound = 0;
    private int previousMysterySound = 0;
    private int previousWalkSound = 0;
    private int previousFootstepSound = 0;
    private int previousClimbSound = 0;
    private int previousRockFallSound = 0;
    private int previousCaveFootstepSound = 0;

    private int previousWaterSource = 0;

    private GvrAudioSource audioSource;

    private bool talkingInteractible = false;
    private bool canTalk = false;

    private float manaCounter = 0;
    private float hpCounter = 0;
    private float torchFireCounter = 0;

    private bool holdingTorch = false;


    // Use this for initialization
    void Start() {
        currentMana = maxMana;
        currentHp = maxHp;

        numberSpiritLights = 0;

        audioSource = GetComponent<GvrAudioSource>();
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.L)) {
            createSpiritLight(transform);
        }

        hpCounter += Time.deltaTime;
        manaCounter += Time.deltaTime;
        if (holdingTorch) {
            torchFireCounter += Time.deltaTime;
        }
            

        if (hpCounter > hpRecoveryRate) {
            if (currentHp < maxHp) {
                currentHp++;
                updateHpUI();
            }
            hpCounter = 0;
        }

        if (manaCounter > manaRecoveryRate) {
            if (currentMana < maxMana) {
                currentMana++;
                updateManaUI();
            }
            manaCounter = 0;
        }

    }

    public bool TalkingInteractible {
        get {
            return talkingInteractible;
        }

        set {
            talkingInteractible = value;
        }
    }

    public bool CanTalk {
        get {
            return canTalk;
        }

        set {
            canTalk = value;
        }
    }

    public void createSpiritLight(Transform transform) {

        if (GameManager.instance.Spirits > 0) {

            //TODO
            //GameObject newSpirit = GameManager.instance.SpiritObject.gameObject;
            /*newSpirit.transform.position = transform.position + (transform.forward * 2);
            newSpirit.SetActive(true);
            Instantiate(newSpirit);*/

            useSpirit();
        }
    }

    public void addSpiritLights(int number) {
        numberSpiritLights += number;
    }

    public void removeSpiritLights(int number) {
        numberSpiritLights -= number;

        if (numberSpiritLights < 0)
            numberSpiritLights = 0;
    }

    public bool WristMenuActivated {
        get {
            return wristMenuActivated;
        }

        set {
            wristMenuActivated = value;
        }
    }

    public float TorchFireCounter {
        get {
            return torchFireCounter;
        }

        set {
            torchFireCounter = value;
        }
    }

    public bool HoldingTorch {
        get {
            return holdingTorch;
        }

        set {
            holdingTorch = value;
        }
    }

    public float TorchFireRate {
        get {
            return torchFireRate;
        }

        set {
            torchFireRate = value;
        }
    }

    public override void damageHp(float damage) {
        base.damageHp(damage);
        //healthSlider.value = base.Hp;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Mushroom") {
            int index = chooseRandomSound(SoundManager.instance.MushroomSounds.Length, previousMushroomSound);
            if (index < 0) {
                return;
            }
            previousMushroomSound = index;
            print("colisão mushroom " + index);
            audioSource.PlayOneShot(SoundManager.instance.MushroomSounds[index]);
        }

        if (other.tag == "Bridge") {
            int index = chooseRandomSound(SoundManager.instance.DiscoverySounds.Length, previousBridgeSound);
            if (index < 0) {
                return;
            }
            previousBridgeSound = index;
            print("colisão bridge " + index);
            audioSource.PlayOneShot(SoundManager.instance.DiscoverySounds[index]);
        }

        if (other.tag == "Lamp") {
            int index = chooseRandomSound(SoundManager.instance.LanternSounds.Length, previousLanternSound);
            if (index < 0) {
                return;
            }
            previousLanternSound = index;
            print("colisão lantern " + index);
            audioSource.PlayOneShot(SoundManager.instance.LanternSounds[index]);
        }

        if (other.tag == "Yggdrasil, Ruins, Cave") {
            int index = chooseRandomSound(SoundManager.instance.MysterySounds.Length, previousMysterySound);
            if (index < 0) {
                return;
            }
            previousMysterySound = index;
            print("colisão mystery " + index);
            audioSource.PlayOneShot(SoundManager.instance.MysterySounds[index]);
        }

        if (other.tag == "Village") {
            print("Changing to village ambient sound");
            SoundManager.instance.enterVillage();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Village") {
            print("Exiting village ambient sound");
            SoundManager.instance.exitVillage();
        }
    }

    public AudioClip getSpellSound(string type) {
        if (type == "Ice") {
            int index = chooseRandomSound(SoundManager.instance.IceSpellSounds.Length, previousIceSpellSound);
            previousIceSpellSound = index;
            print("A disparar iceSpell " + index);
            return SoundManager.instance.IceSpellSounds[index];
        }

        if (type == "Fire") {
            int index = chooseRandomSound(SoundManager.instance.FireSpellSounds.Length, previousFireSpellSound);
            previousFireSpellSound = index;
            print("A disparar fireSpell " + index);
            return SoundManager.instance.FireSpellSounds[index];
        }

        return null;

    }

    public void playWalkSound() {
        if (GameManager.instance.CurrentScene != 2/*SceneType.Cave*/) {
            int index = chooseRandomSound(SoundManager.instance.WalkSounds.Length, previousWalkSound);
            if (index < 0) {
                return;
            }
            //print("Walk sound " + index);
            previousWalkSound = index;
            audioSource.PlayOneShot(SoundManager.instance.WalkSounds[index]);
        }
        
    }

    public void playFootstepSound() {
        if (GameManager.instance.CurrentScene == 1/*SceneType.Forest*/) {
            int index = chooseRandomSound(SoundManager.instance.FootstepSounds.Length, previousFootstepSound);
            //print("Footstep sound " + index);
            previousFootstepSound = index;
            audioSource.PlayOneShot(SoundManager.instance.FootstepSounds[index]);
        } else if (GameManager.instance.CurrentScene == 3/*SceneType.Cave*/) {
            int index = chooseRandomSound(SoundManager.instance.CaveFootstepSounds.Length, previousCaveFootstepSound);
            //print("Footstep sound " + index);
            previousCaveFootstepSound = index;
            audioSource.PlayOneShot(SoundManager.instance.CaveFootstepSounds[index]);
        }
        
    }

    private int chooseRandomSound(int arraySize, int previousSound) {
        if (arraySize <= 0)
            return -1;
        int index = Random.Range(0, arraySize);
        if (index == previousSound)
            index++;
        if (index > arraySize - 1)
            index = 0;
        return index;
    }

    public void changeWaterSoundSource() {
        float minDistance = float.MaxValue;
        int newWaterSource = 0;

        for (int i = 0; i < SoundManager.instance.WaterSoundPoints.Length; i++) {
            float distance = Vector3.Distance(transform.position, SoundManager.instance.WaterSoundPoints[i].transform.position);
            if (distance < minDistance) {
                minDistance = distance;
                newWaterSource = i;
            }
        }

        if (previousWaterSource != newWaterSource) {
            SoundManager.instance.WaterSoundSource.transform.position = SoundManager.instance.WaterSoundPoints[newWaterSource].transform.position;
            GvrAudioSource audioSource = SoundManager.instance.WaterSoundSource.GetComponent<GvrAudioSource>();
            audioSource.Play();
        }
    }

    public void caughtMushroom() {
        GameManager.instance.Mushrooms++;
        mushroomText.text = GameManager.instance.Mushrooms.ToString();
    }

    public void caughtScroll() {
        GameManager.instance.Scrolls++;
        scrollText.text = GameManager.instance.Scrolls.ToString();
    }

    public void useMushroom() {
        GameManager.instance.Mushrooms--;
        mushroomText.text = GameManager.instance.Mushrooms.ToString();
    }

    public void useScroll() {
        GameManager.instance.Scrolls--;
        scrollText.text = GameManager.instance.Scrolls.ToString();
    }

    public AudioClip playClimbSound() {
        int index = chooseRandomSound(SoundManager.instance.ClimbSounds.Length, previousClimbSound);
        previousClimbSound = index;
        int rnd = Random.Range(0, 100);
        if (rnd <= rockFallPercentage) {
            playRockFallSound();
        }
        return SoundManager.instance.ClimbSounds[index];
        
    }

    public void playRockFallSound() {
        int index = chooseRandomSound(SoundManager.instance.RockFallSounds.Length, previousRockFallSound);
        previousRockFallSound = index;
        audioSource.PlayOneShot(SoundManager.instance.RockFallSounds[index]);
    }

    public AudioClip playGrabChestSound() {
        return SoundManager.instance.ChestSounds[0];
    }

    public AudioClip playOpenChestSound() {
        return SoundManager.instance.ChestSounds[1];
    }

    public AudioClip playGrabScrollSound() {
        return SoundManager.instance.ChestSounds[2];
    }

    public AudioClip playTorchDropSound() {
        return SoundManager.instance.TorchDropSound;
    }

    public void selectIceSpell() {
        SpellManager.instance.CurrentSpell = 0;
    }

    public void selectFireSpell() {
        SpellManager.instance.CurrentSpell = 1;
    }

    public AudioClip castSpell(Transform controllerPosition) {

        if (currentMana >= SpellManager.instance.SpellList[SpellManager.instance.CurrentSpell].ManaCost) {
            SpellManager.instance.CastMagic(controllerPosition);
            currentMana -= SpellManager.instance.SpellList[SpellManager.instance.CurrentSpell].ManaCost;
            updateManaUI();

            if (SpellManager.instance.CurrentSpell == 0) {
                int index = chooseRandomSound(SoundManager.instance.IceSpellSounds.Length, previousIceSpellSound);
                previousIceSpellSound = index;
                return SoundManager.instance.IceSpellSounds[index];
            }

            if (SpellManager.instance.CurrentSpell == 1) {
                int index = chooseRandomSound(SoundManager.instance.FireSpellSounds.Length, previousFireSpellSound);
                previousFireSpellSound = index;
                return SoundManager.instance.FireSpellSounds[index];
            }
        }
        return null;
    }

    public void grabSkuldRune() {
        GameManager.instance.CaveReward();
        updateRuneUI();
    }

    public void updateManaUI() {
        manaText.text = currentMana.ToString();
        manaSlider.value = currentMana;
    }

    public void updateHpUI() {
        healthText.text = currentHp.ToString();
        healthSlider.value = currentHp;
    }

    public void updateRuneUI() {
        runeText.text = GameManager.instance.Runes.ToString();
    }

    public void useSpirit() {
        GameManager.instance.Spirits--;
        spiritText.text = GameManager.instance.Spirits.ToString();
    }

    public void playTalk(string person, int index) {
        audioSource.Stop();
        print(person + " talking " + index);
        switch (person) {
            case "Freya":
                audioSource.PlayOneShot(SoundManager.instance.GirlTalks[index]);
                break;
            case "Druid":
                audioSource.PlayOneShot(SoundManager.instance.DruidTalks[index]);
                break;
            case "Leviathan":
                audioSource.PlayOneShot(SoundManager.instance.LeviathanTalks[index]);
                break;
            case "Holle":
                audioSource.PlayOneShot(SoundManager.instance.DeerTalks[index]);
                break;
        }
    }
}
