using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour {

    [SerializeField]
    private List<Spell> spellList = new List<Spell>();

    private int currentSpell = 0;

    void Start() {

    }

    void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.Z)) {
            CastMagic(transform);
        }
    }

    public List<Spell> SpellList {
        get {
            return spellList;
        }

        set {
            spellList = value;
        }
    }

    public int CurrentSpell {
        get {
            return currentSpell;
        }

        set {
            currentSpell = value;
        }
    }

    public void CastMagic(Transform transform) {

        Spell spell = spellList[currentSpell];

        if (spell.SpellPrefab == null) {
            Debug.LogWarning("Spell prefab is null.");
            return;
        } else {
            GameObject spellObject = Instantiate(spell.SpellPrefab, transform.position, transform.rotation);
            spellObject.AddComponent<Rigidbody>();
            spellObject.GetComponent<Rigidbody>().useGravity = false;
            spellObject.GetComponent<Rigidbody>().velocity = spellObject.transform.forward * spell.ProjectileSpeed;
            spellObject.name = spell.SpellName;
            //spellObject.transform.parent = GameObject.Find("SpellManager").transform;

            Destroy(spellObject, 2);
        }
    }
}
